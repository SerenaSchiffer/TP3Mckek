using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["deco"] != null)
            {
                string deco = Request.QueryString["deco"];
                if (deco != null)
                {
                    Session[Logements.SESSIONMEMBRE] = null;
                    Response.Redirect("Default.aspx");

                }
            }
            if(Session[Logements.SESSIONMEMBRE] != null)
            {
                btnConnexion.Visible = false;
                btnIns.Visible = false;
            }
        }
    }
}