<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="CustomerVideoGames.aspx.cs" Inherits="Part2.CustomerVideoGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="gridview">
        <asp:Label ID="lblProducts" runat="server" Text="Video Games" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <img src='<%# Eval("ImageURL") %>' height="150" width="150" />
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
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Add to Wish List">
                    <ControlStyle CssClass="button1" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Add to Cart">
                    <ControlStyle CssClass="button" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
