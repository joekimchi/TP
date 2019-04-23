<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AmazonTermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amazon Sign In</title>
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <img src="img/amazon.png" alt="amazon.com" style="width: 200px; height: 55px;"/>
        <br />
        <br />
        <fieldset style="width: 20%", text-align:"center">
            <div>
                <h2>Sign in</h2>
                <div>
                    Account Type<br />
                    <asp:DropDownList ID="ddlLoginType" runat="server">
                        <asp:ListItem Selected="True" Value="Customer">Customer</asp:ListItem>
                        <asp:ListItem Value="Merchant">Merchant</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtEmail" runat="server" Width="225px"></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="lblPassowrd" runat="server" Text="Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="225px"></asp:TextBox>
                    <br />
                    <asp:HyperLink ID="hyperPassword" runat="server" NavigateUrl="ForgotPassword.aspx" style="text-decoration: none; color: #146EB4">Forgot your password?</asp:HyperLink>
                    <br />
                </div>
                    <asp:Label ID="lblLoginErrorMessage" runat="server"></asp:Label>
                <br />
                <asp:CheckBox ID="chkbxRememberMe" runat="server" Text="Keep me signed in" />
                <br />
                <br />
                <!--Buttons-->
                <asp:Button ID="btnLogin" runat="server" Text="Sign in" OnClick="btnLogin_Click" Width="225px" CssClass="button" />
                <br />
                <br />
                New to Amazon?<br />
                <asp:Button ID="btnNewUser" runat="server" Text="Create your Amazon account" OnClick="btnNewUser_Click" Width="225px" CssClass="button1" Height="39px" />
                <br />
                <br />
            </div>
        </fieldset>
    </form>
</body>
</html>
