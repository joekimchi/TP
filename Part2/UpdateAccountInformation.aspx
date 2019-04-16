<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAccountInformation.aspx.cs" Inherits="Part2.UpdateAccountInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Update Account Information</h1>
        <div id="AccountInformation" runat="server">

            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Home" />
            <br />
            <br />

            Name<br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            Phone Number<br />
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
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
            <br />
            <asp:Button ID="btnSubmitChanges" runat="server" OnClick="btnSubmitChanges_Click" Text="Submit Changes" />
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
