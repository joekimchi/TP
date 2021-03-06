﻿using System;
using Utilities;
using System.Data;

namespace Part2
{
    public partial class UpdateCreditCardInformation : System.Web.UI.Page
    {
        SPCaller spc = new SPCaller();
        int customerID;
        DataSet myDS;

        Validation val = new Validation();

        string currMonth = DateTime.Now.ToString("MM");
        string currYear = DateTime.Now.ToString("yy");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else
            {
                string username = Session["Username"].ToString();
                customerID = spc.GetCustomerIDByEmail(username);

                if (!IsPostBack)
                {
                    myDS = spc.GetCCByCustomerID(customerID);
                    if (myDS.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                        {
                            ddlCard.Items.Add(myDS.Tables[0].Rows[i][1].ToString());
                        }

                        int cardID = int.Parse(ddlCard.SelectedValue);
                        myDS = spc.GetCCInfoByCardID(cardID);

                        if (myDS.Tables[0].Rows.Count > 0)
                        {
                            txtCardNumber.Text = myDS.Tables[0].Rows[0][0].ToString();
                            string expiration = myDS.Tables[0].Rows[0][1].ToString();
                            string[] arrExpiration = expiration.Split('/');

                            ddlMonth.SelectedValue = arrExpiration[0].Trim();
                            ddlYear.SelectedValue = arrExpiration[1].Trim();
                        }
                    }
                }
            }
        }

        protected void ddlCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cardID = int.Parse(ddlCard.SelectedValue);
            myDS = spc.GetCCInfoByCardID(cardID);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                txtCardNumber.Text = myDS.Tables[0].Rows[0][0].ToString();
                string expiration = myDS.Tables[0].Rows[0][1].ToString();
                string[] arrExpiration = expiration.Split('/');

                ddlMonth.SelectedValue = arrExpiration[0].Trim();
                ddlYear.SelectedValue = arrExpiration[1].Trim();
            }
        }

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text;
            string expiration = ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue;

            if (!val.isBlank(cardNumber) && val.isValidCC(cardNumber))
            {

                if (spc.UpdateCC(int.Parse(ddlCard.SelectedValue), cardNumber, expiration))
                    lblResult.Text = "Card successfully updated.";
                else
                    lblResult.Text = "Card was not updated. Please try again later.";
            }
            else
                lblResult.Text = "Invalid credit card number.";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx", false);
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedIndex <= int.Parse(currMonth))
                ddlYear.SelectedValue = (int.Parse(currYear) + 1).ToString();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlYear.SelectedIndex <= int.Parse(currYear))
                ddlYear.SelectedValue = currYear;
        }
    }
}