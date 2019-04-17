﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Part2.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
    <title>Forgot Password</title>

</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <img src="img/amazon.png" alt="amazon.com" style="width: 200px; height: 55px;" />
        <br />
        <br />
        <fieldset style="width: 20%">
            <h2>Password assistance</h2>
            <p>Enter the email address associated with your Amazon account.</p>
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="85%"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlLoginType" runat="server">
                <asp:ListItem Selected="True" Value="Customer">Customer</asp:ListItem>
                <asp:ListItem Value="Merchant">Merchant</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Continue" Width="85%" CssClass="button" OnClick="btnSubmit_Click"/>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx">Return to login</asp:HyperLink>
        </fieldset>
    </form>
</body>
</html>
