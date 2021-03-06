﻿using System;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace Part2
{
    public partial class Cart : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/Rec/";
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

        //Show Shopping Cart by Session
        public void displayCart(double totalcost)
        {
            gvCart.Columns[0].FooterText = "Total";
            gvCart.Columns[3].FooterText = totalcost.ToString("C2");
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
            shoppingCart = (ArrayList)Session["ShoppingCart"];
            Product p = (Product)shoppingCart[rowIndex];

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

        //Checkout Button (only visible if gridview has data)
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            shoppingCart = (ArrayList)Session["ShoppingCart"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            APICalls api = new APICalls();
            SPCaller spc = new SPCaller();

            Customer c = new Customer();
            c.Email = Session["Username"].ToString();
            c.CustomerID = spc.GetCustomerIDByEmail(c.Email);

            //Adding each product into the database
            foreach (Product p in shoppingCart)
            {
                //String jsonCheckout = js.Serialize(p);
                try
                {
                    bool data = api.RecordPurchase(url, p.ID.ToString(), p.Quantity, "1", "0", DateTime.Now.ToString(), DateTime.Now.TimeOfDay.ToString(), c);
                    if (data == true)
                    {
                        Response.Redirect("Confirmation.aspx", false);
                    }
                    else
                    {
                        lblMessage.Text = "A problem occurred while checking out.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            gvCart.DataSource = new DataTable();
            gvCart.DataBind();

            Session.Remove("ShoppingCart");
            Response.Redirect("EmptyCart.aspx", false);

            DBConnect objDB = new DBConnect();
            SPCaller spc = new SPCaller();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_EmptyCart";

            int custID = spc.GetCustomerIDByEmail(Session["Username"].ToString());

            objCommand.Parameters.AddWithValue("@CustomerID", custID);
            objCommand.Parameters.Add("@New", SqlDbType.VarBinary, -1);
            objCommand.Parameters["@New"].Value = DBNull.Value;

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}