using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;

namespace Part2
{
    public partial class RegisterMerchant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/Reg/";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string siteID = txtSiteID.Text;
            string siteName = txtSiteName.Text;
            String siteURL = txtSiteURL.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string apikey = api.APIKeyGen(5);
            string address = txtAddress.Text;
            string city = txtCity.Text;
            


            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindID";
            objCommand.Parameters.AddWithValue("@SiteID", siteID);
            if (objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows.Count > 0)
                lblDuplicateID.Text = "Sorry that Site ID already exists. Try another one.";

            else
            {
                lblDuplicateID.Text = "";
                bool result = api.RegisterSite(url, siteID, name, apikey, email, phone, siteURL);
                if (result == true)
                    lblResult.Text = "Merchant Account successfully added.<br>Your APIKey is: " + apikey;
                else
                    lblResult.Text = "Something went wrong. Merchant Account was not added.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnRegisterNewCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx", false);
        }
    }
}