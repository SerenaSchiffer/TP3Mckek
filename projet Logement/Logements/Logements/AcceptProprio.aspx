<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="AcceptProprio.aspx.cs" Inherits="Logements.AcceptProprio"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col col-sm-9">
        <h1>Demandes d'Inscription</h1>
        <asp:Repeater ID="Repeater_Demandes" runat="server">
                <ItemTemplate>
                    <div class="demandeInscription row">
                        Nom : <%# Eval("Nom")%><br />
                        Prenom : <%# Eval("Prenom")%><br />
                        Adresse : <%# Eval("Adresse")%><br />
                        Téléphone : <%# Eval("Telephone")%><br />
                        Courriel : <%# Eval("Courriel")%><br />
                        <asp:Button ID="btnAccept" runat="server" Text="Accepter" class="btn btn-success" OnClick="accept_Click" CommandArgument='<%#Eval("Id") %>' />
                        <asp:Button ID="btnRefuse" runat="server" Text="Refuser" class="btn btn-danger" OnClick="refuse_Click" UseSubmitBehavior="false" CommandArgument='<%#Eval("Id") %>'/>
                        <hr />
                    </div>
                </ItemTemplate>
        </asp:Repeater>
        
        <!-- Fenêtre s'ouvrant lors du refus d'une inscription -->
        <div class="modal fade" id="refuseModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="titreEnvoi">Message de Confirmation</h4>
                    </div>
                    <div class="modal-body">
                            <div class="form-group">
                                <label for="ZoneRecipient" class="control-label">Recipient:</label>
                                <input runat="server" type="text" class="form-control" id="ZoneRecipient" disabled/>
                            </div>
                            <div class="form-group">
                                <label for="ZoneTexte" class="control-label">Raison du Refus:</label>
                                <textarea id="ZoneTexte" runat="server" class="form-control"></textarea>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">Annuler</button>
                        <asp:Button ID="buttonConfirm" runat="server" CssClass="btn btn-danger" OnClick="refuse_final" CommandArgument="0" Text="Refuser la demande" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
<p>Le lien pour voir les demandes d’inscription est disponible directement à l’accueil du panneau d’Administration.</p>

<p>À ce moment, vous pouvez apercevoir tous les propriétaires qui ont <span class="importantHelp">envoyé une demande d’inscription </span> sur le site. Deux options s’offrent à vous pour chacun des membres : <span class="importantHelp">l’accepter ou le refuser</span>. Si vous l’accepter, appuyer sur le bouton vert “Accepter” et le membre pourra désormais se connecter sur le site. Si vous appuyer sur “Refuser”, un nouveau formulaire apparaîtra.</p>

<img src="Images/accept.png" class="img-thumbnail"/>

<p>Le récipient se remplira automatiquement selon <span class="importantHelp">le courriel de la personne refusée</span>. Vous devrez entrer une raison pour laquelle vous ne désirez pas l’accepter puis appuyer sur “Refuser la demande”. À ce moment , la personne <span class="importantHelp">sera notifiée de la raison</span> du refus et pourra réessayer de se créer un compte.</p>
</asp:Content>