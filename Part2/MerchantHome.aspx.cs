using System;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace AmazonTermProject
{
    public partial class MerchantHome : System.Web.UI.Page
    {
        SPCaller spc = new SPCaller();

        string loginID;
        string password;
        int accountType;

        protected void Page_Load(object sender, EventArgs e)
        {
            loginID = Session["Username"].ToString();
            password = Session["Password"].ToString();
            accountType = int.Parse(Session["AccountType"].ToString());

            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                gvMerchant.DataSource = spc.GetMerchantSales(loginID);
                gvMerchant.DataBind();
            }
        }

        protected void btnRetrieveAPIKey_Click(object sender, EventArgs e)
        {
            lblAPIKey.Text = "";

            string apiKey = spc.RetrieveAPIKey(loginID, password);
            lblAPIKey.Text = "Your API Key is " + apiKey + ".";
        }

        protected void btnManagementReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagementReport.aspx", false);
        }
    }
}