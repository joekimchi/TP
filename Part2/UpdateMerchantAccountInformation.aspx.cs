using System;
using Utilities;
using System.Data;

namespace Part2
{
    public partial class UpdateMerchantAccountInformation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string loginID;
        int accountType;
        SPCaller spc = new SPCaller();
        Validation val = new Validation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else
            {
                loginID = Session["Username"].ToString();
                accountType = int.Parse(Session["AccountType"].ToString());

                if (!IsPostBack)
                {
                    DataSet myDS = spc.GetAccountInfoByTypeAndLogin(accountType, loginID);

                    txtName.Text = myDS.Tables[0].Rows[0][0].ToString();
                    txtPhoneNumber.Text = myDS.Tables[0].Rows[0][1].ToString();
                    txtAddress.Text = myDS.Tables[0].Rows[0][2].ToString();
                    txtCity.Text = myDS.Tables[0].Rows[0][3].ToString();
                    ddlState.SelectedValue = myDS.Tables[0].Rows[0][4].ToString();
                    txtZipCode.Text = myDS.Tables[0].Rows[0][5].ToString();
                }
            }
        }

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            if (!val.isBlank(txtName.Text) && val.isValidNumber(txtPhoneNumber.Text) && !val.isBlank(txtAddress.Text) &&
                   val.hasLettersOnly(txtCity.Text) && val.isValidNumber(txtZipCode.Text))
            {
                string name = txtName.Text;
                string phone = txtPhoneNumber.Text;
                string address = txtAddress.Text;
                string city = txtCity.Text;
                string state = ddlState.SelectedValue;
                int zipCode = int.Parse(txtZipCode.Text);

                bool result = spc.UpdateAccountInfo(accountType, loginID, name, phone, address, city, state, zipCode);

                if (result)
                    lblResult.Text = "Account information successfully updated.";
                else
                    lblResult.Text = "Something went wrong. Your account information was not updated.";
            }
            lblResult.Text = "Invalid inputs: ";
            if (val.isBlank(txtName.Text))
                lblResult.Text += "<br>You entered an invalid name.";
            if (!val.isValidNumber(txtPhoneNumber.Text))
                lblResult.Text += "<br>You entered an invalid phone number.";
            if (!val.isBlank(txtAddress.Text))
                lblResult.Text += "<br>You entered an invalid address.";
            if (!val.hasLettersOnly(txtCity.Text))
                lblResult.Text += "<br>You entered an invalid city.";
            if (!val.isValidNumber(txtZipCode.Text))
                lblResult.Text += "<br>You entered an invalid zipcode. Numbers only.";
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePasswordMerch.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchantHome.aspx", false);
        }
    }
}