<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="TP3.Reservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <asp:Repeater ID="Repeater_Voyages" runat="server">
        <ItemTemplate> 
            <div class=" category col col-sm-8">

				    <p>
					    <div class="col col-sm-8">
                            <div class="col-sm-6 left-detail">
                                <b>Numero du Voyage</b> : <%# Eval("IDVoyage")%><br/>
					            <b>Nombre de places réservés</b> : <%# Eval("NbPassager")%><br/>
                            </div>
                        </div>
                        <input type="button"  class="modif btn btn-info" value="Annuler la réservation" onclick="window.location='DeleteReservation.aspx?ID=<%# Eval("ID")%>'"></input>
				    </p>
            </div>  
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
