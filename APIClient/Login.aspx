<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="APIClient.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>

            <!--Username input-->
            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
            </div>

            <!--Password input -->
            <div>
                <asp:Label ID="lblPassowrd" runat="server" Text="Password:"></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
            </div>

            <div>
                <asp:DropDownList ID="ddlLoginType" runat="server">
                         <asp:ListItem Selected="True" Value="0">Customer</asp:ListItem>
                         <asp:ListItem Value="1">Merchant</asp:ListItem>
                     </asp:DropDownList>
            </div>

            <!--Remember Me Checkbox // login error message-->
            <div>
                <asp:CheckBox ID="chkbxRememberMe" runat="server" Text="Remember Me" />
                <br />
                <asp:Label ID="lblLoginErrorMessage" runat="server"></asp:Label>
            </div>

            <br />

            <!--Buttons-->
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnNewUser" runat="server" Text="Register" OnClick="btnNewUser_Click" />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Return Home" />
        </div>
    </form>
</body>
</html>