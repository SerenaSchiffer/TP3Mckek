using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Membre proprio = null;
            if (Session[Logements.SESSIONMEMBRE] as Membre == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                proprio = Session[Logements.SESSIONMEMBRE] as Membre;
            }
            if (!Page.IsPostBack)
            {

                Chambre[] chambres;
                chambres = ChambreFactory.Get(((Logements)Master).CnnStr, 0, "", proprio.Id);
                Repeater_Chambres.DataSource = chambres.ToArray();
                Repeater_Chambres.DataBind();

            }
        }
    }
}