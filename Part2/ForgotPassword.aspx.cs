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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session.Add("Username", "");
            Session.Add("SecurityQuestion1", "");
            Session.Add("SecurityQuestion2", "");

            string email = txtEmailAddress.Text;

            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            if (email == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter your email";
                txtEmailAddress.Focus();
            }
            else
            {
                //if dropdown selection is Customer
                if (ddlLoginType.SelectedItem.Value == "0")
                {
                    objcommand.CommandType = CommandType.StoredProcedure;
                    objcommand.CommandText = "TP_GetCustomerByEmail";
                    objcommand.Parameters.AddWithValue("@email", email);

                    ds = db.GetDataSetUsingCmdObj(objcommand);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        lblError.Text = "";
                        txtEmailAddress.ReadOnly = true;
                        ddlLoginType.Enabled = false;
                        btnSubmit.Visible = false;
                        txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;

                        questions.Visible = true;
                        Session.Clear();
                        Session["Username"] = ds.Tables[0].Rows[0]["LoginID"].ToString();
                        Session["SecurityQuestion1"] = ds.Tables[0].Rows[0]["SecurityAnswer1"].ToString();
                        Session["SecurityQuestion2"] = ds.Tables[0].Rows[0]["SecurityAnswer2"].ToString();
                    }
                    else
                    {
                        lblError.Text = "We're sorry. We weren't able to identify you given the information provided.";
                        txtEmailAddress.Focus();
                    }
                }
                //if dropdown selection is Merchant
                if (ddlLoginType.SelectedItem.Value == "1")
                {
                    objcommand.CommandType = CommandType.StoredProcedure;
                    objcommand.CommandText = "TP_GetMerchantByEmail";
                    objcommand.Parameters.AddWithValue("@email", email);

                    ds = db.GetDataSetUsingCmdObj(objcommand);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        lblError.Text = "";
                        txtEmailAddress.ReadOnly = true;
                        ddlLoginType.Enabled = false;
                        btnSubmit.Visible = false;
                        txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;

                        questions.Visible = true;
                        Session.Clear();
                        Session["Username"] = ds.Tables[0].Rows[0]["LoginID"].ToString();
                        Session["SecurityQuestion1"] = ds.Tables[0].Rows[0]["SecurityAnswer1"].ToString();
                        Session["SecurityQuestion2"] = ds.Tables[0].Rows[0]["SecurityAnswer2"].ToString();
                    }
                    else
                    {
                        lblError.Text = "We're sorry. We weren't able to identify you given the information provided.";
                        txtEmailAddress.Focus();
                    }
                }
            }
        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            //if answers are equal to session answer
            if (txtSecurity1.Text == Session["SecurityQuestion1"].ToString() && txtSecurity2.Text == Session["SecurityQuestion2"].ToString())
            {
                lblError1.Text = "";
                passwordReset.Visible = true;
                txtSecurity1.ReadOnly = true;
                txtSecurity2.ReadOnly = true;
                questions.Visible = true;
                btnAnswer.Visible = false;
            }
            else
            {
                lblError1.Text = "Error. Please try again.";
            }
        }

        protected void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            string username = txtEmailAddress.Text;
            string userType = ddlLoginType.SelectedItem.Value;
            string password1 = txtNewPassword.Text;
            string password2 = txtReenterPassword.Text;

            DBConnect db = new DBConnect();
            if (password1 != "" && password2 != "")
            {
                if (password1 == password2)
                {
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_NewPWFromForgot";

                    objCommand.Parameters.AddWithValue("@LoginID", username);
                    objCommand.Parameters.AddWithValue("@AccountType", userType);
                    objCommand.Parameters.AddWithValue("@OldPassword", password1);
                    objCommand.Parameters.AddWithValue("@NewPassword", password2);

                    int result = objDB.DoUpdateUsingCmdObj(objCommand);

                    if (result == -1)
                        lblError2.Text = "Oops. There was an error updating your password.";
                    else
                    {
                        lblError2.Text = "Password successfully updated.";
                        Response.AddHeader("REFRESH", "5;URL=Login.aspx");
                        lblError2.Text += "<br>Redirecting to Login...";
                    }
                }
                else
                {
                    lblError2.Text = "Check that your new passwords match.";
                }
            }
            else
            {
                lblError2.Text = "Do not leave values blank";
            }
        }
    }
}