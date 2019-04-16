<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCreditCardInformation.aspx.cs" Inherits="Part2.UpdateCreditCardInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Update Credit Card Information<br />
            <br />
            Card Number<br />
            <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
            <br />
            Expiration Date<br />
            <asp:TextBox ID="txtExpiration" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmitChanges" runat="server" OnClick="btnSubmitChanges_Click" Text="Submit Changes" />
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
