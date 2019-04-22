using System;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Part2
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        SPCaller spc = new SPCaller();

        string loginID;
        string password;
        int accountType;

        protected void Page_Load(object sender, EventArgs e)
        {
            loginID = Session["Username"].ToString();
            password = Session["Password"].ToString();
            accountType = int.Parse(Session["AccountType"].ToString());

            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                gvCustomer.DataSource = spc.GetCustomerPurchases(loginID);
                gvCustomer.DataBind();
            }
        }

        protected void btnManagementReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagementReport.aspx", false);
        }

    }
}