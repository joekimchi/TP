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
            <asp:Button ID="btnUpdateAccountInformation" runat="server" Text="Update Account Information" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" />
            <br />
            <br />
            <br />
        </div>
        <div id="Customer">
            <br />
            <asp:Button ID="btnChangeCreditInformation" runat="server" Text="Change Credit Card Information" />
        </div>
        <div id="Merchant">
            <br />
            <br />
            <asp:Button ID="btnRetrieveAPIKey" runat="server" Text="Retrieve API Key" />
        </div>
    </form>
</body>
</html>
