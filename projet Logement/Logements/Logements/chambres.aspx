<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="chambres.aspx.cs" Inherits="Logements.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class ="col col-sm-9">
    <asp:Repeater ID="Repeater_Chambres" runat="server">
        <ItemTemplate> 
            <div class=" category col col-sm-8">
                <hr /> 
                <div class="col col-sm-6">
                    <img src="Picture.aspx?Chambre=<%# Eval("Id")%>" class="img-thumbnail">
                </div> 
        		<div class="col col-sm-6">
                    <h2>Info chambre</h2>
				    <p>
					    <b>prix</b> : <%# Eval("Prix")%>$/mois<br/>
					    <b>Adresse</b> : <%# Eval("Adresse")%><br/>
                        <a href="Detail.aspx?ID=<%# Eval("Id")%>"> Voir les détails</a><br /><br />
                        <input type="button"  class="modif btn btn-info" value="Modifier" onclick="window.location='Edit.aspx?ID=<%# Eval("Id")%>'"></input>
                        <input type="button"  class="btn btn-success" value="Gérer les images" onclick="window.location='PictureManager.aspx?ID=<%# Eval("Id")%>'"></input>
				    </p>
                </div>
            </div>  
        </ItemTemplate>
    </asp:Repeater>
    <div class="col col-sm-8">
    <asp:Button runat="server" ID="btnAjouter" PostBackUrl="~/Add.aspx" CssClass="btn btn-success" Text="Ajouter une chambre"/>
    </div>
    </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Ici, vous pouvez soit <span class="importantHelp">ajouter une chambre, soit modifier les informations</span> sur une chambre en cliquant sur le bouton bleu “modifier” ou bien ajouter/modifier une image en cliquant sur le bouton “Gérer les images”</p>
</asp:Content>
