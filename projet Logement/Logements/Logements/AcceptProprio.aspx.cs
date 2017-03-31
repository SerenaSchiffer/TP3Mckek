using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logements.BusinessLogic;
using System.Configuration;

namespace Logements
{
    public partial class AcceptProprio : System.Web.UI.Page
    {
        Membre membre;
        protected void Page_Load(object sender, EventArgs e)
        {
            membre = Session[Logements.SESSIONMEMBRE] as Membre;
            if (membre != null && membre.IsAdmin)
            {
                if (!Page.IsPostBack)
                {
                    Membre[] membres;
                    membres = MembreFactory.Get(((Logements)Master).CnnStr, "notAccepted", 0);
                    Repeater_Demandes.DataSource = membres;
                    Repeater_Demandes.DataBind();
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void accept_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).CommandArgument.ToString());
            MembreFactory.Accept(((Logements)Master).CnnStr, id);
            Membre target = (MembreFactory.Get(((Logements)Master).CnnStr, "all", id))[0];
            // Envoyer un courriel
            EmailFacilitator.sendEmail(target.Courriel, "Votre demande d'inscription a été acceptée", "Félicitations, vous pouvez maintenant vous connecter sur le site du cégep");
            Response.Redirect("AcceptProprio.aspx");
        }

        protected void refuse_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).CommandArgument.ToString());
            buttonConfirm.CommandArgument = id.ToString();
            Membre target = (MembreFactory.Get(((Logements)Master).CnnStr, "all", id))[0];
            ZoneRecipient.Value = target.Courriel;
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#refuseModal').modal('show');</script>");
        }

        protected void refuse_final(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).CommandArgument.ToString());
            string messageAEnvoyer = ZoneTexte.InnerText;
            string destinataire = ZoneRecipient.Value;
            // Envoyer un courriel
            EmailFacilitator.sendEmail(destinataire, "Votre demande d'inscription a été refusée", "Votre candidature a malheureusement été refusée pour la raison suivante : " + messageAEnvoyer);
            // Supprimer le membre
            MembreFactory.Delete(((Logements)Master).CnnStr, id);
        }
    }
}