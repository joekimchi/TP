using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Utilities
{
    public class APICalls
    {
        public List<Department> GetDepartments(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            string data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Department> deptList = js.Deserialize<List<Department>>(data);

            return deptList;
        }

        public List<Product> GetProductCatalog(string url, String departmentNumber)
        {
            WebRequest request = WebRequest.Create(url + departmentNumber);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            string data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Product> prodList = js.Deserialize<List<Product>>(data);

            return prodList;
        }

        public bool RegisterSite(string url, String SiteID, String Description, String APIKey, String Email, String Contact)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            WebRequest request = WebRequest.Create(url + "Reg/" + "/" + SiteID + "/" + Description + "/" + APIKey + "/" +
                                                   Email + "/" + Contact);
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            bool data = bool.Parse(reader.ReadToEnd());
            reader.Close();
            response.Close();

            return data;
        }

        public bool RecordPurchase(string url, String ProductID, int Quantity, String SellerSiteID, String APIKey, String Date, String Time,
                                   Customer CustInfo)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonCust = js.Serialize(CustInfo);

            WebRequest request = WebRequest.Create(url + "Rec/" + ProductID + "/" + Quantity + "/" + SellerSiteID + "/" + APIKey + "/" + Date + "/" + Time);
            request.Method = "POST";
            request.ContentLength = jsonCust.Length;
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonCust);
            writer.Flush();
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            bool data = bool.Parse(reader.ReadToEnd());
            reader.Close();
            response.Close();

            return data;
        }
    }
}