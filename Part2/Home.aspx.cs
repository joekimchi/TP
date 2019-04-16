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
                loginID = "";
                password = "";
                accountType = "";
            }

            if (accountType == 0)
            {
                Merchant.Visible = false;
            }
            else //accountType == "Merchant"
            {
                Customer.Visible = false;
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
            Response.Redirect("ChangePassword.apsx?LoginID=" + loginID + "&AccountType=" + accountType, false);
        }
    }
}