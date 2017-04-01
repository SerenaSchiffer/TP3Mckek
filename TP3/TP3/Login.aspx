<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP3.Login" %>
<asp:Content ID="DefaultContent" ContentPlaceHolderID="main" runat="server">
        <div class="row">
                  <div class="login-card">
					<h1>Connexion</h1><br/>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnConn">
				        <asp:TextBox ID="txtCourriel" runat="server" placeholder="Courriel"></asp:TextBox>
                        <asp:TextBox ID="txtMDP" runat="server" TextMode="Password" placeholder="Mot de passe"></asp:TextBox>
                        <asp:Button ID="btnConn" runat="server" Text="Connexion" class="login login-submit" Width="100px" OnClick="btnConn_Click"/>
					</asp:Panel>
				</div>      
      	</div>
</asp:Content>