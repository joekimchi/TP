<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantStoreDescription.aspx.cs" Inherits="APIClient.MerchantStoreDescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <asp:Button ID="btnBack" runat="server" Text="Back to Test Page" OnClick="btnBack_Click" />
        </div>
        <br />
        <div>
            The API&#39;s RecordPurchase method returns a Boolean and takes the following arguments:<br />
            <br />
&nbsp;&nbsp;&nbsp; ProductID (String), the ID of the product purchased<br />
            <br />
&nbsp;&nbsp;&nbsp; Quantity (int), the number of products purchased with that ID<br />
            <br />
&nbsp;&nbsp;&nbsp; SellerSiteID (String),&nbsp; the ID of the site that sold the product(s)<br />
            <br />
&nbsp;&nbsp;&nbsp; APIKey (String), represents the key shared between Amazon and the Seller Site<br />
            <br />
&nbsp;&nbsp;&nbsp; CustInfo (CustomerInformation Object), an object which contains the following properties:<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name (string), the name of the customer<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address (string), the customer&#39;s address<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Contact (string), the customer&#39;s cell phone number--include dashes<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email (string), the customer&#39;s email address<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Occupation (string), the customer&#39;s job<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The CustomerInformation Object uses a default constructor. Here is an example on how to create and add properties to the object:<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustomerInformaton CustInfo = CustomerInformation();<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustInfo.Name = &quot;John Doe&quot;;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustInfo.Address = &quot;123 Mulberry Rd Philadelphia, PA 19123&quot;;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustInfo.Contact = &quot;215-123-4567&quot;;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustInfo.Email = &quot;<a href="mailto:jdoe@yahoo.com">jdoe@yahoo.com</a>&quot;;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustInfo.Occupation = &quot;Electrical Engineer&quot;;</div>
    </form>
</body>
</html>
