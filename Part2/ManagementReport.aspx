<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMerchantMaster.Master" AutoEventWireup="true" CodeBehind="ManagementReport.aspx.cs" Inherits="Part2.ManagementReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Management Report</h2>
    <div class="mgmt">
        <h2>Customer Sales Report
        </h2>
        <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" HorizontalAlign="Center" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="LoginID" HeaderText="Login ID" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="TotalDollarSales" HeaderText="Purchase Total ($)" DataFormatString="${0:###,###,###.00}" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
    </div>

    <br />
    <br />
    <div class="mgmt">
        <h2>Inventory Report
        </h2>
        Find all products with less than
            <asp:TextBox ID="txtQuantity" runat="server" Width="30px"></asp:TextBox>
        &nbsp;in stock&nbsp;<asp:Button ID="btnSearch" runat="server" Height="30px" OnClick="btnSearch_Click" Text="Search" />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        &nbsp;<asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" HorizontalAlign="Center" EmptyDataText="No products to display." ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Department" />
                <asp:BoundField DataField="Title" HeaderText="Product" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="${0:###,###,###.00}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
    </div>

    <br />

    <br />
    <div class="mgmt">
        <h2>Sales Report
        </h2>
        <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" HorizontalAlign="Center" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date of Sale" />
                <asp:BoundField DataField="Time" HeaderText="Time" />
                <asp:BoundField DataField="TotalDollarSales" HeaderText="Sales Total ($)" DataFormatString="${0:###,###,###.00}" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
