<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOffice.aspx.cs" Inherits="Part2.CustomerOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="gridview">
        <asp:Label ID="lblProducts" runat="server" Text="Office" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" />
                <asp:BoundField DataField="description" HeaderText="Description" />
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
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
