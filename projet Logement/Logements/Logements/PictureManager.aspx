<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="PictureManager.aspx.cs" Inherits="Logements.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-success col col-sm-9" runat="server" visible="false" id="pictureAdded" role="alert">Votre image a bien été ajoutée.</div>
    <div class="alert alert-danger col col-sm-9" runat="server" visible="false" id="pictureFailed" role="alert">Vous avez déjà 5 images pour la chambre.</div>
    <div class="col col-sm-9">
        <asp:GridView
            ID="PicturesGridView"
            runat="server"
            AutoGenerateColumns="FALSE"
            EmptyDataText="Aucune image n'a été ajoutée"
            EmptyDataRowStyle-BorderColor="White"
            AllowPaging="true"
            BorderColor="White"
            OnPageIndexChanging="OnPaging"
            DataKeyNames="NoImage"
            OnRowDeleting="deletePicture">
            <Columns>
                <asp:ImageField ControlStyle-Width="500px" HeaderText="Image" DataImageUrlField="NoImage" DataImageUrlFormatString="Picture.aspx?number={0}"></asp:ImageField>
                <asp:CommandField ControlStyle-CssClass="btn btn-danger"  ShowDeleteButton="True" CausesValidation="False" ButtonType="Button"></asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
        <input type="button" id="report" runat="server" class="btn btn-primary" data-toggle="modal" data-target="#modalAddImage"  value="Ajouter une image" />
    </div>

    <!-- Fenêtre s'ouvrant lors d'un ajout d'image -->
    <div class="modal fade" id="modalAddImage" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="titreEnvoi">Ajouter une Image</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:FileUpload ID="FileUpload1"  runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Annuler</button>
                    <asp:Button ID="buttonConfirm" runat="server" CssClass="btn btn-success" OnClick="sendPicture" Text="Ajouter l'Image" />
                </div>
            </div>
        </div>
    </div>

    <!-- Fenêtre s'ouvrant lors d'une suppression d'image -->
    <div class="modal fade" id="modalDelImage" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="tireDelete">Supprimer cette image ?</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <p>Êtes-vous certain de vouloir supprimer cette image ?</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Annuler</button>
                    <asp:Button ID="buttonDelete" runat="server" CssClass="btn btn-success" CommandArgument="0" OnClick="confirmDelete" Text="Supprimer l'Image" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Pour ajouter une image, appuyez sur le bouton “Ajouter une image” pour en <span class="importantHelp">ajouter une nouvelle</span>.</p>
    <img class="img-thumbnail" src="Images/getImage.png" />
    <p>Il ne reste plus qu’à <span class="importantHelp">sélectionner une image</span> en appuyant sur “Choisissez un fichier”, puis de naviguer sur votre ordinateur avec <span class="importantHelp">l’explorateur qui apparaîtra</span>. Vous pouvez choisir une image au format .jpg, .png, .gif ou .bmp, d’une <span class="importantHelp">limite de 2 Mo</span>.  Enfin, vous pourrez appuyer sur “Ajouter l’image” pour confirmer l’importation. Prenez note qu’il y a un <span class="importantHelp">maximum de 5 images</span> par chambre affichée !</p>
    <img class="img-thumbnail" src="Images/deleteImage.png" />
    <p>Vous pouvez aisément appuyer sur “Delete” puis “Supprimer l’image” pour <span class="importantHelp">supprimer l’image</span> qui est entrée avec la chambre.</p>
    <img class="img-thumbnail" src="Images/deleteImage2.png" />
    <p>La première image entrée sera <span class="importantHelp">l’image principale</span> de la chambre et apparaîtra en premier pour les gens qui naviguent sur le site.</p>
</asp:Content>