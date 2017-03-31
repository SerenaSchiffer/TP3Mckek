using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logements.BusinessLogic;

namespace Logements
{
    public partial class category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string category;
            if (Request.QueryString["category"] != null)
            {
                category = Request.QueryString["category"].ToString();
            }
            else
            {
                category = "";
            }
            if(!Page.IsPostBack)
            {
                Chambre[] chambres;
                chambres = ChambreFactory.Get(((Logements)Master).CnnStr, 0, category, 0);
                Repeater_Chambres.DataSource = chambres.ToArray();
                Repeater_Chambres.DataBind();

            }
        }

        protected void btnFiltrer_Click(object sender, EventArgs e)
        {
            string category;
            if (Request.QueryString["category"] != null)
            {
                category = Request.QueryString["category"].ToString();
            }
            else
            {
                category = "";
            }

            Chambre[] chambres;
            int min, max;
            if (txtMin.Text == "")
            {
                min = 0;
            }
            else
            {
                 int.TryParse(txtMin.Text, out min);
                 txtMin.Text = "";
            }

            if(txtMax.Text == "")
            {
                max = 9999;
            }
            else
            {
                int.TryParse(txtMax.Text, out max);
                txtMax.Text = "";
            }
            string ville = txtVille.Text;
            txtVille.Text = "";
            chambres = ChambreFactory.Search(((Logements)Master).CnnStr, category, min, max, ville);
            Repeater_Chambres.DataSource = chambres.ToArray();
            Repeater_Chambres.DataBind();
            
        }
    }
}