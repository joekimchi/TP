<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementReport.aspx.cs" Inherits="Part2.ManagementReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Management Report<br />
            <br />
            <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="LoginID" HeaderText="Login ID" />
                    <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                    <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Dollar Sales" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
