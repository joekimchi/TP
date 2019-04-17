using System;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class UpdateAccountInformation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string loginID;
        int accountType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loginID = Session["Username"].ToString();
                accountType = int.Parse(Session["AccountType"].ToString());
            }
        }

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhoneNumber.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            int zipCode = int.Parse(txtZipCode.Text);

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateAccount";

            objCommand.Parameters.AddWithValue("@AccountType", accountType);
            objCommand.Parameters.AddWithValue("@Email", loginID);
            objCommand.Parameters.AddWithValue("@Name", name);
            objCommand.Parameters.AddWithValue("@Phone", phone);
            objCommand.Parameters.AddWithValue("@Address", address);
            objCommand.Parameters.AddWithValue("@City", city);
            objCommand.Parameters.AddWithValue("@State", state);
            objCommand.Parameters.AddWithValue("@ZipCode", zipCode);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);
            if (result != -1)
                lblResult.Text = "Account information successfully updated.";
            else
                lblResult.Text = "Something went wrong. Your account information was not updated.";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }
    }
}