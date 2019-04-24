<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="Part2.CustomerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Manager" runat="server">
        <asp:Button ID="btnManagementReport" runat="server" OnClick="btnManagementReport_Click" Text="View Management Report" CssClass="button" Height="43px" Width="300px" />
    </div>

    <br />


    <div id="gridview">
        <h2>Things for You</h2>
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
