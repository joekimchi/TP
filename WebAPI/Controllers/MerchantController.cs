using System;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/service/Merchants")]
    public class MerchantController : Controller
    {
        //Get all departments in database and return as a list of department objects
        [HttpGet]
        public List<Department> GetDepartments()
        {
            List<Department> deptList = new List<Department>();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetDepartments";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            int count = myDS.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Department dept = new Department();
                dept.ID = int.Parse(objDB.GetField("ID", i).ToString());
                dept.Name = objDB.GetField("Name", i).ToString();
                deptList.Add(dept);
            }
            return deptList;
        }

        //Get all products in a certain department and return as a list of product objects
        [HttpGet("{DepartmentNumber}")]
        public List<Product> GetProductCatalog(String DepartmentNumber)
        {
            List<Product> prodList = new List<Product>();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProductCatalog";

            objCommand.Parameters.AddWithValue("@DepartmentID", DepartmentNumber);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            int count = myDS.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Product prod = new Product();
                prod.ID = int.Parse(objDB.GetField("ID", i).ToString());
                prod.Description = objDB.GetField("Description", i).ToString();
                prod.Price = float.Parse(objDB.GetField("Price", i).ToString());
                prod.ImageURL = objDB.GetField("ImageURL", i).ToString();

                prodList.Add(prod);
            }
            return prodList;
        }

        //Register a site to work with Amazon to sell their products
        [HttpPost("Reg/{SiteID}/{Description}/{APIKey}/{Email}/{Contact}")]
        public bool RegisterSite(String SiteID, String Description, String APIKey, String Email, String Contact)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RegisterSite";

            objCommand.Parameters.AddWithValue("@SiteID", SiteID);
            objCommand.Parameters.AddWithValue("@Description", Description);
            objCommand.Parameters.AddWithValue("@APIKey", APIKey);
            objCommand.Parameters.AddWithValue("@Email", Email);
            objCommand.Parameters.AddWithValue("@Contact", Contact);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);
            if (result != -1)
                return true;
            return false;
        }
        
        //Record a purchase from a customer with a site
        [HttpPost("Rec/{ProductID}/{Quantity}/{SellerSiteID}/{APIKey}")]
        public bool RecordPurchase(String ProductID, int Quantity, String SellerSiteID, String APIKey, 
                                   [FromBody]CustomerInformation CustInfo)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SearchForAPIKey";
            objCommand.Parameters.AddWithValue("@ID", SellerSiteID);
            objCommand.Parameters.AddWithValue("@APIKey", APIKey);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                try
                {
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetProductPrice";
                    objCommand.Parameters.AddWithValue("@ProductID", ProductID);
                    myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                    float prodPrice = float.Parse(myDS.Tables[0].Rows[0][0].ToString());

                    float totalDollarSales = prodPrice * Quantity;

                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_RecordPurchase";
                    objCommand.Parameters.AddWithValue("@ProductID", ProductID);
                    objCommand.Parameters.AddWithValue("@Quantity", Quantity);
                    objCommand.Parameters.AddWithValue("@SellerSiteID", SellerSiteID);
                    objCommand.Parameters.AddWithValue("@CustomerID", CustInfo.ID);
                    objCommand.Parameters.AddWithValue("@TotalDollarSales", totalDollarSales);

                    objDB.DoUpdateUsingCmdObj(objCommand);
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}