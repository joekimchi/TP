﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AmazonMaster.Master" AutoEventWireup="true" CodeBehind="WishList.aspx.cs" Inherits="Part2.WishList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Your Wish List</h2>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <div id="ViewCart" style="text-align: center">
            <asp:GridView ID="gvCart" runat="server" Width="100%" ShowFooter="True" EmptyDataText="Your Cart is Empty" AutoGenerateColumns="False" OnRowDeleting="gvCart_RowDeleting" OnSelectedIndexChanged="gvCart_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <img src='<%# Eval("ImageURL") %>' height="150" width="150" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" DataFormatString="${0:###,###,###.00}">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" EditText="" ShowDeleteButton="True" DeleteText="Remove">
                        <ControlStyle CssClass="button1" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Add to cart">
                    <ControlStyle CssClass="button" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
        <br />
    </div>
</asp:Content>
