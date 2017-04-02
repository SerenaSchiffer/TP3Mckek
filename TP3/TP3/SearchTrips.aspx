<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="SearchTrips.aspx.cs" Inherits="TP3.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:Repeater ID="Repeater_Voyages" runat="server">
        <ItemTemplate> 
            <div class=" category col col-sm-8">

                    <h2>Info chambre</h2>
				    <p>
					    <div class="col col-sm-8">
                            <h2>Info chambre</h2>
                            <div class="col-sm-6 left-detail">
                                <b>prix :</b>
                                <asp:Label ID="lblPrix" runat="server" Text=""></asp:Label><br />
                                <b>Destination :</b>
                                <asp:Label ID="lblDestination" runat="server" Text=""></asp:Label><br />
                                <b>Depart :</b>                              
                                <asp:Label ID="lblDepart" runat="server" Text=""></asp:Label><br />
                                <b>Heure de depart :</b>
                                <asp:Label ID="lblheure" runat="server" Text=""></asp:Label><br />
                            </div>
                            <div class="class-sm-6 right-detail">
                                <b>Animaux acceptés :</b><asp:CheckBox ID="chkAnimaux" runat="server" Enabled="false" /><br />
                                <b>Fumeur :</b><asp:CheckBox ID="chkFumeur" runat="server" Enabled="false" /><br />
                                <b>Place pour des bagages :</b><asp:CheckBox ID="chkEquipe" runat="server" Enabled="false" /><br />
                            </div>
                        </div>
				    </p>
            </div>  
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
