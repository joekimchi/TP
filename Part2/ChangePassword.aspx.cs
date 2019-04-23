﻿using System;
using Utilities;

namespace AmazonTermProject
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SPCaller spc = new SPCaller();
        string loginID;
        int accountType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            loginID = Session["Username"].ToString();
            accountType = int.Parse(Session["AccountType"].ToString());
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPW = txtOldPassword.Text;
            string newPW = txtNewPassword.Text;
            string newPW2 = txtConfirmPassword.Text;

            if (newPW == newPW2) {
                bool result = spc.ChangePassword(accountType, loginID, oldPW, newPW);

                if (result)
                    lblResult.Text = "Password successfully updated.";
                else
                    lblResult.Text = "Oops. There was an error updating your password.";
            }
            else
                lblNotMatched.Text = "Check that your new passwords match.";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx", false);
        }
    }
}