using System;
using System.Data;
using System.Data.SqlClient;

namespace Utilities
{
    public class SPCaller
    {
        public int GetCustomerIDByEmail(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomerByEmail";

            objCommand.Parameters.AddWithValue("@email", email);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
                return int.Parse(myDS.Tables[0].Rows[0][0].ToString());
            return -1;
        }

        public DataSet GetCCByCustomerID(int customerID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCCByCustomerID";

            objCommand.Parameters.AddWithValue("@CustomerID", customerID);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetCCInfoByCardID(int cardID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCCInfoByCardID";

            objCommand.Parameters.AddWithValue("@CardID", cardID);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public bool AddCreditCard(int customerID, string cardNumber, string expiration)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddNewCC";

            objCommand.Parameters.AddWithValue("@CustomerID", customerID);
            objCommand.Parameters.AddWithValue("@CardNumber", cardNumber);
            objCommand.Parameters.AddWithValue("@Expiration", expiration);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result != -1)
                return true;
            return false;
        }

        public bool UpdateCC(int cardID, string cardNumber, string expiration)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateCC";

            objCommand.Parameters.AddWithValue("@CustomerID", cardID);
            objCommand.Parameters.AddWithValue("@CardNumber", cardNumber);
            objCommand.Parameters.AddWithValue("@Expiration", expiration);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result != -1)
                return true;
            return false;
        }
    }
}
