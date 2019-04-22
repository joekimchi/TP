<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Part2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ViewCart" style="text-align:center">
        <asp:GridView ID="gvCart" runat="server" Width="100%" ShowFooter="True" EmptyDataText="Cart is empty"></asp:GridView>
    </div>
</asp:Content>
