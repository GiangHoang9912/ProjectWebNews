<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="DetailNews.aspx.cs" Inherits="WebProject.Views.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/detail.css" rel="stylesheet" />
    <style>
        .Time{
            float :right;
            font-weight : bold;
            color :#fff;
            padding-top :20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="content-left">
            <%--<asp:Label ID="title" runat="server" Text="Title" Font-Bold="True" Font-Size="Larger" Font-Underline="True"></asp:Label><br /><br />
        <asp:Image ID="NewsImage" runat="server"/><br /><br />
        <asp:Label ID="content" runat="server" Text="content" Font-Size="Medium"></asp:Label><br /><br />
        <asp:Label ID="date" runat="server" Text="Label" Font-Size="Smaller"></asp:Label><br /><br />--%>
            <div class="hiddenText"></div>
            <iframe style="background-color : #fff" runat="server" id="contentNews" width="100%"></iframe>
            <asp:Label ID="Label2" CssClass="Time" runat="server" Text=""></asp:Label>
            <% if (Convert.ToInt32(Session["rule"]) == 2)
                {
            %>
            <asp:LinkButton ID="Save" runat="server" OnClick="Save_Click">Save News</asp:LinkButton><%
                }
            %>
        </div>
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
            <asp:Image ID="banner" runat="server" />
        </div>
    </div>
    <% if (Session["accountID"] != null)
        { %>
    <div class="comment">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="22px" TextMode="MultiLine" Width="264px"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button Height="30px" Width="50px" ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>

        <asp:Repeater ID="rpComment" runat="server" OnItemCommand="rpComment_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <%# Eval("UserName") %>  :
                            <asp:LinkButton CommandArgument='<%# Eval("CommentID") %>' ID="LinkButton1" Enabled="false" runat="server"><%# Eval("CommentContent") %></asp:LinkButton>
                        </td>

                        <td>
                            <asp:ImageButton Height="20px" CommandName="DeleteCmt" CommandArgument='<%# Eval("CommentID") %>' Visible='<%# ShowDeleteButton(Eval("AccountID").ToString()) %>' Width="20px" ID="ImageButton1" runat="server" ImageUrl="~/Logo/XoaComment.png" />
                            <script runat="server">
                                protected bool ShowDeleteButton(string deger)
                                {
                                    try { return string.Equals(deger, Session["accountID"].ToString()); }
                                    catch { return false; }
                                }
                            </script>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <% } %>
</asp:Content>
