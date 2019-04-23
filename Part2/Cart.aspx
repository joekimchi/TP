<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="AmazonTermProject.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Your Shopping Cart</h2>
        <asp:Label ID="lblNoProducts" runat="server" Text="Looks like your cart is empty. Start shopping!" Visible="False"></asp:Label>
        <br />
        <asp:HyperLink ID="hyperShop" runat="server" Font-Underline="False" ForeColor="#146EB4" NavigateUrl="CustomerHome.aspx">Return to home</asp:HyperLink>
        <div id="ViewCart" style="text-align: center">
            <asp:GridView ID="gvCart" runat="server" Width="100%" ShowFooter="True" EmptyDataText="Cart is empty" AutoGenerateColumns="False" OnRowCancelingEdit="gvCart_RowCancelingEdit" OnRowEditing="gvCart_RowEditing" OnRowUpdating="gvCart_RowUpdating" OnRowDeleting="gvCart_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Image" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Desc" HeaderText="Description" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
    </div>
</asp:Content>
