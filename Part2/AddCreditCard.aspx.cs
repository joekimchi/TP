using System;
using Utilities;

namespace Part2
{
    public partial class AddCreditCard : System.Web.UI.Page
    {
        int customerID;
        SPCaller spc = new SPCaller();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Username"].ToString();
            customerID = spc.GetCustomerIDByEmail(email);
        }

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text;
            string expiration = ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue;

            if (spc.AddCreditCard(customerID, cardNumber, expiration))
                lblResult.Text = "You successfully added a credit card.";
            else
                lblResult.Text = "Sorry, your card was not added. Try again later.";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }
    }
}