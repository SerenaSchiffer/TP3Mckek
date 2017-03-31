<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Logements.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class ="col col-sm-9">
        <button title="Afficher les paramètres avancés"  class="btn btn-success" type="button" onclick="if(document.getElementById('recherche') .style.display=='none') {document.getElementById('recherche') .style.display=''}else{document.getElementById('recherche') .style.display='none'}">Recherche avancée</button><br />
        <div class="search col col-sm-3" id="recherche" style="display:none">
            <div class="leftSearch">
                    <b>prix</b><br />
                    <asp:TextBox runat="server" ID="txtMin" placeholder="min" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtMax" placeholder="max" TextMode="Number" CssClass="form-control"></asp:TextBox><br />
                    <b>ville</b><br />
                    <asp:TextBox runat="server" ID="txtVille" Width="85px" CssClass="form-control"></asp:TextBox><br />
                <asp:Button runat="server" ID="btnFiltrer" cssClass="btn btn-default filtre" Text="Filtrer" OnClick="btnFiltrer_Click"/>
            </div>
        </div>
        <div class="col-sm-12">
    <asp:Repeater ID="Repeater_Chambres" runat="server">
        <ItemTemplate>
            <div class="category col col-sm-8">
                <hr/>
                <div class="col col-sm-6">
                    <img src="Picture.aspx?Chambre=<%# Eval("Id")%>" class="img-thumbnail">
                </div> 
        		<div class="col col-sm-6">
                    <h2>Info chambre</h2>
				    <p>
					    <b>prix</b> : <%# Eval("Prix")%>$/mois<br/>
					    <b>Adresse</b> : <%# Eval("Adresse")%><br/>
                        <a href="Detail.aspx?ID=<%# Eval("Id")%>"> Voir les détails</a>
				    </p>
                </div> 
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
    </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Il est possible d’effectuer <span class="importantHelp">une recherche avancée</span> en cliquant sur le bouton vert “Recherche avancée”.</p>
    <img src="Images/recherche.png"/>
    <p>Ensuite, cette section s’affiche, on peut donc <span class="importantHelp">entrer un prix minimum/maximum et/ou une ville</span> afin de filtrer la liste de chambre.</p>
</asp:Content>