<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Part2.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amazon Registration</title>
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <img src="img/amazon.png" alt="amazon.com" style="width: 200px; height: 55px;" />
        <br />
        <br />
        <fieldset style="width: 20%">
            <h2>Create account </h2>
            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Email" Width="225px"></asp:TextBox>
                <br />
            </div>
            <br />
            <div>
                <asp:Label ID="lblName" runat="server" Text="Your Name"></asp:Label>
                <br />
                <asp:TextBox ID="txtName" runat="server" Width="225px"></asp:TextBox>
                <br />
                <asp:Label ID="lblInvalidName" runat="server"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="225px"></asp:TextBox>
                <br />
            </div>
            <br />
            <div>
                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                <br />
                <asp:TextBox ID="txtPhoneNumber" runat="server" Width="225px"></asp:TextBox>
                <br />
            </div>
            <br />
            <div>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddress" runat="server" Width="225px"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                <br />
                <asp:TextBox ID="txtCity" runat="server" Width="225px"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Selected="True">AL</asp:ListItem>
                    <asp:ListItem>AK</asp:ListItem>
                    <asp:ListItem>AZ</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CO</asp:ListItem>
                    <asp:ListItem>CT</asp:ListItem>
                    <asp:ListItem>DE</asp:ListItem>
                    <asp:ListItem>DC</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>GA</asp:ListItem>
                    <asp:ListItem>HI</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>IL</asp:ListItem>
                    <asp:ListItem>IN</asp:ListItem>
                    <asp:ListItem>IA</asp:ListItem>
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>
                    <asp:ListItem>LA</asp:ListItem>
                    <asp:ListItem>ME</asp:ListItem>
                    <asp:ListItem>MD</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MI</asp:ListItem>
                    <asp:ListItem>MN</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MO</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem>
                    <asp:ListItem>NV</asp:ListItem>
                    <asp:ListItem>NH</asp:ListItem>
                    <asp:ListItem>NJ</asp:ListItem>
                    <asp:ListItem>NM</asp:ListItem>
                    <asp:ListItem>NY</asp:ListItem>
                    <asp:ListItem>NC</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>OH</asp:ListItem>
                    <asp:ListItem>OK</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>RI</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SD</asp:ListItem>
                    <asp:ListItem>TN</asp:ListItem>
                    <asp:ListItem>TX</asp:ListItem>
                    <asp:ListItem>UT</asp:ListItem>
                    <asp:ListItem>VT</asp:ListItem>
                    <asp:ListItem>VA</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>WI</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:Label ID="lblZip" runat="server" Text="Zipcode"></asp:Label>
                <br />
                <asp:TextBox ID="txtZipcode" runat="server" MaxLength="5" Width="225px"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblSecurityQuestion1" runat="server" Text="Security Question 1"></asp:Label>
                <br />
                What was your High School mascot?<br />
                <asp:TextBox ID="txtSecurityAnswer1" runat="server" Width="225px"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblSecurityQuestion2" runat="server" Text="Security Question 2"></asp:Label>
                <br />
                What is the make of your first car?<br />
                <asp:TextBox ID="txtSecurityAnswer2" runat="server" Width="225px"></asp:TextBox>
                <br />
            </div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <div>
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Create your Amazon account" Width="225px" CssClass="button" />
                <br />
                <br />
                Already have an account?
                    <asp:HyperLink ID="hyperSignIn" runat="server" NavigateUrl="Login.aspx" style="text-decoration: none; color: #146EB4">Sign in</asp:HyperLink>
                <br />
            </div>
            <br />
            <div>
                <asp:Button ID="btnRegisterforMerchantAccount" runat="server" Text="Register new Merchant" OnClick="btnRegisterforMerchantAccount_Click" CssClass="button1" />
            </div>
        </fieldset>
    </form>
</body>
</html>
