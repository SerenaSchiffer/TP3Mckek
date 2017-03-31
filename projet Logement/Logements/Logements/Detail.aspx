<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Logements.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col col-sm-9">
        <div class="col col-sm-4">
            <div id="carousel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater ID="Repeater_Caroussel" runat="server">
                        <ItemTemplate>
                            <div class='<%# Container.ItemIndex == 0 ? "item active" : "item" %>'>
                                <img id="Image1" src="Picture.aspx?number=<%# Eval("NoImage")%>" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="left carousel-control" href="#carousel" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                </a>
                <a class="right carousel-control" href="#carousel" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                </a>
            </div>
        </div>
        <div class="col col-sm-8">
            <h2>Info chambre</h2>
            <div class="col-sm-6 left-detail">
                <b>prix :</b>
                <asp:Label ID="lblPrix" runat="server" Text=""></asp:Label><br />
                <b>Adresse :</b>
                <asp:Label ID="lblAdresse" runat="server" Text=""></asp:Label><br />
                <b>Ville :</b>
                <asp:Label ID="lblVille" runat="server" Text=""></asp:Label><br />
                <b>Code postal :</b>
                <asp:Label ID="lblCodePostal" runat="server" Text=""></asp:Label><br />
                <b>Meubles :</b><asp:Label ID="lblMeuble" runat="server" Text=""></asp:Label><br />
                <b>Catégorie :</b>
                <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label><br />
                <b>Quantité :</b>
                <asp:Label ID="lblQuantite" runat="server" Text=""></asp:Label><br />
            </div>
            <div class="class-sm-6 right-detail">
                <b>Animaux acceptés :</b><asp:CheckBox ID="chkAnimaux" runat="server" Enabled="false" /><br />
                <b>Internet :</b><asp:CheckBox ID="chkInternet" runat="server" Enabled="false" /><br />
                <b>Stationnement :</b><asp:CheckBox ID="chkStationnement" runat="server" Enabled="false" /><br />
                <b>Déneigement :</b><asp:CheckBox ID="chkDeneigement" runat="server" Enabled="false" /><br />
                <b>Adapté pour mobilité réduite :</b><asp:CheckBox ID="chkMobile" runat="server" Enabled="false" /><br />
                <b>Fumeur :</b><asp:CheckBox ID="chkFumeur" runat="server" Enabled="false" /><br />
                <b>détails :</b><asp:Label ID="lblDetails" runat="server" Text=""></asp:Label><br />
            </div>
        </div>
        <br />
        <div style="padding-top:20px;position:relative;">
            <div class="col col-sm-8" id="map">
                <!--google maps -->
            </div>
            <div class="col col-sm-4">
                <h2>Info proprio</h2>
                <b>Nom :</b>
                <asp:Label ID="lblNom" runat="server" Text=""></asp:Label><br />
                <b>Téléphone :</b>
                <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label><br />
                <b>Courriel :</b>
                <asp:Label ID="lblCourriel" runat="server" Text=""></asp:Label><br />
            </div>
        </div>
    </div>
    <div class="col col-sm-9" style="text-align: right;">
        <input type="button" id="report" runat="server" class="btn btn-warning" data-toggle="modal" data-target="#modalReport" value="Reporter cette Chambre" />
        <asp:Button runat="server" ID="btnEdit" Visible="false" CssClass="btn btn-info" Text="Modifier" />
        <asp:Button runat="server" ID="btnImage" Visible="false" Text="Gérer les images" class="btn btn-success" PostBackUrl="~/PictureManager.aspx"/>
    </div>

    <!-- Fenêtre s'ouvrant lors d'un signalement -->
    <div class="modal fade" id="modalReport" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="titreEnvoi">Signaler un Abus</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="ZoneTexte" class="control-label">Raison :</label>
                        <textarea id="ZoneTexte" runat="server" class="form-control"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">Annuler</button>
                    <asp:Button ID="buttonConfirm" runat="server" CssClass="btn btn-success" OnClick="report_final" Text="Envoyer le signalement" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="script" ContentPlaceHolderID="scripts" runat="server">
    <script>
        function InitializeMap() {
            var latlng = new google.maps.LatLng(48.419909, -71.060928);
            var myOptions = {
                zoom: 15,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map"), myOptions);

            var geocoder = new google.maps.Geocoder();
            var ville = $('#<%=lblVille.ClientID%>').html();
        var rue = $('#<%=lblAdresse.ClientID%>').html();
        var address = ville + " " + rue;
        var destination;
        if (geocoder) {
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                        map.setCenter(results[0].geometry.location);
                        destination = results[0].geometry.location;
                        var infowindow = new google.maps.InfoWindow(
                            {
                                content: '<b>' + address + '</b>',
                                size: new google.maps.Size(150, 50)
                            });

                        var marker = new google.maps.Marker({
                            position: results[0].geometry.location,
                            map: map,
                            title: address
                        });

                        var latlngCegep = { lat: 48.424369, lng: -71.052742 }
                        var marker2 = new google.maps.Marker({
                            position: latlngCegep,
                            map: map,
                            title: 'Cegep'
                        });
                        google.maps.event.addListener(marker, 'click', function () {
                            infowindow.open(map, marker);
                        });

                    } else {
                        alert("No results found");
                    }
                } else {
                    alert("Geocode was not successful for the following reason: " + status);
                }
            });

            /*directionsService = new google.maps.DirectionsService();   Mettre une route si google maps v3
            directionsDisplay = new google.maps.DirectionsRenderer(
            {
                suppressMarkers: true,
                suppressInfoWindows: true
            });
            directionsDisplay.setMap(map);
            var request = {
                origin: latlng,
                destination: destination,
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                    distance = "The distance between the two points on the chosen route is: " + response.routes[0].legs[0].distance.text;
                    distance += "The aproximative driving time is: " + response.routes[0].legs[0].duration.text;
                    document.getElementById("distance_road").innerHTML = distance;
                    alert(distance);
                }
            });*/

            var distance = latlng.distanceTo(destination);
            alert(distance);
        }
    }
    window.onload = InitializeMap;
    </script>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Ici, vous pouvez <span class="importantHelp">voir les détails</span> d'une chambre, vous pouvez également <span class="importantHelp">signaler une chambre</span> si jamais on voit quelque chose d'inapproprié en cliquant sur le bouton “Reporter une chambre”.</p>
    <img src="Images/abus.png" class="img-thumbnail"/>
    <p>Vous devez ensuite <span class="importantHelp">écrire le motif</span> et cliquer sur le bouton “Envoyer le signalement”.</p>
</asp:Content>