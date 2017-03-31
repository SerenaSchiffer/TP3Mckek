using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class Logements : System.Web.UI.MasterPage
    {
        public const string SESSIONMEMBRE = "Membre";
        private Membre membre;
        private static string _cnnStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            membre = Session[SESSIONMEMBRE] as Membre;
            if (membre != null)
            {
                lnkConn.Visible = false;
                lnkIns.Visible = false;
                lnkAdd.Visible = true;
                lnkDeco.Visible = true;
                lnkMembre.Visible = true;
                lnkMembre.NavigateUrl = "profil.aspx";
                lblMembre.Text = membre.Prenom + " " + membre.Nom;
                if(membre.IsAdmin)
                {
                    AdminPanel.Visible = true;
                }
            }

            
        }

        public string CnnStr
        {
            get
            {
                if (_cnnStr == "")
                    _cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;

                return _cnnStr;
            }
        }

        protected void downloadUserGuide(object sender, EventArgs e)
        {
            Response.ContentType = "APPLICATION/OCTET-STREAM";
            String Header = "Attachment; Filename=Guide.pdf";
            Response.AppendHeader("Content-Disposition", Header);
            System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath("Files/guide.pdf"));
            Response.WriteFile(Dfile.FullName);
            Response.End();
        }
    }
}