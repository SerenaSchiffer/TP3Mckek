<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP3.Profil" %>
<asp:Content ID="ContentRegister" ContentPlaceHolderID="main" runat="server">
    <div class="alert alert-success col col-sm-9" runat="server" visible="false" id="updated" role="alert">Vos informations ont été mises à jour.</div>
              <div class="row">
                
                  <div class="login-card">
					<h1>Mes Préférences</h1><br />
                    <asp:CheckBox ID="CheckBoxConducteur" runat="server" /> Je serai un conducteur<br />
                    <asp:CheckBox ID="CheckBoxFumeur" runat="server" /> Je suis fumeur<br />
                    <asp:CheckBox ID="CheckBoxAnimaux" runat="server" /> J'accepte les animaux<br />
                    <asp:CheckBox ID="CheckBoxBienEquipe" runat="server" /> J'ai beaucoup de bagages<br />
                    <asp:Button ID="Envoyer" runat="server" Text="Mettre à Jour" class="login login-submit" Width="100px" OnClick="updateMembre"/>
                   </div>
              </div>
</asp:Content>