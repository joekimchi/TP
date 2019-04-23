<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="AddCreditCard.aspx.cs" Inherits="AmazonTermProject.AddCreditCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:HyperLink ID="hyperBack" runat="server" CssClass="Hyperlink" NavigateUrl="UpdateAccountInformation.aspx" style="text-decoration: none; color: #146EB4">Return to Update Account Info</asp:HyperLink>
        <br />
        <br />
        Card Number<br />
        <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
        <br />
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
        <asp:Button ID="btnAddCard" runat="server" OnClick="btnSubmitChanges_Click" Text="Add Card" CssClass="button" Height="43px" Width="300px" />
        <br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
</asp:Content>
