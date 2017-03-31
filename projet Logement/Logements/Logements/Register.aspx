<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Logements.Register" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="alert alert-danger col col-sm-9" runat="server" visible="false" id="registerFailed" role="alert">Ce courriel est déjà utilisé.</div>
              <div class="row">
                  <div class="login-card">
					<h1>Inscription</h1><br />
                    <asp:TextBox ID="txtNom" runat="server" placeholder="Nom"></asp:TextBox>
                    <asp:TextBox ID="txtPrenom" runat="server" placeholder="Prénom"></asp:TextBox>
                    <asp:TextBox ID="txtAdresse" runat="server" placeholder="Adresse"></asp:TextBox>
                    <asp:TextBox ID="txtTelephone" runat="server" placeholder="Téléphone"></asp:TextBox>
                    <asp:TextBox ID="txtCourriel" runat="server" placeholder="Courriel"></asp:TextBox>
                    <asp:TextBox ID="txtMDP" runat="server" TextMode="Password" placeholder="Mot de passe"></asp:TextBox>
                    <asp:TextBox ID="txtMDP2" runat="server" TextMode="Password" placeholder="Confirmation du mot de passe"></asp:TextBox>
                    <asp:Button ID="Envoyer" runat="server" Text="Envoyer" class="login login-submit" Width="100px" OnClick="Envoyer_Click"/>
					<p>Vos informations devront être validées et acceptées par un administrateur avant de pouvoir afficher vos logements</p>
                   </div>
              </div>

					       
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Pour vous inscrire, vous devrez <span class="importantHelp">entrer les renseignements demandés</span>. Cette page d’inscription est<span class="importantHelp"> réservée aux propriétaires</span> souhaitant afficher des chambres et logements sur le site. Vous devez obligatoirement entrer toutes les informations demandées dans les cases correspondantes. Le <span class="importantHelp">courriel doit être entré de façon exacte</span> puisque cela sera votre identifiant afin de pouvoir vous connecter. Les deux cases de mot de passe sont sensibles à la casse et doivent avoir le même mot de passe d’entré.

Quand toutes les informations sont entrées, appuyez sur <span class="importantHelp">le bouton “Envoyer”</span>. Veuillez noter que votre compte ne sera <span class="importantHelp">pas immédiatement accessible </span>et devra être accepté par un administrateur avant d’être utilisable. Vous recevrez un courriel à votre adresse lorsque votre compte aura été accepté. À ce moment, vous pourrez procéder à la connexion et l’ajout de logements.
</p>
</asp:Content>