using System;
using TP3.BusinessLogic;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConn_Click(object sender, EventArgs e)
        {
            string courriel = txtCourriel.Text;
            string mdp = txtMDP.Text;
            Membre membre = MembreFactory.Login(courriel, mdp, ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString);
            if (membre != null)
            {
                Session[TP3.SESSIONMEMBRE] = membre;
                Response.Redirect("Default.aspx");
            }
            else
            {
                loginFailed.Visible = true;
            }
        }
    }
}