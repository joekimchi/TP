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
            string email = txtEmailAddress.Text;

            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            if (email.Length == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Enter your email";
                txtEmailAddress.Focus();
            }
            else
            {
                //if dropdown selection is Customer
                if (ddlLoginType.Text == "Customer")
                {
                    objcommand.CommandType = CommandType.StoredProcedure;
                    objcommand.CommandText = "TP_GetCustomerByEmail";
                    objcommand.Parameters.AddWithValue("@email", email);

                    ds = db.GetDataSetUsingCmdObj(objcommand);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        lblError.Text = "";
                        txtEmailAddress.ReadOnly = true;
                        ddlLoginType.Enabled = false;
                        txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;
                        
                    }
                    else
                    {
                        lblError.Text = "We're sorry. We weren't able to identify you given the information provided.";
                        txtEmailAddress.Focus();
                    }
                }
                //if dropdown selection is Merchant
                if (ddlLoginType.Text == "Merchant")
                {
                    objcommand.CommandType = CommandType.StoredProcedure;
                    objcommand.CommandText = "TP_GetMerchantByEmail";
                    objcommand.Parameters.AddWithValue("@email", email);

                    ds = db.GetDataSetUsingCmdObj(objcommand);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        lblError.Text = "";
                        txtEmailAddress.ReadOnly = true;
                        ddlLoginType.Enabled = false;
                        txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;

                    }
                    else
                    {
                        lblError.Text = "We're sorry. We weren't able to identify you given the information provided.";
                        txtEmailAddress.Focus();
                    }
                }
            }
        }
    }
}