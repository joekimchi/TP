<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Part2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Home</h1>    
        <div id="Default">
            <asp:Button ID="btnUpdateAccountInformation" runat="server" Text="Update Account Information" OnClick="btnUpdateAccountInformation_Click" CssClass="button" Height="43px" Width="300px" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" CssClass="button" Height="43px" Width="300px" />
            <br />
            <br />
            <br />
        </div>
        <div id="Customer" runat="server">
            <asp:Button ID="btnAddCC" runat="server" CssClass="button" Height="43px" OnClick="btnAddCC_Click" Text="Add New Credit Card" Width="300px" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnChangeCreditInformation" runat="server" Text="Change Credit Card Information" OnClick="btnChangeCreditInformation_Click" CssClass="button" Height="43px" Width="300px" />
            <br />
            <br />
            <h2>
                Your Purchases
            </h2>
            <br />
            <br />
            <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" EmptyDataText="No purchases to display." HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="SiteName" HeaderText="Site Name" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="Time" HeaderText="Time" />
                    <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Dollar Sales" />
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
        <div id="Merchant" runat="server">
            <br />
            <h2>
                Your Sales
            </h2>
            <br />
            <br />
            <asp:GridView ID="gvMerchant" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                    <asp:BoundField DataField="Time" HeaderText="Time" />
                    <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Dollar Sales" />
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
            <asp:Label ID="lblAPIKey" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnRetrieveAPIKey" runat="server" Text="Retrieve API Key" OnClick="btnRetrieveAPIKey_Click" CssClass="button" Height="43px" Width="300px" />
            <br />
        </div>
        <div id="Manager" runat="server">

            <br />
            <asp:Button ID="btnManagementReport" runat="server" OnClick="btnManagementReport_Click" Text="View Management Report" CssClass="button" Height="43px" Width="300px" />

        </div>
    </form>
</body>
</html>
