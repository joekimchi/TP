using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;

namespace Part2
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cart cart = (Cart)Session["Cart"];
            //lnkbtnViewCart.Text = "Cart(" + cart.TotalQuantity + ")";
            if (!IsPostBack)
            {
                if (!(Session["Username"] == null))
                {
                    string email = Session["Username"].ToString();

                    lblWelcomeUser.Text = "Hello, " + email;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx", false);
        }

        protected void lnkbtnCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}