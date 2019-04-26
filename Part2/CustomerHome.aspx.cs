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
    public partial class CustomerHome : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        ArrayList shoppingCart = new ArrayList();
        SPCaller spc = new SPCaller();

        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug46231/TermProjectWS/api/service/Merchants/";
        string url2 = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tuj59730/TermProjectWS/api/service/Merchants/";

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

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gvProducts.SelectedIndex;

            Product p = new Product();
            p.Title = gvProducts.SelectedRow.Cells[0].Text;
            p.Description = gvProducts.SelectedRow.Cells[1].Text;
            p.Price = Double.Parse(gvProducts.SelectedRow.Cells[2].Text, System.Globalization.NumberStyles.Currency);
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