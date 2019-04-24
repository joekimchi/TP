using System;
using Utilities;

namespace Part2
{
    public partial class AddCreditCard : System.Web.UI.Page
    {
        int customerID;
        SPCaller spc = new SPCaller();
        Validation val = new Validation();

        string currMonth = DateTime.Now.ToString("MM");
        string currYear = DateTime.Now.ToString("yy");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                string email = Session["Username"].ToString();
                customerID = spc.GetCustomerIDByEmail(email);
                ddlMonth.SelectedValue = currMonth;
                ddlYear.SelectedValue = currYear;
            }
        }

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text;
            string expiration = ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue;

            if (!val.isBlank(cardNumber) && val.isValidCC(cardNumber))
            {

                if (spc.AddCreditCard(customerID, cardNumber, expiration))
                    lblResult.Text = "You successfully added a credit card.";
                else
                    lblResult.Text = "Sorry, your card was not added. Try again later.";
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