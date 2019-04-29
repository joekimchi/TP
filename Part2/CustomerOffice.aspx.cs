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
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class CustomerOffice : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        ArrayList shoppingCart = new ArrayList();
        ArrayList wishList = new ArrayList();
        SPCaller spc = new SPCaller();

        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/";

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
            WebRequest request = WebRequest.Create(url + "2/");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Product[] products = js.Deserialize<Product[]>(data);

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