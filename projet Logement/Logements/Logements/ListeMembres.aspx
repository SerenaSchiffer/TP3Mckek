<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="ListeMembres.aspx.cs" Inherits="Logements.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col col-sm-9">
        <h1>Liste des Membres</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" EmptyDataText="Aucun membre n'a été ajouté"
        AllowPaging="true" PageSize="10" OnPageIndexChanging = "OnPaging" OnRowDataBound="Gridview1_Databound" onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"></asp:BoundField>
                <asp:BoundField DataField="Courriel" HeaderText="Courriel" SortExpression="Courriel"></asp:BoundField>
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom"></asp:BoundField>
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom"></asp:BoundField>
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" SortExpression="Adresse"></asp:BoundField>
                <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone"></asp:BoundField>
                <asp:CheckboxField DataField="IsAdmin" HeaderText="IsAdmin" SortExpression="IsAdmin"></asp:CheckboxField>
                <asp:CheckboxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"></asp:CheckboxField>
            </Columns>
        </asp:GridView>
    </div>
    <!-- Fenêtre s'ouvrant lors du clic sur une ligne -->
        <div class="modal fade" id="formulaireMembre" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="titreEnvoi">Modifier un Utilisateur</h4>
                    </div>
                    <div class="modal-body">
                            <div class="form-group">
                                <label for="Modal_ID" class="control-label">ID :</label>
                                <input runat="server" type="text" class="form-control" id="Modal_ID" disabled/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_Email" class="control-label">Courriel :</label>
                                <input runat="server" type="text" class="form-control" id="Modal_Email"/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_Prenom" class="control-label">Prenom :</label>
                                <input runat="server" type="text" class="form-control" id="Modal_Prenom"/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_Nom" class="control-label">Nom :</label>
                                <input runat="server" type="text" class="form-control" id="Modal_Nom"/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_Adresse" class="control-label">Adresse :</label>
                                <input runat="server" type="text" class="form-control" id="Modal_Adresse"/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_Telephone" class="control-label">Telephone :</label>
                                <input runat="server" type="text" class="form-control" id="Modal_Telephone"/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_Telephone" class="control-label">IsAdmin :</label>
                                <input runat="server" type="checkbox" class="form-control" id="Modal_IsAdmin"/>
                            </div>
                            <div class="form-group">
                                <label for="Modal_IsActive" class="control-label">IsActive :</label>
                                <input runat="server" type="checkbox" class="form-control" id="Modal_IsActive"/>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">Annuler</button>
                        <asp:Button ID="buttonDelete" runat="server" UseSubmitBehavior="false" CssClass="btn btn-danger" OnClick="openPrompt" Text="Supprimer" />
                        <asp:Button ID="buttonConfirm" runat="server" UseSubmitBehavior="false" CssClass="btn btn-success" OnClick="updateMembre" CommandArgument="0" Text="Mettre à Jour" />
                    </div>
                </div>
            </div>
        </div>
    <!-- Fenêtre s'ouvrant lors du clic sur une ligne -->
        <div class="modal fade" id="deletePrompt" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="deleteUserTitle">Êtes-vous sûr de vouloir effacer cet utilisateur ?</h4>
                    </div>
                    <div class="modal-body">
                            <div class="form-group">
                                <asp:Button ID="cancelDeletion" runat="server" UseSubmitBehavior="false" CssClass="btn btn-info" OnClick="cancelPrompt" Text="Annuler" />
                                <asp:Button ID="confirmDeletion" runat="server" UseSubmitBehavior="false" CssClass="btn btn-danger" OnClick="confirmPrompt" CommandArgument="0" Text="Confirmer la Suppression" />
                            </div>
                    </div>
                    <div class="modal-footer">

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Le lien pour voir la liste des membres est disponible directement à l’accueil du panneau d’Administration.</p>
    <p>Vous pouvez apercevoir rapidement <span class="importantHelp"> toutes les informations </span> sur chaque membre, dont le statut d’administrateur et voir si le membre est actif. Évidemment, <span class="importantHelp">vous ne pouvez pas consulter le mot de passe</span> d’un propriétaire. En <span class="importantHelp">cliquant sur la ligne</span> correspondant à un membre, vous pourrez modifier ses informations. </p>
    <p>Vous pouvez <span class="importantHelp">modifier toutes les informations</span> du propriétaire sauf l’ID et le mot de passe. Vous pouvez le rendre administrateur, actif ou inactif en cochant les cases. <span class="importantHelp">Appuyez sur mettre à jour </span> pour confirmer les changements. <span class="importantHelp">En appuyant sur supprimer</span>, une autre fenêtre de confirmation apparaîtra. </p>
    <p>Évidemment, il ne faut appuyer sur “Confirmer la Suppression” que <span class="importantHelp">si vous voulez absolument supprimer le membre</span> ! Attention, <span class="importantHelp">cette action est irréversible</span>, rendez le membre inactif <span class="importantHelp">si vous voulez une action moins drastique.</span> </p>
</asp:Content>