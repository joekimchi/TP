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
    public partial class CustomerElectronics : System.Web.UI.Page
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
            List<Product> products1  = js.Deserialize<List<Product>>(data1);

            foreach(Product p in products1)
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


            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gvProducts.SelectedIndex;

            Product p = new Product();
            p.ImageUrl = gvProducts.SelectedRow.Cells[0].Text;
            p.Title = gvProducts.SelectedRow.Cells[1].Text;
            p.Description = gvProducts.SelectedRow.Cells[2].Text;
            p.Price = Double.Parse(gvProducts.SelectedRow.Cells[3].Text, System.Globalization.NumberStyles.Currency);
            TextBox Quantity = (TextBox)gvProducts.SelectedRow.FindControl("txtQuantity");
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