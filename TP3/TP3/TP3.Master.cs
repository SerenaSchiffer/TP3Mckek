using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3
{
    public partial class TP3 : System.Web.UI.MasterPage
    {
        public const string SESSIONMEMBRE = "Membre";
        protected void Page_Load(object sender, EventArgs e)
        {
            string logout = Request["deco"];
            if (logout != null)
                return;//TODO: Log-out user
        }
    }
}