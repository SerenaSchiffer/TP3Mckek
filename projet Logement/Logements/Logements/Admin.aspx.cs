using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class Admin : System.Web.UI.Page
    {
        Membre membre;
        protected void Page_Load(object sender, EventArgs e)
        {
            membre = Session[Logements.SESSIONMEMBRE] as Membre;
            if (membre != null && membre.IsAdmin)
            {

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}