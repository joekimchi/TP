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
            if (!IsPostBack)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_CustomerSalesReport";
                gvCustomer.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvCustomer.DataBind();

                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_InventoryReport";
                gvInventory.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvInventory.DataBind();

                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_SalesReport";
                gvSales.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvSales.DataBind();
            }
        }
    }
}