<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="UpdateAccountInformation.aspx.cs" Inherits="Part2.UpdateAccountInformation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="orderList">
        <h2>Your Purchases</h2>
        <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" EmptyDataText="No purchases to display." HorizontalAlign="Center" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="SiteName" HeaderText="Site Name" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Time" HeaderText="Time" />
                <asp:BoundField DataField="TotalDollarSales" HeaderText="Total Dollar Sales" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
    </div>
    <div id="AccountInformation" runat="server">
        <h2>Update your Amazon account</h2>
        Full Name<br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Phone Number<br />
        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
        <br />
        <br />
        Address<br />
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <br />
        City<br />
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br />
        <br />
        State<br />
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
        <br />
        <br />
        Zip Code<br />
        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnSubmitChanges" runat="server" OnClick="btnSubmitChanges_Click" Text="Submit Changes" CssClass="button" Height="43px" Width="300px" />
        <br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        <br />
        <br />
        <div id="Default">
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" CssClass="button1" Height="43px" Width="300px" />
            &nbsp;<asp:Button ID="btnAddCC" runat="server" CssClass="button1" Height="43px" OnClick="btnAddCC_Click" Text="Add New Credit Card" Width="300px" />
            &nbsp;<asp:Button ID="btnChangeCreditInformation" runat="server" Text="Change Credit Card Information" OnClick="btnChangeCreditInformation_Click" CssClass="button1" Height="43px" Width="300px" />
        </div>
        <br />
    </div>
</asp:Content>
