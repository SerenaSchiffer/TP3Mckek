using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Membre membre;
        protected void Page_Load(object sender, EventArgs e)
        {
            membre = Session[Logements.SESSIONMEMBRE] as Membre;
            if (membre != null && membre.IsAdmin)
            {
                if (!Page.IsPostBack)
                {
                    showgrid();
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void showgrid()
        {
            Membre[] membres;
            membres = MembreFactory.Get(((Logements)Master).CnnStr, "all", 0);
            GridView1.DataSource = membres;
            GridView1.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void Gridview1_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex.ToString()));
                e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                Membre edited = MembreFactory.Get(((Logements)Master).CnnStr,"",int.Parse(GridView1.SelectedValue.ToString()))[0];
                Modal_ID.Value = edited.Id.ToString();
                Modal_Email.Value = edited.Courriel;
                Modal_Prenom.Value = edited.Prenom;
                Modal_Nom.Value = edited.Nom;
                Modal_Adresse.Value = edited.Adresse;
                Modal_Telephone.Value = edited.Telephone;
                Modal_IsAdmin.Checked = edited.IsAdmin;
                Modal_IsActive.Checked = edited.IsActive;
                buttonConfirm.CommandArgument = edited.Id.ToString();
                confirmDeletion.CommandArgument = edited.Id.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#formulaireMembre').modal('show');</script>");
            }
        }

        protected void openPrompt(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script>$('#deletePrompt').modal('show');</script>");
        }


        protected void cancelPrompt(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script>$('#formulaireMembre').modal('show');</script>");
        }

        protected void confirmPrompt(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).CommandArgument.ToString());
            MembreFactory.Delete(((Logements)Master).CnnStr, id);
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script>$('#deletePrompt').modal('hide');</script>");
            showgrid();
        }

        protected void updateMembre(object sender, EventArgs e)
        {
            Membre updated = new Membre(int.Parse(Modal_ID.Value), Modal_Nom.Value, Modal_Prenom.Value, Modal_Adresse.Value, Modal_Telephone.Value, Modal_Email.Value, "", Modal_IsAdmin.Checked, Modal_IsActive.Checked, true);
            MembreFactory.update(updated, ((Logements)Master).CnnStr);
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script>$('#formulaireMembre').modal('hide');</script>");
            showgrid();
        }


    }
}