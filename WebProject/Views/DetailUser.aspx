<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="DetailUser.aspx.cs" Inherits="WebProject.Views.DetailUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/detailuser.css" rel="stylesheet" />
    <script src="../Test/pikaday.js"></script>
    <link href="../Css/pikaday.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="UserInforContent">
        <table>
            <tr>
                <td>Full Name :
                </td>
                <td>
                    <asp:TextBox ID="FullName" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>Date Of Birth :
                </td>
                <td>
                    <%-- ContentPlaceHolder1_DateOfBirth --%>
                    <asp:TextBox ID="DateOfBirth" runat="server"></asp:TextBox><br />
                    <script>
                        var picker = new Pikaday({
                            field: document.getElementById('ContentPlaceHolder1_DateOfBirth'),
                            format: 'D-M-YYYY',
                            toString(date, format) {
                                // you should do formatting based on the passed format,
                                // but we will just return 'D/M/YYYY' for simplicity
                                const day = date.getDate();
                                const month = date.getMonth() + 1;
                                const year = date.getFullYear();
                                return `${year}-${month}-${day}`;
                            },
                            parse(dateString, format) {
                                // dateString is the result of `toString` method
                                const parts = dateString.split('/');
                                const day = parseInt(parts[0], 10);
                                const month = parseInt(parts[1], 10) - 1;
                                const year = parseInt(parts[2], 10);
                                return new Date(year, month, day);
                            }
                        });
                    </script>
                </td>
            </tr>
            <tr>
                <td>Email :
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>Phone :
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblFile" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Upload" CssClass="upLabel" runat="server" Text="UpLoad" OnClick="Upload_Click" />
                </td>
                <td><a href="#" class="upLabel" id="btnChangPass" onclick="ChangePass();requiredChangePass();">Change Your Password</a></td>
            </tr>
        </table>
        <%-- Change Pass --%>

        <div id="ChangePass" style="display: none;">
            <table>
                <tr>
                    <td>Old Password :</td>
                    <td>
                        <asp:TextBox ID="OldPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>New Password :</td>
                    <td>
                        <asp:TextBox ID="NewPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password :
                    </td>
                    <td>
                        <asp:TextBox ID="confirmPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Changes" runat="server" OnClick="Change_Click" Text="Accept" />
                        <%--<asp:LinkButton ID="Change" runat="server" OnClick="Change_Click">Accept</asp:LinkButton>--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="imgAvata">
            <asp:Image ID="avata" runat="server" />
        </div>
        <div style="margin-top: 50px;" onclick="requiredUpdateUser();">
            <asp:Button ID="btnSave" CssClass="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </div>

    <%
        if (Session["rule"] != null && Convert.ToInt32(Session["rule"].ToString()) == 3)
        {
    %>
    <asp:Button ID="btnadd" CssClass="btnAdd" runat="server" Text="Add News" OnClick="btnadd_Click" />

    <asp:Repeater ID="rpEmp" runat="server" OnItemCommand="rpEmp_ItemCommand">
        <HeaderTemplate>
            <table class="table-news">
                <tr style="align-content: center">
                    <th>NewsID</th>
                    <th>NewsTitle</th>
                    <th>TypeName</th>
                    <th>NewsImage</th>
                    <th>StartDate</th>
                    <th>AccountName</th>
                    <th>NewsDocx</th>
                    <th>View</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="align-content: center">
                <td><%#Eval ("NewsID")%></td>
                <td><%#Eval ("NewsTitle")%></td>
                <td><%#Eval ("TypeName")%></td>
                <td><%#Eval ("NewsImage")%></td>
                <td><%#Eval ("StartDate")%></td>
                <td><%#Eval ("UserName")%></td>
                <td><%#Eval ("NewsDox")%></td>
                <td>
                    <asp:LinkButton CommandName="ViewNews" CommandArgument='<%# Eval("NewsID") %>' ID="LinkButton1" runat="server">View</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton CommandName="EditNews" CommandArgument='<%# Eval("NewsID") %>' ID="LinkButton2" runat="server">Edit</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton CommandName="DeleteNews" CommandArgument='<%# Eval("NewsID") %>' ID="LinkButton3" runat="server">Delete</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>

    <%
        }
    %>

    <%-- display news user Save --%>

    <%
        if (Session["rule"] != null && Convert.ToInt32(Session["rule"].ToString()) == 2)
        {
    %>
    <asp:Repeater ID="rpDisplaySaveNews" runat="server" OnItemCommand="rpDisplaySaveNews_ItemCommand">
        <ItemTemplate>
            <table class="SaveNews">
                <tr>
                    <td>News :
                        <asp:LinkButton ID="LinkButton4" CommandName="ViewsNewsSave" CommandArgument='<%# Eval("NewsID") %>' runat="server"><%# Eval("NewsTitle") %></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Button ID="Button1" CommandArgument='<%# Eval("NewsID") %>' CommandName="deleteSaveNews" runat="server" Text="Delete" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <%
        }
    %>
</asp:Content>
