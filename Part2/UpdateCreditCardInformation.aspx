<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCreditCardInformation.aspx.cs" Inherits="Part2.UpdateCreditCardInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Stylesheet.css" />
    <title>Update Credit Card Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Credit Card Information</h1>
            <br />
            <asp:Button ID="btnBack" runat="server" CssClass="button" Height="39px" OnClick="btnBack_Click" Text="Back to Home" Width="300px" />
            <br />
            <br />
            <br />
            Select Card to Update<br />
            <asp:DropDownList ID="ddlCard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCard_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Card Number<br />
            <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
            <br />
            Expiration Date<br />
            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            /<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="btnSubmitChanges" runat="server" OnClick="btnSubmitChanges_Click" Text="Submit Changes" CssClass="button" Height="43px" Width="300px" />
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
