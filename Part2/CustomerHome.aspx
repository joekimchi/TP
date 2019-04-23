<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="AmazonTermProject.CustomerHome" %>

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
        <asp:Button ID="btnManagementReport" runat="server" OnClick="btnManagementReport_Click" Text="View Management Report" CssClass="button" Height="43px" Width="300px" />
    </div>

    <br />


    <div id="gridview">
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" />
                <asp:BoundField DataField="desc" HeaderText="Description" />
                <asp:BoundField DataField="price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" type="number" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="imageUrl" HeaderText="Image" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Add to cart">
                    <ControlStyle CssClass="button1" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:BoundField DataField="productID" HeaderText="Product ID" Visible="False" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
