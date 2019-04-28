<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Part2.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Your Shopping Cart</h2>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <div id="ViewCart" style="text-align: center">
            <asp:GridView ID="gvCart" runat="server" Width="100%" ShowFooter="True" EmptyDataText="Your Cart is Empty" AutoGenerateColumns="False" OnRowCancelingEdit="gvCart_RowCancelingEdit" OnRowEditing="gvCart_RowEditing" OnRowUpdating="gvCart_RowUpdating" OnRowDeleting="gvCart_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <img src='<%# Eval("ImageURL") %>' height="150" width="150" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" DataFormatString="${0:###,###,###.00}">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" EditText="Update">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" EditText="" ShowDeleteButton="True" DeleteText="Remove">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="button" OnClick="btnCheckout_Click" />
        <br />
        <br />
    </div>
</asp:Content>
