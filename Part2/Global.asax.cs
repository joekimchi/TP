using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Utilities;

namespace Part2
{
    public class Global : System.Web.HttpApplication
    {
        SPCaller spc = new SPCaller();
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
                List<Cart> cart = (List<Cart>)Session["ShoppingCart"];
                foreach(Cart c in cart)
                {
                    spc.AddToCart(c.User, c.Title, c.price)
                }
            }

            
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}