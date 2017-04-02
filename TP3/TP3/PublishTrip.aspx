<%@ Page Title="" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="PublishTrip.aspx.cs" Inherits="TP3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <span>Ajouter un voyage</span>
                </td>
            </tr>
            <tr>
                <td>
                    Conducteur: 
                </td>
                <td>
                    <asp:DropDownList ID="drDownConducteur" runat="server" Width="150"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Lieu de départ: 
                </td>
                <td>
                    <asp:TextBox ID="txtDepart" runat="server" placeholder="Lieu de départ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Destination: 
                </td>
                <td>
                    <asp:TextBox ID="txtDestination" runat="server" placeholder="Destination"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Prix: 
                </td>
                <td>
                    <asp:TextBox ID="txtPrix" runat="server" placeholder="Prix"></asp:TextBox>
                </td>
                <td><asp:Label ID="lblEnterNumber" Visible="false" runat="server">Veuillez rentrez un nombre</asp:Label></td>
            </tr>
            <tr>
                <td>
                    Date départ: 
                </td>
                <td>
                    <asp:Calendar ID="calHeureDepart" runat="server" placeholder="Date départ"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    Préférences:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckBoxAnimaux" runat="server" Text="Animaux"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckBoxFumeur" runat="server" Text="Fumeur"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckBoxBcpBagage" runat="server" Text="Beaucoup de bagages"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre de passager:
                </td>
                <td>
                    <asp:TextBox ID="txtNbPassagers" TextMode="Number" min="1" max="5" runat="server" step="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Ajouter" runat="server" Text="Ajouter" class="login login-submit" Width="100px" OnClick="Ajouter_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
