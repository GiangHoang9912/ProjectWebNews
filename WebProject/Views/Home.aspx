<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebProject.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Content --%>
    <div class="content">
        <%-- Content left --%>
        <div class="content-left">
            <asp:Image ID="NewsSpecs" runat="server" />
            <asp:LinkButton ID="btnNewsSpecs" CssClass="LinkButton" runat="server" OnClick="btnNewsSpecs_Click">LinkButton</asp:LinkButton>
            <div>
                <asp:Repeater ID="rpRandomNews" runat="server" OnItemCommand="rpRandomNews_ItemCommand">
                    <ItemTemplate>
                        <div class="NewsLittle">
                            <img src="../Logo/<%# Eval("NewsImage") %>" />

                            <asp:LinkButton ID="LinkButton1" CssClass="LinkButton" runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem, "NewsID") %>'><%# Eval("NewsTitle") %></asp:LinkButton>

                            <p>
                                <asp:Label ID="Label1" runat="server" Font-Size="Small"><%# Eval("StartDate") %></asp:Label></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <%-- Content right --%>
        <div class="content-right">
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
</asp:Content>
