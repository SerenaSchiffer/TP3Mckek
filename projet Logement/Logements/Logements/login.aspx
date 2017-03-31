<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Logements.login" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert alert-success col col-sm-9" runat="server" visible="false" id="passwordChanged" role="alert">Votre mot de passe a bien été modifié.</div>
    <div class="alert alert-danger col col-sm-9" runat="server" visible="false" id="loginFailed" role="alert">Votre courriel ou nom d'utilisateur est incorrect.</div>
    <div class="alert alert-info col col-sm-9" runat="server" visible="false" id="generatedPassword" role="alert">Un courriel a été envoyé avec des instructions pour modifier votre mot de passe.</div>

    <div class="row">
                  <div class="login-card">
					<h1>Connexion</h1><br/>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnConn">
				        <asp:TextBox ID="txtCourriel" runat="server" placeholder="Courriel"></asp:TextBox>
                        <asp:TextBox ID="txtMDP" runat="server" TextMode="Password" placeholder="Mot de passe"></asp:TextBox>
                        <asp:Button ID="btnConn" runat="server" Text="Connexion" class="login login-submit" Width="100px" OnClick="btnConn_Click" />
					</asp:Panel>
				  <div class="login-help">
					<li><asp:HyperLink ID="lnkIns" runat="server" NavigateUrl="Register.aspx">Inscription</asp:HyperLink></li> • <a onclick="$('#forgotPassword').modal('show');">J'ai oublié mon mot de passe</a>
				  </div>
				</div>      
      	</div>
    <!-- Fenêtre s'ouvrant lors de la connexion avec un mot de passe temporaire -->
        <div class="modal fade" id="changeMDP" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="titreEnvoi">Entrer un nouveau mot de Passe</h4>
                    </div>
                    <div class="modal-body">
                            <div class="form-group">
                                <label for="Pass" class="control-label">Nouveau mot de Passe :</label>
                                <input runat="server" type="password" class="form-control" id="Pass"/>
                            </div>
                            <div class="form-group">
                                <label for="Pass2" class="control-label">Confirmer le nouveau mot de Passe :</label>
                                <input runat="server" type="password" class="form-control" id="Pass2"/>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Annuler</button>
                        <asp:Button ID="buttonConfirm" runat="server" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="newPassword" CommandArgument="0" Text="Confirmer" />
                    </div>
                </div>
            </div>
        </div>
    <!-- Fenêtre s'ouvrant lors de l'oubli de mot de passe -->
        <div class="modal fade" id="forgotPassword" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Mot de passe Oublié</h4>
                    </div>
                    <div class="modal-body">
                            <div class="form-group">
                                <label for="Pass2" class="control-label">Votre courriel :</label>
                                <input runat="server" type="text" class="form-control" id="myEmail"/>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Annuler</button>
                        <asp:Button ID="button1" runat="server" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="generatePassword" Text="Confirmer" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Une fois sur la page de connexion, il suffit d’entrer son nom d’utilisateur et son mot de passe pour se connecter. <span class="importantHelp">Si vous ne possédez pas encore de compte</span>, vous pouvez vous inscrire grâce au bouton inscription.</p>
    <p>Si vous avez <span class="importantHelp">oublié votre mot de passe</span>, cliquez sur le bouton “J’ai oublié mon mot de passe”</p>
    <img class="img-thumbnail" src="Images/mdpOublie1.PNG" />
    <p>Il suffit d’entrer votre courriel et un nouveau mot de passe temporaire vous sera envoyé par courriel.</p>
    <p>Ensuite, il faut <span class="importantHelp">se reconnecter sur la page</span> connexion avec le mot de passe reçu par courriel.</p>
    <img class="img-thumbnail" src="Images/mdpOublie2.PNG" />
    <p>Vous pouvez ensuite entrer votre nouveau mot de passe.</p>
</asp:Content>