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
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username;
            string password;

            username = txtEmail.Text;
            password = txtPassword.Text;

            DBConnect newUserConnection = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            //if dropdown selection is Customer
            if (ddlLoginType.Text == "Customer")
            {
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.CommandText = "TP_CustomerLogin";
                objcommand.Parameters.AddWithValue("@username", username);
                objcommand.Parameters.AddWithValue("@password", password);

                ds = newUserConnection.GetDataSetUsingCmdObj(objcommand);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblLoginErrorMessage.Text = "Incorrect username or password";
                }
                else
                {
                    Session["CustomerUsername"] = username;
                    Response.Redirect(".aspx");
                }
            }
            //if dropdown selection is Merchant
            else
            {
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.CommandText = "TP_MerchantLogin";
                objcommand.Parameters.AddWithValue("@username", username);
                objcommand.Parameters.AddWithValue("@password", password);

                ds = newUserConnection.GetDataSetUsingCmdObj(objcommand);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblLoginErrorMessage.Text = "Incorrect username or password";
                }
                else
                {
                    Session["MerchantUsername"] = username;
                    Response.Redirect(".aspx");
                }
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}