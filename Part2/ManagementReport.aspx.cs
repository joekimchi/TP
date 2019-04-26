using System;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class ManagementReport : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_CustomerSalesReport";
                    gvCustomer.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                    gvCustomer.DataBind();

                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_SalesReport";
                    gvSales.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                    gvSales.DataBind();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchantHome.aspx", false);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            int i;
            if (int.TryParse(txtQuantity.Text, out i))
            {
                int quantity = int.Parse(txtQuantity.Text);

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_InventoryReport";
                objCommand.Parameters.AddWithValue("@Quantity", quantity);

                gvInventory.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvInventory.DataBind();
            }
            else
            {
                lblError.Text = "You did not enter a valid integer in the textbox.";
            }
        }
    }
}