using TP3.BusinessLogic;
using System;
using System.Web.UI;

namespace TP3
{
    public partial class TP3 : System.Web.UI.MasterPage
    {
        public const string SESSIONMEMBRE = "Membre";
        private Membre membre;
        protected void Page_Load(object sender, EventArgs e)
        {
            string logout = Request.QueryString["deco"];
            if (logout != null)
                Session[TP3.SESSIONMEMBRE] = null;
            membre = Session[SESSIONMEMBRE] as Membre;
            
            if (membre != null) // Ajuster UI pour membre login
            {
                lnkCancel.Visible = true;
                lnkDeco.Visible = true;
                lnkSearch.Visible = true;
                lnkIns.Visible = false;
                lnkConn.Visible = false;
                lnkPublish.Visible = membre.IsDriver;
                lnkPropos.Visible = true;
            }
        }
    }
}