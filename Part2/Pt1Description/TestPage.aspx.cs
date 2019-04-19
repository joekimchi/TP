using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Web.Script.Serialization;  // needed for JSON serializers

namespace APIClient
{
    public partial class TestPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcommand = new SqlCommand();
        DataSet ds = new DataSet();
        Validation val = new Validation();
        APICalls api = new APICalls();

        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/";
        Customer custInfo = new Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                custInfo.Name = "Du Ha";
                custInfo.ID = 123;
                ddlCustomer.Items.Add(custInfo.Name);
            }
        }

        //Get All Departments
        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            gvGetAllDepartments.DataSource = api.GetDepartments(url);
            gvGetAllDepartments.DataBind();
        }

        //Get Product by Department ID
        protected void btnGetProductCatalog_Click(object sender, EventArgs e)
        {
            if (val.isValidNumber(txtDepartmentNumber.Text))
            {
                lblInputDepartmentError.Text = "";

                string deptID = txtDepartmentNumber.Text;

                gvProductCatalog.DataSource = api.GetProductCatalog(url, deptID);
                gvProductCatalog.DataBind();
            }
            else
                lblInputDepartmentError.Text = "Please enter valid number for Department Number";
        }

        //For Register Site 
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";

            if (val.isValidNumber(txtSiteID.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text) &&
                !string.IsNullOrWhiteSpace(txtAPIKey.Text) && val.hasEmailTraits(txtEmailAddress.Text) && !string.IsNullOrWhiteSpace(txtEmailAddress.Text) &&
                !string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                Site site = new Site();

                site.SiteID = txtSiteID.Text;
                site.Description = txtDescription.Text;
                site.APIKey = txtAPIKey.Text;
                site.Email = txtEmailAddress.Text;
                site.PhoneNumber = txtPhoneNumber.Text;
                site.PhoneNumber = txtPhoneNumber.Text;

                try
                {
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server
                    WebRequest request = WebRequest.Create(url + "Reg/" + site.SiteID + "/" + site.Description + "/" + site.APIKey + "/" + site.Email + "/" + site.PhoneNumber);
                    bool data = api.RegisterSite(url, site.SiteID, site.Description, site.APIKey, site.Email, site.PhoneNumber);

                    if (data == true)
                    {
                        lblResult.Text = "True";
                        txtSiteID.Text = "";
                        txtDescription.Text = "";
                        txtAPIKey.Text = "";
                        txtEmailAddress.Text = "";
                        txtPhoneNumber.Text = "";
                    }
                    else
                        lblResult.Text = "False";
                }
                catch (Exception ex)
                {
                    lblResult.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                if (!val.isValidNumber(txtSiteID.Text) || string.IsNullOrWhiteSpace(txtSiteID.Text))
                    lblResult.Text += "<br>You entered an invalid Site ID. Numbers only.";
                if (!val.hasLettersorWhiteSpaceOnly(txtDescription.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                    lblResult.Text += "<br>You entered an invalid Description.";
                if (string.IsNullOrWhiteSpace(txtAPIKey.Text))
                    lblResult.Text += "<br>You entered an invalid APIKey. It should include numbers or letters only.";
                if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
                    lblResult.Text += "<br>You entered an invalid Email Address.";
                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                    lblResult.Text += "<br>You entered an invalid Phone Number. 10-digit numbers only.";
            }
        }

        //For Record Purchase
        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            lblResult1.Text = "";

            if (val.isValidNumber(txtProductID.Text) && val.isValidNumber(txtQuantity.Text) &&
                val.isValidNumber(txtSellerSiteID.Text) && !string.IsNullOrWhiteSpace(txtInputAPIKey.Text))
            {
                try
                {
                    WebRequest request = WebRequest.Create(url + "Rec/" + txtProductID.Text + "/" + txtQuantity.Text + "/" +
                                         txtSellerSiteID.Text + "/" + txtInputAPIKey.Text + "/");

                    bool data = api.RecordPurchase(url, txtProductID.Text, int.Parse(txtQuantity.Text), txtSellerSiteID.Text, txtInputAPIKey.Text, custInfo);

                    if (data == true)
                    {
                        lblResult1.Text = "True";
                        txtProductID.Text = "";
                        txtQuantity.Text = "";
                        txtSellerSiteID.Text = "";
                        txtInputAPIKey.Text = "";
                    }
                    else
                        lblResult1.Text = "False";
                }
                catch (Exception ex)
                {
                    lblResult1.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                if (!val.isValidNumber(txtProductID.Text))
                    lblResult1.Text += "<br>You entered an invalid Product ID. Numbers only.";
                if (!val.isValidNumber(txtQuantity.Text))
                    lblResult1.Text += "<br>You entered an invalid Quantity. Numbers only.";
                if (!val.isValidNumber(txtSellerSiteID.Text))
                    lblResult1.Text += "<br>You entered an invalid Seller ID. Numbers only.";
                if (string.IsNullOrWhiteSpace(txtInputAPIKey.Text))
                    lblResult.Text += "<br>You entered an invalid APIKey. It should include numbers or letters only.";
            }
        }

        protected void btnMerchant_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchantStoreDescription.aspx", false);
        }
    }
}