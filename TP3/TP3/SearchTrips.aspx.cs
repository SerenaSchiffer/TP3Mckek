using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP3.BusinessLogic;

namespace TP3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Voyage[] voyages;
            voyages = VoyageFactory.GetAll(System.Configuration.ConfigurationManager.ConnectionStrings["cnnStr"].ConnectionString);
            Repeater_Voyages.DataSource = voyages.ToArray();
            Repeater_Voyages.DataBind();
        }
    }
}