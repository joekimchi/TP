using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Utilities;
using System.Data.SqlClient;

namespace Utilities
{
    public class Register
    {
        public bool NewCustomer(CustomerInformation newCustomer)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_NewCustomer";
            objCommand.Parameters.AddWithValue("@loginID", newCustomer.LoginID);
            objCommand.Parameters.AddWithValue("@password", newCustomer.Password);
            objCommand.Parameters.AddWithValue("@name", newCustomer.Name);
            objCommand.Parameters.AddWithValue("@address", newCustomer.Address);
            objCommand.Parameters.AddWithValue("@city", newCustomer.City);
            objCommand.Parameters.AddWithValue("@state", newCustomer.State);
            objCommand.Parameters.AddWithValue("@zipcode", newCustomer.ZipCode);

            //integer to determine if value was added into DB or not
            int result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (!(result <= 0)) //if a new row was successsfully added
            {
                return false;
            }
            else               //else the row was not added successfully
            {
                return true;

            }
        }

        public bool ValidCustomerLogin(string email, string password)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ValidCustomerLogin";
            objCommand.Parameters.AddWithValue("@loginID", email);
            objCommand.Parameters.AddWithValue("@password", password);
            DBConnect objDB = new DBConnect();
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            bool result = true;

            //if user is correct with password
            if ((myDS.Tables[0].Rows.Count <= 1) && (myDS.Tables[0].Rows[0]["Password"].ToString() == password))
            {
                return result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool ValidMerchantLogin(string email, string password)
        {
            DataSet myDS = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ValidMerchantLogin";
            objCommand.Parameters.AddWithValue("@loginID", email);
            objCommand.Parameters.AddWithValue("@password", password);
            DBConnect objDB = new DBConnect();
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            bool result = true;

            //if the values are found in the DB return true
            if ((myDS.Tables[0].Rows.Count <= 1) && (myDS.Tables[0].Rows[0]["password"].ToString() == password))
            {
                result = true;
            }

            //the user does not exist in the DB
            else
            {
                result = false;
            }
            return result;
        }
    }
}
