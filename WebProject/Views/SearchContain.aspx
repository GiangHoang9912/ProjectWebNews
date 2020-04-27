<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="SearchContain.aspx.cs" Inherits="WebProject.Views.SearchContain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="content-left">

            <asp:DataList ID="dlNewsByTitleContain" runat="server" OnItemCommand="dlNewsByTitleContain_ItemCommand">
                <ItemTemplate>
                    <div>
                        <img src='../Logo/<%# Eval("Imglink") %>' />
                    </div>
                    <asp:LinkButton ID="LinkButton3" CssClass="LinkButton" runat="server" CommandName='<%# Eval("NewID") %>'>
                   <%# Eval("NewTitle") %>
                    </asp:LinkButton><br />
                    <br />
                    <br />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <h3 style="padding-left : 40%;"><%=NotFount %></h3>
        </div>
        <div class="content-right">
            <asp:Image ID="banner" runat="server" />
        </div>
    </div>
    <div class="paging">
                                    <div>
            Page :
            <asp:Label ID="Label1" runat="server"></asp:Label><br />
            <asp:Repeater ID="btnPage" runat="server" OnItemCommand="btnPage_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="btnLink" runat="server" Class="<%# Container.DataItem %>" CommandName="<%# Container.DataItem %>">
                            <%# Container.DataItem %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
