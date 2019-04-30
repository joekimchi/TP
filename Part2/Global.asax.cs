using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Utilities;

namespace Part2
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["ShoppingCart"] != null)
            {
                ArrayList cart = (ArrayList)Session["ShoppingCart"];

                BinaryFormatter serializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream();
                serializer.Serialize(memStream, cart);

                byte[] cartBytes = memStream.ToArray();

                SPCaller spc = new SPCaller();
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_StoreCart";

                int custID = spc.GetCustomerIDByEmail(Session["Username"].ToString());

                objCommand.Parameters.AddWithValue("@CustomerID", custID);
                objCommand.Parameters.AddWithValue("@Cart", cartBytes);
                objDB.DoUpdateUsingCmdObj(objCommand);
            }

            if (Session["WishList"] != null)
            {
                ArrayList wishList = (ArrayList)Session["WishList"];

                BinaryFormatter serializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream();
                serializer.Serialize(memStream, wishList);

                byte[] wlBytes = memStream.ToArray();

                SPCaller spc = new SPCaller();
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_StoreWishList";

                int custID = spc.GetCustomerIDByEmail(Session["Username"].ToString());

                objCommand.Parameters.AddWithValue("@CustomerID", custID);
                objCommand.Parameters.AddWithValue("@WishList", wlBytes);
                objDB.DoUpdateUsingCmdObj(objCommand);
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}