<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AmazonTermProject.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
    <title>Change Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Change Password</h1>
            <br />
            <asp:HyperLink ID="hyperBackHome" runat="server" NavigateUrl="Home1.aspx" style="text-decoration: none; color: #146EB4">Return to Home</asp:HyperLink>
            <br />
            <br />
            Enter your current password<br />
            <asp:TextBox ID="txtOldPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your new password<br />
            <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            Confirm your new password<br />
            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNotMatched" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="btnUpdatePassword" runat="server" OnClick="btnUpdatePassword_Click" Text="Update Password" CssClass="button" Height="39px" Width="300px" />
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
