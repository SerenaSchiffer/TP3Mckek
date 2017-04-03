using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class Reservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Membre membre = Session[TP3.SESSIONMEMBRE] as Membre;
            if (membre != null)
            {
                Reservation[] reservations = ReservationFactory.GetAllById(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString, membre.Id);
                Repeater_Voyages.DataSource = reservations.ToArray();
                Repeater_Voyages.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}