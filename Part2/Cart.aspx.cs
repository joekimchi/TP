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

namespace AmazonTermProject
{
    public partial class Cart : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/Record/Purchase/";
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
                if (gvCart.Rows.Count != 0)
                {
                    displayCart(TotalPriceFooter());
                }
                else
                {
                    btnCheckout.Visible = false;
                    lblNoProducts.Visible = true;
                }
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
        public double TotalPriceFooter()
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
            gvCart.EditIndex = e.NewEditIndex;
            displayCart(TotalPriceFooter());
        }

        //Cancel Edit Row
        protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCart.EditIndex = -1;
            displayCart(TotalPriceFooter());
        }

        //Update Row
        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Product p = (Product)shoppingCart[rowIndex];
            shoppingCart = (ArrayList)Session["ShoppingCart"];

            TextBox TBox;
            TBox = (TextBox)gvCart.Rows[rowIndex].Cells[3].Controls[0];
            p.Quantity = Int32.Parse(TBox.Text);

            Session["ShoppingCart"] = shoppingCart;
            gvCart.EditIndex = -1;
            displayCart(TotalPriceFooter());
        }

        //Delete Row
        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            shoppingCart = (ArrayList)Session["ShoppingCart"];
            shoppingCart.RemoveAt(row);

            Session["ShoppingCart"] = shoppingCart;
            displayCart(TotalPriceFooter());
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }  
    }
}