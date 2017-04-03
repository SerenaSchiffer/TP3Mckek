using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Voyage[] voyages;
                voyages = VoyageFactory.GetAll(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString);
                Repeater_Voyages.DataSource = voyages.ToArray();
                Repeater_Voyages.DataBind();
            }
            
        }

        protected void Rechercher_Click(object sender, EventArgs e)
        {
            string depart;
            string destination;
            bool fumeur;
            bool animaux;
            bool bienEquipe;
            DateTime dateDebut;
            DateTime dateFin;
            
            depart = txtDepart.Text;
            destination = txtDestination.Text;
            fumeur = ckBoxFumeur.Checked;
            animaux = ckBoxAnimaux.Checked;
            bienEquipe = ckBoxBcpBagage.Checked;
            dateDebut = calDebut.SelectedDate;
            dateFin = calFin.SelectedDate;

            Voyage[] voyages = VoyageFactory.Search(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, fumeur, animaux, bienEquipe, depart, destination, dateDebut, dateFin);
            Repeater_Voyages.DataSource = voyages.ToArray();
            Repeater_Voyages.DataBind();
        }
    }
}