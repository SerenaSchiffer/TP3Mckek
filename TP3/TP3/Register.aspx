<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TP3.Register" %>
<asp:Content ID="ContentRegister" ContentPlaceHolderID="main" runat="server">
              <div class="row">
                  <div class="login-card">
					<h1>Inscription</h1><br />
                    <asp:TextBox ID="txtNom" runat="server" placeholder="Nom"></asp:TextBox><br />
                    <asp:TextBox ID="txtPrenom" runat="server" placeholder="Prénom"></asp:TextBox><br />
                    <asp:TextBox ID="txtAdresse" runat="server" placeholder="Adresse"></asp:TextBox><br />
                    <asp:TextBox ID="txtTelephone" runat="server" placeholder="Téléphone"></asp:TextBox><br />
                    <asp:TextBox ID="txtCourriel" runat="server" placeholder="Courriel"></asp:TextBox><br />
                    <asp:TextBox ID="txtMDP" runat="server" TextMode="Password" placeholder="Mot de passe"></asp:TextBox><br />
                    <asp:TextBox ID="txtMDP2" runat="server" TextMode="Password" placeholder="Confirmation du mot de passe"></asp:TextBox><br />
                    <asp:RadioButton ID="conducteur" runat="server" /> Je serai un conducteur<br />
                    <asp:Button ID="Envoyer" runat="server" Text="Envoyer" class="login login-submit" Width="100px" OnClick="Envoyer_Click"/>
                   </div>
              </div>

					       
</asp:Content>