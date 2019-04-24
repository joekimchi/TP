<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="ChangePasswordCust.aspx.cs" Inherits="Part2.ChangePasswordCust" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Change Password</h2>
        <asp:HyperLink ID="hyperBack" runat="server" CssClass="Hyperlink" NavigateUrl="UpdateAccountInformation.aspx" style="text-decoration: none; color: #146EB4">Return to Update Account Info</asp:HyperLink>
        <br />
        <br />
        Enter your current password<br />
        <asp:TextBox ID="txtOldPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        Enter your new password<br />
        <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        Confirm your new password<br />
        <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblNotMatched" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnUpdatePassword" runat="server" OnClick="btnUpdatePassword_Click" Text="Update Password" CssClass="button" Height="39px" Width="300px" />
        <br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
</asp:Content>
