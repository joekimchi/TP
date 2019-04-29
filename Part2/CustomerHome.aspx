<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="Part2.CustomerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="gridview">
        <asp:Label ID="lblProducts" runat="server" Text="Product Catalog" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="gvProducts_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img ID="ImageURL" runat="server" src='<%# Eval("ImageURL") %>' height="150" width="150" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="${0:###,###,###.00}" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" type="number" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAddToWishList" runat="server" Text="Add To Wish List" CommandName="AddToWishList" CommandArgument="<%# Container.DataItemIndex %>" class="button1" />
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" CommandName="AddToCart" CommandArgument="<%# Container.DataItemIndex %>" class="button" />
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
