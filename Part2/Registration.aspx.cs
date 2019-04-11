using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;

namespace Part2
{
    public partial class Registration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        APICalls api = new APICalls();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegisterforMerchantAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterMerchant.aspx", false);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            CustomerInformation newCustomer = new CustomerInformation();

            newCustomer.LoginID = txtEmail.Text;
            newCustomer.Name = txtName.Text;
            newCustomer.Password = txtPassword.Text;
            newCustomer.Address = txtAddress.Text;
            newCustomer.City = txtCity.Text;
            newCustomer.State = ddlState.Text;
            newCustomer.ZipCode = txtZipcode.Text;
            newCustomer.SecurityQuestion1 = ddlSecurityQuestion1.Text;
            newCustomer.SecurityAnswer1 = txtSecurityAnswer1.Text;
            newCustomer.SecurityQuestion2 = ddlSecurityQuestion2.Text;
            newCustomer.SecurityAnswer2 = txtSecurityAnswer2.Text;

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
                txtPassword.Text = "";
                txtReenterPassword.Text = "";

                lblError.Text = "Error. Try Again.";
            }
        }

        public bool Validation()
        {
            bool validInput;
            bool passwordsEqual = String.Equals(txtPassword.ToString(), txtReenterPassword.ToString());

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
                validInput = true;
            }

            //passwords dont match
            if (!passwordsEqual)
            {
                lblPasswordsDontMatch.Text = "Passwords Must Match";
                txtPassword.Text = "";
                txtReenterPassword.Text = "";
                validInput = false;
            }
            else
            {
                validInput = true;
            }

            return validInput;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}