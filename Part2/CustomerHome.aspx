<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="Part2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Default">
        <h2>Your Purchases</h2>
        <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" EmptyDataText="No purchases to display." HorizontalAlign="Center" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="SiteName" HeaderText="Site Name" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Time" HeaderText="Time" />
                <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Dollar Sales" />
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
    <div id="Manager" runat="server">
        <br />
        <asp:Button ID="btnManagementReport" runat="server" OnClick="btnManagementReport_Click" Text="View Management Report" CssClass="button" Height="43px" Width="300px" />
    </div>
</asp:Content>
