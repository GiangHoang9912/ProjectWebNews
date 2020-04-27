<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="CommandNews.aspx.cs" Inherits="WebProject.Views.AddNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/AddNews.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="tblAddNews" onmousemove="requiredAddNews();">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Title :
            </td>
            <td>
                <asp:TextBox ID="TitleNews" Width="233px" runat="server"></asp:TextBox>
            </td>
        </tr>   
        <tr>
            <td>Type :
            </td>
            <td>
                <asp:DropDownList ID="listType" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Image : <asp:FileUpload ID="FileUpload2" runat="server" />
            </td>
            <td>
                
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
                <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Start Date :
            </td>
            <td>
                <asp:TextBox ID="StartDate" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Docx : <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                <asp:TextBox ID="filename" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddNews" CssClass="btnSaveAdd" runat="server" Text="Add" OnClick="btnAddNews_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="error" runat="server"></asp:Label><br /><br />
</asp:Content>
