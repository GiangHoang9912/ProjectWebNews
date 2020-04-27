<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Header.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebProject.Views.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Set the size of the div element that contains the map */
        #map {
            border: 1px solid black;
            height: 300px; /* The height is 400 pixels */
            width: 100%; /* The width is the width of the web page */
        }

        table {
            margin: auto;
        }

        .content {
            padding-top: 50px;
            margin: 30px;
        }

        .sendForUs {
            margin-top: 30px;
            margin-left: 30px;
        }

        .btnSend {
           height : 30px;
        }

        table td {
            width: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sendForUs">
        E-mail address: :<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        Message :<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="265px" TextMode="MultiLine" Width="995px"></asp:TextBox><br />
        <asp:Button CssClass="btnSend" ID="Button1" runat="server" Text="Send For Us" />
    </div>
    <div class="content">
        <div class="Contact">
            <h3>Where We Are : </h3>
            <table>
                <tr>
                    <td>Name :
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Address :
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Email :
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Phone :
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Opening Hour :
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Opening Days :
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <!--The div element for the map -->
        <div id="map"></div>
        <script>
            // Initialize and add the map
            function initMap() {
                // The location of Uluru 21.425711, 105.878815
                var uluru = { lat: 21.425711, lng: 105.878815 };
                // The map, centered at Uluru
                var map = new google.maps.Map(
                    document.getElementById('map'), { zoom: 12, center: uluru });
                // The marker, positioned at Uluru
                var marker = new google.maps.Marker({ position: uluru, map: map });
            }
        </script>
        <!--Load the API from the specified URL
    * The async attribute allows the browser to render the page while the API loads
    * The key parameter will contain your own API key (which is not needed for this tutorial)
    * The callback parameter executes the initMap() function
    -->
        <script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBduqdqndTQ4nZr8d9vDkPT8bIZqoN6D4I&callback=initMap">
        </script>
    </div>
</asp:Content>
