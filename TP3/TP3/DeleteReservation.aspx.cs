using System;
using System.Configuration;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class DeleteReservation : System.Web.UI.Page
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
                Response.Redirect("SearchTrips.aspx");
            }
            Reservation reservation = ReservationFactory.GetByID(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, ID);
            Voyage voyage = VoyageFactory.GetByID(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, reservation.IdVoyage);
            int nbPassager = voyage.NbPassagers + reservation.NbPassager;
            VoyageFactory.UpdatePassager(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, nbPassager, reservation.IdVoyage);
            ReservationFactory.Delete(ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, ID);
            Response.Redirect("SearchTrips.aspx");
        }
    }
}