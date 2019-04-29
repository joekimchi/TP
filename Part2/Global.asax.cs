using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

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
            //DBConnect objDB = new DBConnect();
            //SqlCommand objCommand = new SqlCommand();
            //SPCaller spc = new SPCaller();

            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_GetCart";

            //objCommand.Parameters.AddWithValue("@CustomerID", spc.GetCustomerIDByEmail(Session["LoginID"].ToString()));

            //if (objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows.Count > 0)
            //{
            //    byte[] cartBytes = (byte[])objDB.GetField("Cart", 0);
            //    BinaryFormatter deserializer = new BinaryFormatter();
            //    MemoryStream memStream = new MemoryStream(cartBytes);

            //    ArrayList cart = (ArrayList)deserializer.Deserialize(memStream);
            //    Session["ShoppingCart"] = cart;
            //}
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

                objCommand.Parameters.AddWithValue("@CustomerID", spc.GetCustomerIDByEmail(Session["LoginID"].ToString()));
                objCommand.Parameters.AddWithValue("@Cart", cartBytes);
                objDB.DoUpdateUsingCmdObj(objCommand);
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}