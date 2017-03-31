<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Logements.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col col-sm-9">
        <div class="panel">
        <h1>Logements et résidences Cégep Chicoutimi</h1>
              
        <div class="row">
            <div class="col col-sm-9">
                <img src="images/cal.jpg" class="img-responsive"/>
            </div>
            <div class="col col-sm-3">
                <asp:Button runat="server" ID="btnIns" PostBackUrl="Register.aspx" CssClass="btn btn-info" Text="Pas encore inscrit ?"/><br /><br />
                <asp:Button runat="server" ID="btnConnexion" PostBackUrl="login.aspx" CssClass="btn btn-info" Text="Se connecter"/>
            </div> 
        </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Ceci est la page d'accueil, on peut y trouver <span class="importantHelp">plusieurs liens et boutons</span> permettant d'accéder à plusieurs parties du site. Pour plus d'informations, vous pouvez télécharger <span class="importantHelp">le guide d'utilisateur complet</span> en cliquant sur le bouton en bas à droite.</p>
</asp:Content>