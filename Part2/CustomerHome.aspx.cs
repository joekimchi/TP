using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using Utilities;
using System.Data.SqlClient;

namespace Part2
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        ArrayList shoppingCart = new ArrayList();
        ArrayList wishList = new ArrayList();
        SPCaller spc = new SPCaller();

        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/";
        string url2 = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tuj59730/TermProjectWS/api/service/Merchants/";

        string loginID;
        string password;
        int accountType;

        protected void Page_Load(object sender, EventArgs e)
        {
            var rows = gvProducts.Rows;
            foreach (GridViewRow row in rows)
            {
                TextBox t = (TextBox)row.FindControl("txtQuantity");
                t.Text = "1";
            }

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
            WebRequest request = WebRequest.Create(url + "1/");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Product> products = js.Deserialize<List<Product>>(data);


            //For new Merchant
            WebRequest request1 = WebRequest.Create(url2 + "GetProductCatalog/1001/");
            WebResponse response1 = request1.GetResponse();

            Stream theDataStream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(theDataStream1);
            String data1 = reader1.ReadToEnd();
            reader1.Close();
            response1.Close();

            JavaScriptSerializer js1 = new JavaScriptSerializer();
            List<Product> products1 = js.Deserialize<List<Product>>(data1);

            foreach (Product p in products1)
            {
                products.Add(p);
            }

            //For new Merchant2
            WebRequest request2 = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug40077/TermProjectWS/api/service/Merchants/GetProductCatalog/2");
            WebResponse response2 = request2.GetResponse();

            Stream theDataStream2 = response2.GetResponseStream();
            StreamReader reader2 = new StreamReader(theDataStream2);
            String data2 = reader2.ReadToEnd();
            reader2.Close();
            response2.Close();

            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<Product> products2 = js.Deserialize<List<Product>>(data2);

            foreach (Product p in products2)
            {
                products.Add(p);
            }


            WebRequest request3 = WebRequest.Create(url + "2/");
            WebResponse response3 = request3.GetResponse();

            Stream theDataStream3 = response3.GetResponseStream();
            StreamReader reader3 = new StreamReader(theDataStream3);
            String data3 = reader3.ReadToEnd();
            reader3.Close();
            response3.Close();

            JavaScriptSerializer js3 = new JavaScriptSerializer();
            List<Product> products3 = js3.Deserialize<List<Product>>(data3);

            foreach (Product p in products3)
            {
                products.Add(p);
            }


            //FOR VIDEO GAMES
            WebRequest request4 = WebRequest.Create(url + "3/");
            WebResponse response4 = request4.GetResponse();

            Stream theDataStream4 = response4.GetResponseStream();
            StreamReader reader4 = new StreamReader(theDataStream4);
            String data4 = reader4.ReadToEnd();
            reader4.Close();
            response4.Close();

            JavaScriptSerializer js4 = new JavaScriptSerializer();
            List<Product> products4 = js.Deserialize<List<Product>>(data4);

            foreach (Product p in products4)
            {
                products.Add(p);
            }

            //FOR VIDEO GAMES
            WebRequest request5 = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug91466/TermProjectWS/api/service/Merchants/GetProductCatalog/2");
            WebResponse response5 = request5.GetResponse();

            Stream theDataStream5 = response5.GetResponseStream();
            StreamReader reader5 = new StreamReader(theDataStream5);
            String data5 = reader5.ReadToEnd();
            reader5.Close();
            response5.Close();

            JavaScriptSerializer js5 = new JavaScriptSerializer();
            List<Product> products5 = js5.Deserialize<List<Product>>(data5);

            foreach (Product p in products5)
            {
                products.Add(p);
            }

            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        //simple method that checks if input is a number
        public string isNumeric(string value)
        {
            int n;
            String flag;
            bool isNumeric = int.TryParse(value, out n);
            if (isNumeric == false)
            {
                flag = "false";
            }
            else
            {
                flag = "true";
            }
            return flag;
        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            TextBox userQuantity = (TextBox)gvProducts.Rows[index].FindControl("txtQuantity");
            string quantity = userQuantity.Text.Trim();

            if (isNumeric(quantity) == "false")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter valid numeric quantity');", true);
            }
            else
            {
                //Add to Wish List button
                if (e.CommandName == "AddToWishList")
                {
                    Product p = new Product();

                    p.ImageUrl = gvProducts.Rows[index].Cells[0].Text;
                    p.Title = gvProducts.Rows[index].Cells[1].Text;
                    p.Description = gvProducts.Rows[index].Cells[2].Text;
                    p.Price = Double.Parse(gvProducts.Rows[index].Cells[3].Text, System.Globalization.NumberStyles.Currency);
                    TextBox Quantity = (TextBox)gvProducts.Rows[index].FindControl("txtQuantity");
                    p.Quantity = Convert.ToInt32(Quantity.Text);

                    if (Session["WishList"] != null)
                    {
                        wishList = (ArrayList)Session["WishList"];
                        wishList.Add(p);
                    }
                    else
                    {
                        wishList.Add(p);
                    }
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Product added to your wish list');", true);
                    Session["WishList"] = wishList;
                }

                //Add to Cart button
                if (e.CommandName == "AddToCart")
                {
                    Product p = new Product();

                    p.ImageUrl = gvProducts.Rows[index].Cells[0].Text;
                    p.Title = gvProducts.Rows[index].Cells[1].Text;
                    p.Description = gvProducts.Rows[index].Cells[2].Text;
                    p.Price = Double.Parse(gvProducts.Rows[index].Cells[3].Text, System.Globalization.NumberStyles.Currency);
                    TextBox Quantity = (TextBox)gvProducts.Rows[index].FindControl("txtQuantity");
                    p.Quantity = Convert.ToInt32(Quantity.Text);

                    if (Session["ShoppingCart"] != null)
                    {
                        shoppingCart = (ArrayList)Session["ShoppingCart"];
                        shoppingCart.Add(p);
                    }
                    else
                    {
                        shoppingCart.Add(p);
                    }
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Product added to cart');", true);
                    Session["ShoppingCart"] = shoppingCart;
                }
            }
        }

    }
}