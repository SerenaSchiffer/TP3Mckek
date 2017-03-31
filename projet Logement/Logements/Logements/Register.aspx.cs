using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
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

                bool exists = MembreFactory.checkIfExists(((Logements)Master).CnnStr, courriel);  // Vérifie si le courriel est déjà utilisé
                if (!exists)
                {
                    Membre membre = new Membre(0, nom, prenom, adresse, telephone, courriel, mdp, false, false, false);
                    MembreFactory.Save(((Logements)Master).CnnStr, membre);
                    EmailFacilitator.sendEmail("testlogement123@gmail.com", "Nouveau membre inscrit", "Un nouveau membre s'est inscrit sur le site des logements");
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    registerFailed.Visible = true;
                }
        }
    }
}