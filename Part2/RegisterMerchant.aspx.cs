using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace Part2
{
    public partial class RegisterMerchant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        Validation v = new Validation();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/Reg/";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string siteID = txtSiteID.Text;
            string siteName = txtSiteName.Text;
            String siteURL = txtSiteURL.Text;
            string apikey = v.APIKeyGen(5);

            ContactInformation ci = new ContactInformation();
            ci.Name = txtName.Text;
            ci.Address = txtAddress.Text;
            ci.City = txtCity.Text;
            ci.State = ddlState.SelectedValue;
            ci.ZipCode = int.Parse(txtZipCode.Text);
            ci.Email = txtEmail.Text;
            ci.Password = txtPassword.Text;
            ci.Phone = txtPhone.Text;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindID";
            objCommand.Parameters.AddWithValue("@SiteID", siteID);
            if (objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows.Count > 0)
                lblDuplicateID.Text = "Sorry that Site ID already exists. Try another one.";

            else
            {
                lblDuplicateID.Text = "";

                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonci = js.Serialize(ci);

                WebRequest request = WebRequest.Create(url + siteID + "/" + siteName + "/" + siteURL + "/" + apikey);
                request.Method = "POST";
                request.ContentLength = jsonci.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonci);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                bool result = bool.Parse(reader.ReadToEnd());
                reader.Close();
                response.Close();

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