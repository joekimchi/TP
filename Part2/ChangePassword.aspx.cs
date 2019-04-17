using System;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace Part2
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string loginID;
        int accountType;
        protected void Page_Load(object sender, EventArgs e)
        {
            loginID = Session["Username"].ToString();
            accountType = int.Parse(Session["AccountType"].ToString());
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPW = txtOldPassword.Text;
            string newPW = txtNewPassword.Text;
            string newPW2 = txtConfirmPassword.Text;

            if (newPW == newPW2) {

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ChangePassword";

                objCommand.Parameters.AddWithValue("@AccountType", accountType);
                objCommand.Parameters.AddWithValue("@LoginID", loginID);
                objCommand.Parameters.AddWithValue("@OldPassword", oldPW);
                objCommand.Parameters.AddWithValue("@NewPassword", newPW);

                int result = objDB.DoUpdateUsingCmdObj(objCommand);

                if (result == -1)
                    lblResult.Text = "Oops. There was an error updating your password.";
                else
                    lblResult.Text = "Password successfully updated.";
            }
            else
            {
                lblNotMatched.Text = "Check that your new passwords match.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }
    }
}