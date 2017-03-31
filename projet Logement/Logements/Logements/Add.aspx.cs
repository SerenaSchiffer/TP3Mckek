using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class Add : System.Web.UI.Page
    {
        Membre membreConnecte;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Logements.SESSIONMEMBRE] as Membre == null)
            {
                Response.Redirect("Default.aspx");

            }
            else
            {
                membreConnecte = Session[Logements.SESSIONMEMBRE] as Membre;
            }
            if(membreConnecte.IsAdmin)
            {
                ddlCategory.Items.FindByValue("Simple").Enabled = true;
                ddlCategory.Items.FindByValue("Double").Enabled = true;
                ddlCategory.Items.FindByValue("StudioRezz").Enabled = true;
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            int idMembre = membreConnecte.Id;
            double prix = double.Parse(txtPrix.Text);
            string adresse = txtAddresse.Text;
            string ville = txtVille.Text;
            string codePostal = txtCodePostal.Text;
            string details = txtDetails.Text;
            bool animaux = chkAnimaux.Checked;
            bool internet = chkInternet.Checked;
            bool stationnement = chkStationnement.Checked;
            bool deneigement = chkDeneige.Checked;
            int meuble = 0;
            if(rdM.Checked)
            {
                meuble = 2;
            }
            else if (rdSM.Checked)
            {
                meuble = 1;
            }
            else if(rdV.Checked)
            {
                meuble = 0;
            }
            bool mobiliteReduite = chkMobile.Checked;
            bool fumeur = chkFumeur.Checked;
            int quantite = int.Parse(txtQuantite.Text);
            string category = ddlCategory.SelectedValue.ToString();

            Chambre chambre =  new Chambre(0,idMembre,prix,adresse,ville,codePostal,details,animaux,internet,stationnement,deneigement,meuble,mobiliteReduite,fumeur,quantite,category);

            ChambreFactory.Save(((Logements)Master).CnnStr, chambre);

            Response.Redirect("Default.aspx");
        }
    }
}