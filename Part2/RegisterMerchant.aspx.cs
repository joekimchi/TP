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
        Validation val = new Validation();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/Reg/";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!val.isBlank(txtEmail.Text) && !val.isBlank(txtName.Text) &&
                !val.isBlank(txtPassword.Text) && !val.isBlank(txtAddress.Text) &&
                val.hasLettersOnly(txtCity.Text) && !val.isBlank(txtSecurityAnswer1.Text) &&
                !val.isBlank(txtSecurityAnswer2.Text))
            {
                string siteID = txtSiteID.Text;
                string siteName = txtSiteName.Text;
                String siteURL = txtSiteURL.Text;
                string apikey = val.APIKeyGen(5);

                ContactInformation ci = new ContactInformation();
                ci.Name = txtName.Text;
                ci.Address = txtAddress.Text;
                ci.City = txtCity.Text;
                ci.State = ddlState.SelectedValue;
                ci.ZipCode = int.Parse(txtZipCode.Text);
                ci.Email = txtEmail.Text;
                ci.Password = txtPassword.Text;
                ci.Phone = txtPhone.Text;
                ci.SecurityAnswer1 = txtSecurityAnswer1.Text;
                ci.SecurityAnswer2 = txtSecurityAnswer2.Text;

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
                    {
                        lblResult.Text = "Merchant Account successfully added.<br>Your APIKey is: " + apikey;

                        if (chkbxRememberMe.Checked == true)
                        {
                            Response.Cookies["Username"].Value = txtEmail.Text;
                            Response.Cookies["Password"].Value = txtPassword.Text;
                            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                    else
                        lblResult.Text = "Something went wrong. Merchant Account was not added.";
                }
                lblError.Text = "Invalid inputs: ";
                if (val.isBlank(txtEmail.Text))
                    lblError.Text += "<br>You entered an invalid email.";
                if (val.isBlank(txtName.Text))
                    lblError.Text += "<br>You entered an invalid name.";
                if (val.isBlank(txtPassword.Text))
                    lblError.Text += "<br>Please enter a password";
                if (!val.isBlank(txtAddress.Text))
                    lblError.Text += "<br>You entered an invalid address.";
                if (!val.hasLettersOnly(txtCity.Text))
                    lblError.Text += "<br>You entered an invalid city.";
                if (val.isBlank(txtSecurityAnswer1.Text))
                    lblError.Text += "<br>Please enter a security answer for question 1.";
                if (val.isBlank(txtSecurityAnswer2.Text))
                    lblError.Text += "<br>Please enter a security answer for question 2.";
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