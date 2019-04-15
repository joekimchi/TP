using System;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Part2
{
    public partial class Home : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRetrieveAPIKey_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";

            objCommand.Parameters.AddWithValue("@SiteID", 1);
            string apiKey = objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows[0][0].ToString();
            lblAPIKey.Text = apiKey;
        }
    }
}