<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMerchantMaster.Master" AutoEventWireup="true" CodeBehind="MerchantHome.aspx.cs" Inherits="Part2.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Merchant" runat="server">
        <br />
        <h2>Your Sales</h2>
        <br />
        <asp:GridView ID="gvMerchant" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" EmptyDataText="You have not sold anything yet.">
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
</asp:Content>
