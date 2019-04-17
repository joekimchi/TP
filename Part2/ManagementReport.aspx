<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementReport.aspx.cs" Inherits="Part2.ManagementReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
    <title>Management Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Management Report<br />
            <br />
            Customer Sales Report<br />
            <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="LoginID" HeaderText="Login ID" />
                    <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                    <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Dollar Sales" />
                </Columns>
            </asp:GridView>
            <br />
            Inventory Report<asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Department" />
                    <asp:BoundField DataField="Title" HeaderText="Product" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
            <br />
            Sales Report<asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date of Sale" />
                    <asp:BoundField DataField="Time" HeaderText="Time" />
                    <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Sales ($)" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
