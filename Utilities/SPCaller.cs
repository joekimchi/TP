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

            objCommand.Parameters.AddWithValue("@CardID", cardID);
            objCommand.Parameters.AddWithValue("@CardNumber", cardNumber);
            objCommand.Parameters.AddWithValue("@Expiration", expiration);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result != -1)
                return true;
            return false;
        }

        public DataSet GetCustomerPurchases(string loginID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CustomerPurchases";

            objCommand.Parameters.AddWithValue("@LoginID", loginID);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetMerchantSales(string loginID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_MerchantSales";

            objCommand.Parameters.AddWithValue("@Email", loginID);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public string RetrieveAPIKey(string loginID, string password)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";

            objCommand.Parameters.AddWithValue("@Email", loginID);
            objCommand.Parameters.AddWithValue("@Password", password);

            return objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows[0][0].ToString();
        }

        public bool ChangePassword(int accountType, string loginID, string oldPassword, 
        string newPassword)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ChangePassword";

            objCommand.Parameters.AddWithValue("@AccountType", accountType);
            objCommand.Parameters.AddWithValue("@LoginID", loginID);
            objCommand.Parameters.AddWithValue("@OldPassword", oldPassword);
            objCommand.Parameters.AddWithValue("@NewPassword", newPassword);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result != -1)
                return true;
            return false;
        }

        public DataSet GetCustomerByEmail(string email)
        {
            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_GetCustomerByEmail";
            objcommand.Parameters.AddWithValue("@email", email);

            return db.GetDataSetUsingCmdObj(objcommand);
        }

        public DataSet GetMerchantByEmail(string email)
        {
            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();

            SqlCommand objcommand = new SqlCommand();

            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_GetMerchantByEmail";
            objcommand.Parameters.AddWithValue("@email", email);

            return db.GetDataSetUsingCmdObj(objcommand);
        }

        public bool NewPasswordFromForgot(string username, string userType, string password, string password2)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_NewPWFromForgot";

            objCommand.Parameters.AddWithValue("@LoginID", username);
            objCommand.Parameters.AddWithValue("@AccountType", userType);
            objCommand.Parameters.AddWithValue("@OldPassword", password);
            objCommand.Parameters.AddWithValue("@NewPassword", password2);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);
            if (result != -1)
                return true;
            return false;
        }
    }
}
