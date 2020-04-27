<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="SearchByType.aspx.cs" Inherits="WebProject.Views.SearchByType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="content-left">
            <asp:DataList ID="dlNewsByType" runat="server" OnItemCommand="dlNewsByType_ItemCommand">
                <ItemTemplate>
                    <div>
                        <img src='../Logo/<%# Eval("Imglink") %>' />
                    </div>
                    <asp:LinkButton ID="LinkButton2" CssClass="LinkButton" runat="server" CommandName='<%# Eval("NewID") %>'>
                   <%# Eval("NewTitle") %>
                    </asp:LinkButton><br /><br /><br /><br /><br />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="content-right">
            <asp:Image ID="banner" runat="server" />
            <asp:DataList ID="dlNews" runat="server" OnItemCommand="dlNews_ItemCommand">
                <ItemTemplate>
                    <div class="listTop5News">
                        <img class="imageNews" src='../Logo/<%# DataBinder.Eval(Container.DataItem, "NewsImage") %>' />
                        <div>
                            <asp:LinkButton ID="Top5Title" CssClass="LinkButton" runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem, "NewsID") %>'>
                            <%# DataBinder.Eval(Container.DataItem, "NewsTitle") %>
                            </asp:LinkButton><br />
                            <asp:Label ID="startdate" runat="server" Font-Size="Small"><%# Eval("StartDate") %></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="paging">
        <div>
            Page :
            <asp:Label ID="Label1" runat="server"></asp:Label><br />
            <asp:Repeater ID="btnPage" runat="server" OnItemCommand="rpPage_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="btnLink" runat="server" Class="<%# Container.DataItem %>" CommandName="<%# Container.DataItem %>">
                            <%# Container.DataItem %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
