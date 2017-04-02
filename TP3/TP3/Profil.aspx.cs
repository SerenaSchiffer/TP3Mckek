using System;
using System.Configuration;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Membre membre = Session[TP3.SESSIONMEMBRE] as Membre;
            if (!Page.IsPostBack)
            {
                if (membre != null)
                {
                    CheckBoxAnimaux.Checked = membre.IsAnimaux;
                    CheckBoxBienEquipe.Checked = membre.IsEquipe;
                    CheckBoxConducteur.Checked = membre.IsDriver;
                    CheckBoxFumeur.Checked = membre.IsFumeur;
                }
        }
    }
        protected void updateMembre(object sender, EventArgs e)
        {
            Membre membre = Session[TP3.SESSIONMEMBRE] as Membre;
            Membre newvalues = new Membre(membre.Id, membre.Nom, membre.Prenom, membre.Adresse, membre.Telephone, membre.Courriel, "", membre.IsAdmin, CheckBoxConducteur.Checked, CheckBoxFumeur.Checked, CheckBoxAnimaux.Checked, CheckBoxBienEquipe.Checked);
            MembreFactory.update(newvalues, ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString);
            Session[TP3.SESSIONMEMBRE] = newvalues;
            updated.Visible = true;
        }
    }
}