<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebProject.Views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Register-content" onmousemove="requiredCreateAccount();">
        <h1>Tạo tài khoản mới</h1>
        <h4>Nhanh chóng và dễ dàng.</h4>
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
                <td>Account Name :
                </td>
                <td>
                    <asp:TextBox ID="Account" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>Password :
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>Confirm Password :
                </td>
                <td>
                    <asp:TextBox ID="Confirm" runat="server" TextMode="Password"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="ImgShow" runat="server" Text="UpLoad" OnClick="Upload_Click" />
                    <asp:Label ID="lblFile" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <div class="imgAvatar">
                        <asp:Image ID="avatar" runat="server" />
                        <asp:Button ID="Button1" Width="170px" runat="server" Text="Create Account" OnClick="Button1_Click" style="height: 26px" />

                    </div>

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
