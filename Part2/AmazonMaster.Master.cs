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
            Response.Redirect("CustomerHome.aspx", false);
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAccountInformation.aspx", false);
        }

        protected void lnkbtnWishList_Click(object sender, EventArgs e)
        {
            if (Session["WishList"] != null)
            {
                Response.Redirect("WishList.aspx", false);
            }
            else
            {
                Response.Redirect("EmptyEmpty.aspx", false);
            }
        }

        protected void lnkbtnViewCart_Click(object sender, EventArgs e)
        {
            if (Session["ShoppingCart"] != null)
            {
                Response.Redirect("Cart.aspx", false);
            }
            else
            {
                Response.Redirect("EmptyCart.aspx", false);
            }
        }

        protected void lnkbtn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerElectronics.aspx", false);
        }

        protected void lnkbtn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOffice.aspx", false);
        }

        protected void lnkbtn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerVideoGames.aspx", false);
        }
    }
}