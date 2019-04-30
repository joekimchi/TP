<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Part2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Order placed successfully!</h2>
        <br />
        Confirmation email sent to 
        <asp:Label ID="lblEmail" runat="server" Font-Bold="True" ForeColor="Blue" Text=""></asp:Label>.<br />
        Address:
        <asp:Label ID="lblAddress" runat="server"></asp:Label>
        ,
        <asp:Label ID="lblCity" runat="server"></asp:Label>
        ,
        <asp:Label ID="lblState" runat="server"></asp:Label>
        ,
        <asp:Label ID="lblZipcode" runat="server"></asp:Label>
        <br />
        <br />
        <h3>Your Order Summary</h3>
        <asp:GridView ID="gvCart" runat="server" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" DataFormatString="${0:###,###,###.00}">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
        <br />
    </div>
</asp:Content>
