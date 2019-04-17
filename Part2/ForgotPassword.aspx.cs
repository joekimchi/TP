using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email;

            email = txtEmailAddress.Text;

            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            if (email.Length != 0)
            {
                //if dropdown selection is Customer
                if (ddlLoginType.Text == "Customer")
                {
                    objcommand.CommandType = CommandType.StoredProcedure;
                    objcommand.CommandText = "TP_GetCustomerByEmail";
                    objcommand.Parameters.AddWithValue("@email", email);

                    ds = db.GetDataSetUsingCmdObj(objcommand);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        lblError.Text = "We're sorry. We weren't able to identify you given the information provided.";
                    }
                    else
                    {
                        lblError.Text = "";
                        txtEmailAddress.ReadOnly = true;
                        txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;
                    }
                }
                //if dropdown selection is Merchant
                if (ddlLoginType.Text == "Merchant")
                {
                    objcommand.CommandType = CommandType.StoredProcedure;
                    objcommand.CommandText = "TP_GetMerchantByEmail";
                    objcommand.Parameters.AddWithValue("@email", email);

                    ds = db.GetDataSetUsingCmdObj(objcommand);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        lblError.Text = "We're sorry. We weren't able to identify you given the information provided.";
                    }
                    else
                    {
                        lblError.Text = "";
                        txtEmailAddress.ReadOnly = true;
                        txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;
                    }
                }
            }

            else
            {
                lblError.Visible = true;
                lblError.Text = "Enter your email";
            }
        }
    }
}