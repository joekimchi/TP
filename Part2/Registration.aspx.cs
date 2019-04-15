using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class Registration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcommand = new SqlCommand();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegisterforMerchantAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterMerchant.aspx", false);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_GetLoginID";

            objcommand.Parameters.AddWithValue("@LoginID", txtEmail.Text);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcommand);

            if (ds.Tables[0].Rows.Count == 0)
            {
                CustomerInformation newCustomer = new CustomerInformation();
                newCustomer.LoginID = txtEmail.Text;
                newCustomer.Name = txtName.Text;
                newCustomer.Password = txtPassword.Text;
                newCustomer.PhoneNumber = txtPhoneNumber.Text;
                newCustomer.Address = txtAddress.Text;
                newCustomer.City = txtCity.Text;
                newCustomer.State = ddlState.Text;
                newCustomer.ZipCode = txtZipcode.Text;
                newCustomer.SecurityQuestion1 = ddlSecurityQuestion1.Text;
                newCustomer.SecurityAnswer1 = txtSecurityAnswer1.Text;
                newCustomer.SecurityQuestion2 = ddlSecurityQuestion2.Text;
                newCustomer.SecurityAnswer2 = txtSecurityAnswer2.Text;

                if (newCustomer != null)
                {
                    try
                    {
                        objcommand.CommandType = CommandType.StoredProcedure;
                        objcommand.CommandText = "TP_NewCustomer";

                        objcommand.Parameters.AddWithValue("@LoginID", newCustomer.LoginID);
                        objcommand.Parameters.AddWithValue("@Name", newCustomer.Name);
                        objcommand.Parameters.AddWithValue("@Password", newCustomer.Password);
                        objcommand.Parameters.AddWithValue("@PhoneNumber", newCustomer.PhoneNumber);
                        objcommand.Parameters.AddWithValue("@Address", newCustomer.Address);
                        objcommand.Parameters.AddWithValue("@City", newCustomer.City);
                        objcommand.Parameters.AddWithValue("@State", newCustomer.State);
                        objcommand.Parameters.AddWithValue("@Zipcode", newCustomer.ZipCode);
                        objcommand.Parameters.AddWithValue("@SecurityQuestion1", newCustomer.SecurityQuestion1);
                        objcommand.Parameters.AddWithValue("@SecurityAnswer1", newCustomer.SecurityAnswer1);
                        objcommand.Parameters.AddWithValue("@SecurityQuestion2", newCustomer.SecurityQuestion2);
                        objcommand.Parameters.AddWithValue("SecurityAnswer2", newCustomer.SecurityAnswer2);

                        int result = objDB.DoUpdateUsingCmdObj(objcommand);

                        if (result != -1)
                        {
                            lblError.Text = "Successfully created an account";
                        }
                        else
                        {
                            lblError.Text = "An error occurred. Please try again!";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
                lblError.Text = "Username is taken";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}