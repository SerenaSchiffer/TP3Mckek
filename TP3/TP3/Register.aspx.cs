using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            //Membre membre = new Membre(0, nom, prenom, adresse, telephone, courriel, mdp, false, false, false);
            //MembreFactory.Save(((Logements)Master).CnnStr, membre);
            Response.Redirect("Default.aspx");
        }
    }


}