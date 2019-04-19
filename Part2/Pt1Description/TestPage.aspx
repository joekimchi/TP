<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="APIClient.TestPage" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web API Test Page</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <!--HEADER-->
        <div>
            <h1>Web API Test Page</h1>
        </div>   
        <!--GET Departments-->
        <div>
            <h2>GetDepartments()</h2>
            <p>This method returns a list of Department Numbers and Department Names from the Department table in your database. 
                The Dataset returned by the function consists of 2 columns corresponding to the Department Number and Department Name.</p>
            <asp:Button ID="btnGetAll" runat="server" Text="Get All Departments" OnClick="btnGetAll_Click" /><br />
            <br />
            <asp:GridView ID="gvGetAllDepartments" runat="server" HorizontalAlign="Center"></asp:GridView>
        </div>
        <br />
        <!--GET ProductCatalog-->
        <div>
            <h2>GetProductCatalog(String DepartmentNumber)</h2>
            <p>This method accepts a Department Number as input and returns a DataSet containing the Product Number, Description, Price, and image URL for all products in that Department.  Dataset consists of 4 columns corresponding to the Product Number, Description, Price, and image URL.  </p>
            <asp:Label ID="lblDepartmentNumber" runat="server" Text="Input Department Number:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtDepartmentNumber" runat="server" Width="100px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnGetProductCatalog" runat="server" Text="Get Result" OnClick="btnGetProductCatalog_Click" />
            <br />
            <asp:Label ID="lblInputDepartmentError" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="gvProductCatalog" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EmptyDataText="No Products Found">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="ImageURL" HeaderText="ImageURL" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <!--BOOLEAN Register Site-->
        <div>
            <h2>Boolean RegisterSite(String SiteID, String Description, String APIKey, String email, Contact information)</h2>
            <p>This method will create a record for a site that will sell products on your behalf. You will need to store the Site’s 
                ID and it should return true when it successfully registers a site and false when the registration fails. The APIKey was 
                generated during the Merchant Registration process on the Amazon Site you used to create a Merchant Account (Term Project 
                Part 1 – Section 4). This APIKey should be a unique value shared between you and the Amazon Site that sells your products.</p>
            <asp:Label ID="lblSiteID" runat="server" Text="Input Site ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtSiteID" runat="server" Width="100px"></asp:TextBox>
            &nbsp;
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Input Description:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtDescription" runat="server" Width="254px"></asp:TextBox>
            <br />
            <asp:Label ID="lblAPIKey" runat="server" Text="Input APIKey:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtAPIKey" runat="server" Width="176px"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmailAddress" runat="server" Text="Input Email Address:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="230px"></asp:TextBox>
            <br />
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Input Phone Number:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtPhoneNumber" runat="server" Width="230px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <br />
            <asp:Label ID="lblRegisteredSuccessfully" runat="server" Text="Result: "></asp:Label>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
        <br />
        <!--BOOLEAN Record Purchase-->
        <div>
            <h2>Boolean RecordPurchase(String ProductID, int Quantity, String SellerSiteID, String APIKey, Object Customer Information)</h2>
            <p>
                <asp:Button ID="btnMerchant" runat="server" OnClick="btnMerchant_Click" Text="Merchant Store Description" />
            </p>
            <p>The purpose of this method is to allow an Amazon Site that sells your products the ability to send you information about a purchase. 
               This requires you (the merchant) to previously setup a merchant account with the Amazon site that will sell products on your behalf.
               This method accepts a ProductNumber and a Quantity that will be used to record the sale of a product from some team’s site that sells products for you. </p>
            <asp:Label ID="lblProductID" runat="server" Text="Input Product ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtProductID" runat="server" Width="100px"></asp:TextBox>
            &nbsp;
            <br />
            <asp:Label ID="lblQuantity" runat="server" Text="Input Quantity:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtQuantity" runat="server" Width="100px"></asp:TextBox>
            <br />
            <asp:Label ID="lblSellerSiteID" runat="server" Text="Input Seller Site ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtSellerSiteID" runat="server" Width="100px"></asp:TextBox>
            <br />
            <asp:Label ID="lblInputAPIKey" runat="server" Text="Input APIKey:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtInputAPIKey" runat="server" Width="176px"></asp:TextBox>
            <br />
            <asp:Label ID="lblCustomerInfo" runat="server" Text="Customer Info:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlCustomer" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmit1" runat="server" Text="Submit" OnClick="btnSubmit1_Click" />
            <br />
            <br />
            <asp:Label ID="lblRecordedSuccessfully" runat="server" Text="Result: "></asp:Label>
            <asp:Label ID="lblResult1" runat="server"></asp:Label>
            <br />
        </div>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
