using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;

namespace APIClient
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            CustomerInformation newCustomer = new CustomerInformation();

            newCustomer.LoginID = txtEmail.Text;
            newCustomer.Name = txtName.Text;
            newCustomer.Password = txtpassword.Text;
            newCustomer.Address = txtAddress.Text;
            newCustomer.City = txtCity.Text;
            newCustomer.State = ddlState.Text;
            newCustomer.ZipCode = txtZipcode.Text;

            if (Validation())
            {
                //Add new Customer to TP_Customer DB
                if (register.NewCustomer(newCustomer) == true)
                {
                    //if "Remember Me" is checked, store username in cookie
                    if (chkbxRememberMe.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("LoginCookie");
                        cookie.Values["Email"] = txtEmail.Text;
                        cookie.Values["LastVisited"] = DateTime.Now.ToString();
                        cookie.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        // if not checked, don't store username in cookie
                        Response.Cookies.Remove("loginID");
                    }
                }
                Response.Redirect("Login.aspx");
            }
            else
            {
                txtName.Text = "";
                txtEmail.Text = "";
                txtpassword.Text = "";
                txtReenterPassword.Text = "";

                lblError.Text = "Error. Try Again.";
            }
        }

        public bool Validation()
        {
            bool validInput;
            bool passwordsEqual = String.Equals(txtpassword.ToString(), txtReenterPassword.ToString());

            if (txtName.Text == "")
            {
                lblInvalidName.Text = "Please enter your name.";
                validInput = false;
            }

            //check if email is valid
            if (txtEmail.Text.IndexOf("@") == -1 || txtEmail.Text.IndexOf(".") == -1)
            {
                validInput = false;
            }
            else
            {

            }

            //passwords dont match
            if (!passwordsEqual)
            {
                lblPasswordsDontMatch.Text = "Passwords Must Match";
                txtpassword.Text = "";
                txtReenterPassword.Text = "";
                validInput = false;
            }
            else
            {
                validInput = true;
            }

            return validInput;
        }

        protected void btnRegisterforMerchantAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationMerchant.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}