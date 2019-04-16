﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterMerchant.aspx.cs" Inherits="Part2.RegisterMerchant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amazon Merchant Registration</title>
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <img src="img/amazon.png" alt="amazon.com" style="width: 200px; height: 55px;" />
        <br />
        <fieldset style="width: 0">
            <h3>Merchant Registration </h3>
            <br />
            <div>
                Site ID (integers only)<br />
                <asp:TextBox ID="txtSiteID" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblDuplicateID" runat="server"></asp:Label>
                <br />
                Site Name<br />
                <asp:TextBox ID="txtSiteName" runat="server"></asp:TextBox>
                <br />
                Site URL<br />
                <asp:TextBox ID="txtSiteURL" runat="server"></asp:TextBox>
                <br />
                Merchant
            Name
            <br />
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                Address<br />
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <br />
                City<br />
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <br />
                State<br />
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                <br />
                Zip Code<br />
                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                <br />
                Email (This will be your Login)<br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                Password<br />
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <br />
                Phone Number<br />
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Create your Amazon Merchant account" />
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
                <br />
                <br />
                Already have an account?
                    <asp:HyperLink ID="hyperSignIn" runat="server" NavigateUrl="Login.aspx">Sign in</asp:HyperLink>
                <br />
                <br />
                <asp:Button ID="btnRegisterNewCustomer" runat="server" OnClick="btnRegisterNewCustomer_Click" Text="Register New Customer" />
                <br />
            </div>
        </fieldset>
    </form>
</body>
</html>
