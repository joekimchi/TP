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
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class CustomerVideoGames : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        ArrayList shoppingCart = new ArrayList();
        SPCaller spc = new SPCaller();

        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/";

        string loginID;
        string password;
        int accountType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            else
            {
                loginID = Session["Username"].ToString();
                password = Session["Password"].ToString();
                accountType = int.Parse(Session["AccountType"].ToString());

                if (!IsPostBack)
                {
                    DisplayProduct();
                }
            }
        }

        public void DisplayProduct()
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(url + "3/");
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Product[] products = js.Deserialize<Product[]>(data);

            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gvProducts.SelectedIndex;

            Product p = new Product();
            p.Title = gvProducts.SelectedRow.Cells[0].Text;
            p.Description = gvProducts.SelectedRow.Cells[1].Text;
            p.Price = Convert.ToDouble(gvProducts.SelectedRow.Cells[2].Text);
            TextBox Quantity = (TextBox)gvProducts.SelectedRow.FindControl("txtQuantity");
            p.ImageUrl = gvProducts.SelectedRow.Cells[3].Text;
            p.Quantity = Convert.ToInt32(Quantity.Text);

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