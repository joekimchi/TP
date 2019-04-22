﻿using System;
using Utilities;
using System.Data;

namespace Part2
{
    public partial class UpdateMerchantAccountInformation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string loginID;
        int accountType;
        SPCaller spc = new SPCaller();
        protected void Page_Load(object sender, EventArgs e)
        {
            loginID = Session["Username"].ToString();
            accountType = int.Parse(Session["AccountType"].ToString());

            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                DataSet myDS = spc.GetAccountInfoByTypeAndLogin(accountType, loginID);

                txtName.Text = myDS.Tables[0].Rows[0][0].ToString();
                txtPhoneNumber.Text = myDS.Tables[0].Rows[0][1].ToString();
                txtAddress.Text = myDS.Tables[0].Rows[0][2].ToString();
                txtCity.Text = myDS.Tables[0].Rows[0][3].ToString();
                ddlState.SelectedValue = myDS.Tables[0].Rows[0][4].ToString();
                txtZipCode.Text = myDS.Tables[0].Rows[0][5].ToString();
            }
        }

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhoneNumber.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string state = ddlState.SelectedValue;
            int zipCode = int.Parse(txtZipCode.Text);

            bool result = spc.UpdateAccountInfo(accountType, loginID, name, phone, address, city, state, zipCode);

            if (result)
                lblResult.Text = "Account information successfully updated.";
            else
                lblResult.Text = "Something went wrong. Your account information was not updated.";
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchantHome.aspx", false);
        }
    }
}