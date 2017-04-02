<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="SearchTrips.aspx.cs" Inherits="TP3.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h2>Listes des voyages</h2>
    <asp:Repeater ID="Repeater_Voyages" runat="server">
        <ItemTemplate> 
            <div class=" category col col-sm-8">

				    <p>
					    <div class="col col-sm-8">
                            <div class="col-sm-6 left-detail">
                                <b>prix</b> : <%# Eval("Prix")%>$/mois<br/>
					            <b>Depart</b> : <%# Eval("Depart")%><br/>
                                <b>Destination</b> : <%# Eval("Destination")%><br/>                          
                                <b>Heure de depart </b> : <%# Eval("HeureDepart")%><br/>
                                <b>Nombre de passagers </b> : <%# Eval("NbPassagers")%><br/>
                            </div>
                            <div class="class-sm-6 right-detail">
                                <b>Animaux acceptés :</b> <input type="checkbox" <%# Convert.ToBoolean(Eval("Animaux")) ? "checked" : "" %> /><br />
                                <b>Fumeur :</b><input type="checkbox" <%# Convert.ToBoolean(Eval("Fumeur")) ? "checked" : "" %> /><br />
                                <b>Place pour des bagages :</b><input type="checkbox" <%# Convert.ToBoolean(Eval("BienEquipe")) ? "checked" : "" %> /><br />
                            </div>
                        </div>
                        <input type="button"  class="modif btn btn-info" value="Afficher le voyage" onclick="window.location='Voyages.aspx?ID=<%# Eval("ID")%>'"></input>
				    </p>
            </div>  
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
