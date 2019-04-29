using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                Response.Redirect("EmptyWishList.aspx", false);
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

        protected void messageBox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);

        }
    }

}