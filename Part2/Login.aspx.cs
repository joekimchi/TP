using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace AmazonTermProject
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Username"] != null)
                    txtEmail.Text = Request.Cookies["Username"].Value;
                if (Request.Cookies["Password"] != null)
                    txtPassword.Attributes.Add("value", Request.Cookies["Password"].Value);
                if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
                    chkbxRememberMe.Checked = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username;
            string password;

            username = txtEmail.Text;
            password = txtPassword.Text;

            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            //if dropdown selection is Customer
            if (ddlLoginType.Text == "Customer")
            {
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.CommandText = "TP_CustomerLogin";
                objcommand.Parameters.AddWithValue("@username", username);
                objcommand.Parameters.AddWithValue("@password", password);

                ds = db.GetDataSetUsingCmdObj(objcommand);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblLoginErrorMessage.Text = "Incorrect username or password";
                }
                else
                {
                    if(chkbxRememberMe.Checked == true)
                    {
                        Response.Cookies["Username"].Value = txtEmail.Text;
                        Response.Cookies["Password"].Value = txtPassword.Text;
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }

                    Session["AccountType"] = 0;
                    Session["Username"] = username;
                    Session["Password"] = password;
                    Response.Redirect("CustomerHome.aspx");
                }
            }
            //if dropdown selection is Merchant
            if (ddlLoginType.Text == "Merchant")
            {
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.CommandText = "TP_MerchantLogin";
                objcommand.Parameters.AddWithValue("@username", username);
                objcommand.Parameters.AddWithValue("@password", password);

                ds = db.GetDataSetUsingCmdObj(objcommand);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblLoginErrorMessage.Text = "Incorrect username or password";
                }
                else
                {
                    if (chkbxRememberMe.Checked == true)
                    {
                        Response.Cookies["Username"].Value = txtEmail.Text;
                        Response.Cookies["Password"].Value = txtPassword.Text;
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }

                    Session["AccountType"] = 1;
                    Session["Username"] = username;
                    Session["Password"] = password;
                    Response.Redirect("MerchantHome.aspx", false);
                }
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }
    }
}