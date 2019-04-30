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
        Validation val = new Validation();

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
            if (!val.isBlank(txtEmail.Text) && !val.isBlank(txtName.Text) && 
                !val.isBlank(txtPassword.Text) && val.isValidNumber(txtPhoneNumber.Text) && !val.isBlank(txtAddress.Text) &&
                val.hasLettersOnly(txtCity.Text) && val.isValidNumber(txtZipcode.Text) && !val.isBlank(txtSecurityAnswer1.Text) &&
                !val.isBlank(txtSecurityAnswer2.Text))
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
                    customer.SecurityAnswer1 = txtSecurityAnswer1.Text;
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
                            objcommand.Parameters.AddWithValue("@SecurityAnswer1", customer.SecurityAnswer1);
                            objcommand.Parameters.AddWithValue("@SecurityAnswer2", customer.SecurityAnswer2);

                            int result = objDB.DoUpdateUsingCmdObj(objcommand);

                            if (result == -1)
                            {
                                lblError.Text = "An error occurred. Please try again.";
                            }
                            else
                            {
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

                                lblError.Text = "Account Successfully Created";
                                Response.AddHeader("REFRESH", "5;URL=Login.aspx");
                                lblError.Text += "<br>Redirecting to Login...";
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
            lblError.Text = "Invalid inputs: ";
            if (val.isBlank(txtEmail.Text))
                lblError.Text += "<br>You entered an invalid email.";
            if (val.isBlank(txtName.Text))
                lblError.Text += "<br>You entered an invalid name.";
            if (val.isBlank(txtPassword.Text))
                lblError.Text += "<br>Please enter a password";
            if (!val.isValidNumber(txtPhoneNumber.Text))
                lblError.Text += "<br>You entered an invalid phone number.";
            if (!val.isBlank(txtAddress.Text))
                lblError.Text += "<br>You entered an invalid address.";
            if (!val.hasLettersOnly(txtCity.Text))
                lblError.Text += "<br>You entered an invalid city.";
            if (!val.isValidNumber(txtZipcode.Text))
                lblError.Text += "<br>You entered an invalid zipcode. Numbers only.";
            if (val.isBlank(txtSecurityAnswer1.Text))
                lblError.Text += "<br>Please enter a security answer for question 1.";
            if (val.isBlank(txtSecurityAnswer2.Text))
                lblError.Text += "<br>Please enter a security answer for question 2.";
        }
    }
}