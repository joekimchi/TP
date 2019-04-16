<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Part2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
                    Home
        </h1>    
        <div id="Default">
            <asp:Button ID="btnUpdateAccountInformation" runat="server" Text="Update Account Information" OnClick="btnUpdateAccountInformation_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            <br />
            <br />
            <br />
        </div>
        <div id="Customer" runat="server">
            <br />
            <asp:Button ID="btnChangeCreditInformation" runat="server" Text="Change Credit Card Information" OnClick="btnChangeCreditInformation_Click" />
            <br />
        </div>
        <div id="Merchant" runat="server">
            <br />
            <br />
            <asp:Button ID="btnRetrieveAPIKey" runat="server" Text="Retrieve API Key" OnClick="btnRetrieveAPIKey_Click" />
            <br />
            <asp:Label ID="lblAPIKey" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
