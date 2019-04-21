using System;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Part2
{
    public partial class Home : System.Web.UI.Page
    {
        DataSet myDS;
        SPCaller spc = new SPCaller();

        string loginID;
        string password;
        int accountType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                loginID = Session["Username"].ToString();
                password = Session["Password"].ToString();
                accountType = int.Parse(Session["AccountType"].ToString());

                if (accountType == 0)
                {
                    Merchant.Visible = false;

                    gvCustomer.DataSource = spc.GetCustomerPurchases(loginID);
                    gvCustomer.DataBind();
                }
                else //accountType == "Merchant"
                {
                    Customer.Visible = false;
                    gvMerchant.DataSource = spc.GetMerchantSales(loginID);
                    gvMerchant.DataBind();
                }
            }
        }

        protected void btnRetrieveAPIKey_Click(object sender, EventArgs e)
        {
            lblAPIKey.Text = "";

            string apiKey = spc.RetrieveAPIKey(loginID, password);
            lblAPIKey.Text = "Your API Key is " + apiKey + ".";
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", false);
        }

        protected void btnUpdateAccountInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAccountInformation.aspx", false);
        }

        protected void btnChangeCreditInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateCreditCardInformation.aspx", false);
        }

        protected void btnManagementReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagementReport.aspx", false);
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnAddCC_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCreditCard.aspx", false);
        }
    }
}