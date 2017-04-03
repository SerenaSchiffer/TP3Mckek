using System;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class Voyages : System.Web.UI.Page
    {
        Voyage voyage;
        int ID = 0;
        Membre membre;
        protected void Page_Load(object sender, EventArgs e)
        {
            membre = Session[TP3.SESSIONMEMBRE] as Membre;
            if (membre != null)
            {
                if (membre.IsAdmin)
                {
                    btnDelete.Visible = true;
                }
            }
            if (Request.QueryString["ID"] != null)
            {
                ID = int.Parse(Request.QueryString["ID"]);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            voyage = VoyageFactory.GetByID(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, ID);
            lblPrix.Text = voyage.Prix.ToString();
            lblDepart.Text = voyage.Depart;
            lblDestination.Text = voyage.Destination;
            lblHeure.Text = voyage.HeureDepart.ToString();
            lblPassagers.Text = voyage.NbPassagers.ToString();
            chkAnimaux.Checked = voyage.Animaux;
            chkFumeur.Checked = voyage.Fumeur;
            chkEquipe.Checked = voyage.BienEquipe;
        }

        protected void btnReserver_Click(object sender, EventArgs e)
        {
            if(voyage.NbPassagers >= int.Parse(txtReserve.Text))
            {
                int passager = voyage.NbPassagers - int.Parse(txtReserve.Text);
                VoyageFactory.UpdatePassager(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, passager, ID);
                Reservation reservation = new Reservation(0,membre.Id, ID, int.Parse(txtReserve.Text));
                ReservationFactory.Save(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, reservation);
                Response.Redirect("SearchTrips.aspx");
            }
            else
            {
                NotEnoughPlace.Visible = true;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            VoyageFactory.Delete(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, ID);
            Response.Redirect("SearchTrips.aspx");
        }
    }
}