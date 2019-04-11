using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;

namespace Part2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CustomerInformation newCustomer = new CustomerInformation();
            Register register = new Register();

            bool loginSuccess;
            if (ddlLoginType.SelectedValue == "0")
            {
                loginSuccess = register.ValidCustomerLogin(txtEmail.Text, txtPassword.Text);
            }
            else loginSuccess = register.ValidMerchantLogin(txtEmail.Text, txtPassword.Text);

            //if session exists, load cookie value into txtbox
            if (Session["LoginID"] != null)
            {
                HttpCookie emailCookie = Request.Cookies["loginID"];
                txtEmail.Text = emailCookie.Values["LoginID"].ToString();
                chkbxRememberMe.Checked = true;
            }

            //if user enters a valid username and password
            if (loginSuccess)
            {
                //just to test if it works
                Response.Redirect("testpage.aspx");

                //Remember Me is checked - store email into cookie
                if (chkbxRememberMe.Checked)
                {
                    HttpCookie emailCookie = new HttpCookie("LoginCookie");
                    emailCookie.Values["Email"] = txtEmail.Text;
                    emailCookie.Values["LastVisited"] = DateTime.Now.ToString();
                    emailCookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(emailCookie);
                }
                else
                {
                    //remove user's email from username textbox
                    Response.Cookies.Remove("loginID");
                }
            }

            //invalid login
            else
            {
                lblLoginErrorMessage.Text = "Incorrect Credentials";
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