using System;
using TP3.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TP3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Membre[] conducteurs = MembreFactory.Get(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, "drivers", 0);
                drDownConducteur.DataSource = conducteurs;
                drDownConducteur.DataTextField = "Prenom";
                drDownConducteur.DataValueField = "ID";
                drDownConducteur.DataBind();
            }
        }

        protected void Ajouter_Click(object sender, EventArgs e)
        {
            int idConducteur = int.Parse(drDownConducteur.SelectedItem.Value);
            string depart = txtDepart.Text;
            string destination = txtDestination.Text;
            int nbPassagers;
            bool isNbPassagersDigit = int.TryParse(txtNbPassagers.Text, out nbPassagers);
            double prix;
            bool isPrixDigit = double.TryParse(txtPrix.Text, out prix);
            DateTime heureDepart = calHeureDepart.SelectedDate;
            bool fumeur = ckBoxFumeur.Checked;
            bool animaux = ckBoxAnimaux.Checked;
            bool bcpBagages = ckBoxBcpBagage.Checked;
            
            if (isPrixDigit && isNbPassagersDigit)
            {
                Voyage voyage = new Voyage(0, idConducteur, prix, depart, destination, heureDepart, animaux, fumeur, bcpBagages, nbPassagers);
                VoyageFactory.Save(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, voyage);
                Response.Redirect("Default.aspx");
            }
            else
                lblEnterNumber.Visible = true;
        }
    }
}