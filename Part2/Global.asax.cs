using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                List<CartItem> cart = (List<CartItem>)Session["ShoppingCart"];

                foreach(CartItem ci in cart)
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;

                    objCommand.CommandText = "TP_AddToCart";

                    objCommand.Parameters.AddWithValue("@CustomerID", ci.User);
                    objCommand.Parameters.AddWithValue("@Title", ci.Title);
                    objCommand.Parameters.AddWithValue("@Description", ci.Description);
                    objCommand.Parameters.AddWithValue("@Price", ci.Price);
                    objCommand.Parameters.AddWithValue("@Quantity", ci.Quantity);
                    objCommand.Parameters.AddWithValue("@ImageURL", ci.Image);

                    objDB.DoUpdateUsingCmdObj(objCommand);
                }
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}