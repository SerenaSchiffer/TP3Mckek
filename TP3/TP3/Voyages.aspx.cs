using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class Voyages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            if (Request.QueryString["ID"] != null)
            {
                ID = int.Parse(Request.QueryString["ID"]);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            Voyage voyage = VoyageFactory.GetByID(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, ID);
            lblPrix.Text = voyage.Prix.ToString();
            lblDepart.Text = voyage.Depart;
            lblDestination.Text = voyage.Destination;
            lblHeure.Text = voyage.HeureDepart.ToString();
            lblPassagers.Text = voyage.NbPassagers.ToString();
            chkAnimaux.Checked = voyage.Animaux;
            chkFumeur.Checked = voyage.Fumeur;
            chkEquipe.Checked = voyage.BienEquipe;
        }
    }
}