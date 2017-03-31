<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Logements.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="login-card">
            <h1>Modifier une chambre</h1>
            <br /><br /><br />
            <div class="leftAdd">
                <div>
                    <asp:TextBox ID="txtPrix" runat="server" placeholder="Prix" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    <asp:TextBox ID="txtAddresse" runat="server" placeholder="Adresse"></asp:TextBox>
                    <asp:TextBox ID="txtVille" runat="server" placeholder="Ville"></asp:TextBox>
                    <asp:TextBox ID="txtCodePostal" runat="server" placeholder="Code Postal" MaxLength="6"></asp:TextBox>
                    <b>Catégorie : </b><asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Chambres">Chambres</asp:ListItem>
                        <asp:ListItem Value="1 1/2">1 1/2</asp:ListItem>
                        <asp:ListItem Value="2 1/2">2 1/2</asp:ListItem>
                        <asp:ListItem Value="3 1/2">3 1/2</asp:ListItem>
                        <asp:ListItem Value="4 1/2">4 1/2</asp:ListItem>
                        <asp:ListItem Value="5 1/2">5 1/2</asp:ListItem>
                        <asp:ListItem Value="Maisons">Maisons</asp:ListItem>
                        <asp:ListItem Value="Studio">Studio</asp:ListItem>
                        <asp:ListItem Value="Simple" Enabled="false">Simple</asp:ListItem>
                        <asp:ListItem Value="Double" Enabled="false">Double</asp:ListItem>
                        <asp:ListItem Value="StudioRezz" Enabled="false">Studio résidence</asp:ListItem>
                        
                    </asp:DropDownList>
                <div>
                    <label> Détails(max 255 caractères)</label><br />
                    <asp:TextBox runat="server" ID="txtDetails" Width="100%" TextMode="MultiLine" 
                    onKeyUp="CheckTextLength(this)" onChange="CheckTextLength(this)"></asp:TextBox>                    
                </div>
            </div>
        </div>
        <div class="rightAdd">
            <h1>Options</h1>
            <div>
		        <label>Animaux acceptés</label><br />
                <asp:CheckBox ID="chkAnimaux" runat="server" />
            </div>
            <div>
		        <label>Internet</label><br />
                <asp:CheckBox ID="chkInternet" runat="server" />
            </div>
            <div>
		        <label>Stationnement</label><br />
                <asp:CheckBox ID="chkStationnement" runat="server" />
            </div>
            <div>
		        <label>Déneigement</label><br />
                <asp:CheckBox ID="chkDeneige" runat="server" />
            </div>
            <div>
                <label>Meubles</label><br />
                <asp:RadioButton runat="server" id="rdM" value="2" GroupName="rdMeuble" Checked="true"></asp:RadioButton>Meublé
                <asp:RadioButton runat="server" id="rdSM" value="1" GroupName="rdMeuble"></asp:RadioButton>Semi-meublé
                <asp:RadioButton runat="server" id="rdV" value="0" GroupName="rdMeuble"></asp:RadioButton>Vide

            </div>
            <div>
		        <label>Adapté mobilité réduite</label><br />
                <asp:CheckBox ID="chkMobile" runat="server" />
            </div>
            <div>
		        <label>Fumeurs acceptés</label><br />
                <asp:CheckBox ID="chkFumeur" runat="server" />
            </div>
            <div>
                <label>Quantité des chambres disponibles ( non applicable aux appartements)</label><br />
                <asp:TextBox ID="txtQuantite" runat="server" TextMode="Number" Text="1"></asp:TextBox>
            </div>
        </div>
        <br />
                <asp:Button ID="btnModifier" runat="server" Text="Modifier"  class="btn btn-info btnModifier" OnClick="btnModifier_Click"/>
                <asp:Button ID="btnAnnuler" runat="server" Text="Annuler"  class="btn btn-danger btnModifier" PostBackUrl="~/chambres.aspx"/>

                <asp:Button runat="server" ID="btnImage" Text="Gérer les images" class="btn btn-success" PostBackUrl="~/PictureManager.aspx"/>
     </div>
</asp:Content>
<asp:Content ID="script" ContentPlaceHolderID="scripts" runat="server">
<script>

    function CheckTextLength(text, label) {
        var maxlength = 255; // Change number to your max length.
        if (text.value.length > maxlength) {
            text.value = text.value.substring(0, maxlength);
            alert("Seulement 255 caractères permis");
        }
    }
</script>			
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
    <p>Il suffit maintenant de <span class="importantHelp">changer les champs</span> du formulaire que l’on souhaite modifier. Lorsque les modifications sont terminées, cliquez sur <span class="importantHelp">le bouton bleu</span> “Modifier”. 

Pour annuler la modification, cliquez sur le <span class="importantHelp">bouton rouge “annuler”</span>.

Il est également possible de d’accéder à <span class="importantHelp">la gestion d’image</span> à partir d’ici en cliquant sur le bouton vert “Gérer les images”.
</p>
</asp:Content>
