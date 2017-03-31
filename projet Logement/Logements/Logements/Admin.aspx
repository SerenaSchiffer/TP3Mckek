<%@ Page Title="" Language="C#" MasterPageFile="./Logements.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Logements.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Panneau d'Administration</h2>
    <div class="col col-sm-9">
        <a href="AcceptProprio.aspx">Voir les demandes d'Inscription</a><br />
        <a href="ListeMembres.aspx">Voir la liste des membres</a>
    </div>
</asp:Content>
<asp:Content ID="helpContent" ContentPlaceHolderID="helpContent" runat="server">
<p>À partir d'ici, vous pouvez <span class="importantHelp">choisir un lien du panneau d'administration</span>, pour soit gérer les demandes d'inscriptions, soit voir la liste des membres</p>
</asp:Content>