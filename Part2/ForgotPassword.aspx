<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Part2.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amazon Password Assistance</title>
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <img src="img/amazon.png" alt="amazon.com" style="width: 200px; height: 55px;" />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx" Style="text-decoration: none; color: #146EB4">Return to login</asp:HyperLink>
        <br />
        <br />
        <fieldset style="width: 20%">
            <h2>Password assistance</h2>
            <p>Enter the email address associated with your Amazon account.</p>
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="85%" placeholder="example@email.com"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlLoginType" runat="server">
                <asp:ListItem Selected="True" Value="0">Customer</asp:ListItem>
                <asp:ListItem Value="1">Merchant</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Continue" Width="85%" CssClass="button" OnClick="btnSubmit_Click" />
            <br />
            <br />
            <div id="questions" runat="server" visible="false">
                <hr />
                <h2>Security Questions</h2>
                <h5>(case sensitive)</h5>
                <div>
                    <label>1. What was your High School mascot?</label>
                    <asp:TextBox ID="txtSecurity1" runat="server" type="text" Width="85%" TextMode="Password"/>
                </div>
                <br />
                <div>
                    <label>2. What is the make of your first car?</label>
                    <asp:TextBox ID="txtSecurity2" runat="server" type="text" Width="85%" TextMode="Password"/>
                </div>
                <div>
                    <asp:Label ID="lblError1" runat="server"></asp:Label>
                    <br />
                </div>
                <div>
                    <asp:Button ID="btnAnswer" runat="server" Text="Continue" Width="85%" CssClass="button" OnClick="btnAnswer_Click" />
                </div>
            </div>
            <br />
            <div id="passwordReset" runat="server" visible="false">
                <hr />
                <h2>Password Reset</h2>
                <div>
                    <label>New password</label>
                    <asp:TextBox ID="txtNewPassword" runat="server" type="text" Width="85%" TextMode="Password"/>
                </div>
                <br />
                <div>
                    <label>Re-enter password</label>
                    <asp:TextBox ID="txtReenterPassword" runat="server" type="text" Width="85%" TextMode="Password"/>
                </div>
                <div>
                    <asp:Label ID="lblError2" runat="server"></asp:Label>
                    <br />
                </div>
                <div>
                    <asp:Button ID="btnConfirmPassword" runat="server" Text="Continue" Width="85%" CssClass="button" OnClick="btnConfirmPassword_Click" />
                </div>
            </div>
        </fieldset>
    </form>
</body>
</html>
