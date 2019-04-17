using System;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Part2
{
    public partial class Home : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string loginID;
        string password;
        int accountType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loginID = Session["Username"].ToString();
                password = Session["Password"].ToString();
                accountType = int.Parse(Session["AccountType"].ToString());
            }

            if (accountType == 0)
            {
                Merchant.Visible = false;

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_CustomerPurchases";

                objCommand.Parameters.AddWithValue("@LoginID", loginID);
                gvCustomer.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvCustomer.DataBind();
            }
            else //accountType == "Merchant"
            {
                Customer.Visible = false;
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_MerchantSales";

                objCommand.Parameters.AddWithValue("@Email", loginID);
                gvMerchant.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvMerchant.DataBind();
            }
        }

        protected void btnRetrieveAPIKey_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";

            objCommand.Parameters.AddWithValue("@Email", loginID);
            objCommand.Parameters.AddWithValue("@Password", password);

            string apiKey = objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows[0][0].ToString();
            lblAPIKey.Text = "Your API Key is " + apiKey + ".";
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.apsx", false);
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
    }
}