<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="Logements.profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-success col col-sm-9" runat="server" visible="false" id="profileChanged" role="alert">Votre profil a bien été modifié.</div>
    <div class="alert alert-danger col col-sm-9" runat="server" visible="false" id="wrongPassword" role="alert">Le mot de passe entré n'est pas valide.</div>
    <div class="alert alert-danger col col-sm-9" runat="server" visible="false" id="passesDontFit" role="alert">Les deux mots de passe ne sont pas identiques.</div>
    <div class="alert alert-success col col-sm-9" runat="server" visible="false" id="passChanged" role="alert">Votre mot de passe a bien été modifié.</div>


    <div class="col col-sm-9">
        <div class="form-group">
            <label for="Txt_ID" class="control-label">ID :</label>
            <input runat="server" type="text" class="form-control" id="Txt_ID" disabled />
        </div>
        <div class="form-group">
            <label for="Txt_Email" class="control-label">Courriel :</label>
            <input runat="server" type="text" class="form-control" id="Txt_Email" disabled />
        </div>
        <div class="form-group">
            <label for="Txt_Prenom" class="control-label">Prenom :</label>
            <input runat="server" type="text" class="form-control" id="Txt_Prenom" />
        </div>
        <div class="form-group">
            <label for="Txt_Nom" class="control-label">Nom :</label>
            <input runat="server" type="text" class="form-control" id="Txt_Nom" />
        </div>
        <div class="form-group">
            <label for="Txt_Adresse" class="control-label">Adresse :</label>
            <input runat="server" type="text" class="form-control" id="Txt_Adresse" />
        </div>
        <div class="form-group">
            <label for="Txt_Telephone" class="control-label">Telephone :</label>
            <input runat="server" type="text" class="form-control" id="Txt_Telephone" />
        </div>
        <asp:Button ID="buttonConfirm" runat="server" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="updateMembre" CommandArgument="0" Text="Mettre à Jour" /><br />
        <br />
        <asp:Button ID="buttonChangePass" runat="server" UseSubmitBehavior="false" CssClass="btn btn-warning" OnClick="changePass" Text="Changer mon Mot de Passe" />
    </div>

    <!-- Fenêtre s'ouvrant lors du changement de mot de passe -->
    <div class="modal fade" id="changeModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="titreEnvoi">Changement de Mot de Passe</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="OldPW" class="control-label">Mot de passe actuel:</label>
                        <input runat="server" type="password" class="form-control" id="OldPW" />
                    </div>
                    <div class="form-group">
                        <label for="NewPW1" class="control-label">Nouveau mot de Passe:</label>
                        <input runat="server" type="password" class="form-control" id="NewPW1" />
                    </div>
                    <div class="form-group">
                        <label for="NewPW2" class="control-label">Confirmer le nouveau mot de Passe:</label>
                        <input runat="server" type="password" class="form-control" id="NewPW2" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">Annuler</button>
                    <asp:Button ID="buttonChangeFinal" runat="server" CssClass="btn btn-success" OnClick="change_final" CommandArgument="0" Text="Modifier mon mot de passe" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>
        Les renseignements se <span class="importantHelp">rempliront automatiquement</span>. Vous pouvez ainsi <span class="importantHelp">modifier les champs</span> qui vous intéressent, sauf l’ID et le Courriel, qui sont grisés et qui ne peuvent donc pas être modifiés. Lorsque les changements sont effectués, vous pouvez cliquer<span class="importantHelp"> sur le bouton “Mettre à jour” </span>afin de valider les modifications.
        Appuyer sur <span class="importantHelp">le bouton “Changer mon Mot de Passe”</span> fera apparaître une fenêtre.
    </p>
    <img class="img-thumbnail" src="Images/mdpProfil.PNG"/>
    <p>
        Vous devrez donc entrer votre mot de passe <span class="importantHelp">actuel</span>, votre <span class="importantHelp">nouveau mot de passe</span> et retaper votre nouveau mot de passe. Finalement, appuyez sur le bouton “Modifier mon mot de passe” afin de confirmer la modification.
    </p>
</asp:Content>