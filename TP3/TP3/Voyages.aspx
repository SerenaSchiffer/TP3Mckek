<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Voyages.aspx.cs" Inherits="TP3.Voyages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="col col-sm-8">
                            <div class="col-sm-6 left-detail">
                                <b>prix</b> : <asp:Label ID="lblPrix" runat="server" Text="Label"></asp:Label>
					            <b>Depart</b> : <asp:Label ID="lblDepart" runat="server" Text="Label"></asp:Label>
                                <b>Destination</b> : <asp:Label ID="lblDestination" runat="server" Text="Label"></asp:Label>                        
                                <b>Heure de depart </b> : <asp:Label ID="lblHeure" runat="server" Text="Label"></asp:Label>
                                <b>Nombre de places disponibles</b> : <asp:Label ID="lblPassagers" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="class-sm-6 right-detail">
                                <b>Animaux acceptés :</b> <asp:CheckBox ID="chkAnimaux" runat="server" />
                                <b>Fumeur :</b><asp:CheckBox ID="chkFumeur" runat="server" />
                                <b>Place pour des bagages :</b><asp:CheckBox ID="chkEquipe" runat="server" />
                            </div>
                        </div>
                        <asp:TextBox ID="txtReserve" runat="server" TextMode="Number" Text="1"></asp:TextBox> <asp:Button ID="btnReserver" runat="server" Text="Réserver" OnClick="btnReserver_Click" />  
                        <asp:Button ID="btnDelete" runat="server" Text="Annuler le voyage" Visible="false" OnClick="btnDelete_Click"/>
    <div class="alert alert-danger col col-sm-9" runat="server" visible="false" id="NotEnoughPlace" role="alert">Il n'y a pas asez de places disponibles</div>
</asp:Content>