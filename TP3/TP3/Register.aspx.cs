using System;
using TP3.BusinessLogic;
using System.Configuration;

namespace TP3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Envoyer_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string adresse = txtAdresse.Text;
            string telephone = txtTelephone.Text;
            string courriel = txtCourriel.Text;
            string mdp = txtMDP.Text;
            string mdp2 = txtMDP2.Text;
            bool isDriver = CheckBoxConducteur.Checked;
            bool fumeur = CheckBoxFumeur.Checked;
            bool animaux = CheckBoxAnimaux.Checked;
            bool equipe = CheckBoxBienEquipe.Checked;

            Membre membre = new Membre(0, nom, prenom, adresse, telephone, courriel, mdp, false, isDriver,fumeur,animaux,equipe);
            MembreFactory.Save(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, membre);
            Response.Redirect("Default.aspx");
        }
    }


}