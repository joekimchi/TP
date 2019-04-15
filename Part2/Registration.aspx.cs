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

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegisterforMerchantAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterMerchant.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_GetLoginID";
            objcommand.Parameters.AddWithValue("@LoginID", txtEmail.Text);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objcommand);

            //if username is not already taken
            if (ds.Tables[0].Rows.Count == 0)
            {
                Customer customer = new Customer();
                customer.Email = txtEmail.Text;
                customer.Name = txtName.Text;
                customer.Password = txtPassword.Text;
                customer.Phone = txtPhoneNumber.Text;
                customer.Address = txtAddress.Text;
                customer.City = txtCity.Text;
                customer.State = ddlState.Text;
                customer.ZipCode = Convert.ToInt32(txtZipcode.Text);
                customer.SecurityQuestion1 = ddlSecurityQuestion1.Text;
                customer.SecurityAnswer1 = txtSecurityAnswer1.Text;
                customer.SecurityQuestion2 = ddlSecurityQuestion2.Text;
                customer.SecurityAnswer2 = txtSecurityAnswer2.Text;

                if (customer != null)
                {
                    try
                    {
                        objcommand.Parameters.Clear();
                        objcommand.CommandType = CommandType.StoredProcedure;
                        objcommand.CommandText = "TP_NewCustomer";

                        objcommand.Parameters.AddWithValue("@LoginID", customer.Email);
                        objcommand.Parameters.AddWithValue("@Name", customer.Name);
                        objcommand.Parameters.AddWithValue("@Password", customer.Password);
                        objcommand.Parameters.AddWithValue("@PhoneNumber", customer.Phone);
                        objcommand.Parameters.AddWithValue("@Address", customer.Address);
                        objcommand.Parameters.AddWithValue("@City", customer.City);
                        objcommand.Parameters.AddWithValue("@State", customer.State);
                        objcommand.Parameters.AddWithValue("@Zipcode", customer.ZipCode);
                        objcommand.Parameters.AddWithValue("@SecurityQuestion1", customer.SecurityQuestion1);
                        objcommand.Parameters.AddWithValue("@SecurityAnswer1", customer.SecurityAnswer1);
                        objcommand.Parameters.AddWithValue("@SecurityQuestion2", customer.SecurityQuestion2);
                        objcommand.Parameters.AddWithValue("@SecurityAnswer2", customer.SecurityAnswer2);

                        int result = objDB.DoUpdateUsingCmdObj(objcommand);

                        if (result == -1)
                        {
                            lblError.Text = "An error occurred. Please try again.";
                        }
                        else
                        {
                            lblError.Text = "Account Successfully Created";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                lblError.Text = "Username is taken. Please try again.";
            }
        }
    }
}