﻿using System;
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
    public partial class WishList : System.Web.UI.Page
    {
        ArrayList shoppingCart = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            else if (!IsPostBack)
            {
                displayCart(TotalPriceFooter());
            }
        }

        //Show Wish List by Session
        public void displayCart(double totalcost)
        {
            gvCart.Columns[0].FooterText = "Total";
            gvCart.Columns[3].FooterText = totalcost.ToString("C2");
            shoppingCart = (ArrayList)Session["WishList"];
            gvCart.DataSource = shoppingCart;
            gvCart.DataBind();
        }

        //Total Price for Footer
        public double TotalPriceFooter()
        {
            shoppingCart = (ArrayList)Session["WishList"];
            double totalPrice = 0.0;

            foreach (Product p in shoppingCart)
            {
                double price = p.Price;
                int quantity = p.Quantity;
                totalPrice += p.TotalPrice(p.Price, p.Quantity);
            }
            return totalPrice;
        }

        //Delete Row
        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            shoppingCart = (ArrayList)Session["WishList"];
            shoppingCart.RemoveAt(row);

            Session["WishList"] = shoppingCart;
            displayCart(TotalPriceFooter());
        }

        protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gvCart.SelectedIndex;

            Product p = new Product();
            p.ImageUrl = gvCart.SelectedRow.Cells[0].Text;
            p.Title = gvCart.SelectedRow.Cells[1].Text;
            p.Description = gvCart.SelectedRow.Cells[2].Text;
            p.Price = Double.Parse(gvCart.SelectedRow.Cells[3].Text, System.Globalization.NumberStyles.Currency);
            p.Quantity = Convert.ToInt32(gvCart.SelectedRow.Cells[4].Text);

            if (ViewState["ShoppingCart"] != null)
            {
                shoppingCart = (ArrayList)ViewState["ShoppingCart"];
                shoppingCart.Add(p);
            }
            else
            {
                shoppingCart.Add(p);
            }
            ViewState["ShoppingCart"] = shoppingCart;
            Session["ShoppingCart"] = shoppingCart;
        }
    }
}