<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementReport.aspx.cs" Inherits="Part2.ManagementReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
    <title>Management Report</title>
</head>
<body>
    <form id="form1" runat="server">
            <h1>Management</h1>
            <asp:Button ID="btnBack" runat="server" CssClass="button" Height="39px" OnClick="btnBack_Click" Text="Back to Home" />
            <br />
            <br />
            <div class="mgmt">
                <h2>
                    Customer Sales Report
                </h2>
                <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="LoginID" HeaderText="Login ID" />
                        <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                        <asp:BoundField DataField="TotalDollarSales" HeaderText="Purchase Total ($)" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <br />
            </div>

            <br />
            <br />
            <div class="mgmt">
                <h2>
                    Inventory Report
                </h2>
                Find all products with less than
            <asp:TextBox ID="txtQuantity" runat="server" Width="30px"></asp:TextBox>
                &nbsp;in stock&nbsp;<asp:Button ID="btnSearch" runat="server" Height="30px" OnClick="btnSearch_Click" Text="Search" />
                <br />
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <br />
                &nbsp;<asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" EmptyDataText="No products to display.">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Department" />
                        <asp:BoundField DataField="Title" HeaderText="Product" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <br />
            </div>

            <br />

            <br />
            <div class="mgmt">
                <h2>
                    Sales Report
                </h2>
                <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date of Sale" />
                        <asp:BoundField DataField="Time" HeaderText="Time" />
                        <asp:BoundField DataField="TotalDollarSales" HeaderText="Sales Total ($)" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <br />
            </div>
    </form>
</body>
</html>
