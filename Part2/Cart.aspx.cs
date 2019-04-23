using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using Utilities;

namespace Part2
{
    public partial class Cart : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/Record/Purchase/";
        ArrayList shoppingCart = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayCart(ShowTotalPrice());
            }
        }

        //Show Shopping Cart by Session
        public void displayCart(double totalcost)
        {
            gvCart.Columns[0].FooterText = "Total";
            gvCart.Columns[4].FooterText = totalcost.ToString("C2");
            shoppingCart = (ArrayList)Session["ShoppingCart"];
            gvCart.DataSource = shoppingCart;
            gvCart.DataBind();
        }

        //Total Price for Footer
        public double ShowTotalPrice()
        {
            shoppingCart = (ArrayList)Session["ShoppingCart"];
            double totalPrice = 0.0;
            foreach (Product p in shoppingCart)
            {
                double price = p.Price;
                int quantity = p.Quantity;
                totalPrice += p.TotalPrice(p.Price, p.Quantity);
            }
            return totalPrice;
        }

        //Edit Row
        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        //Cancel Edit Row
        protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
        }

        //Update Row
        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }  
    }
}