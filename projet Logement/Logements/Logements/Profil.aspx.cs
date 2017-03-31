using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class profil : System.Web.UI.Page
    {
        Membre membre;
        protected void Page_Load(object sender, EventArgs e)
        {
            membre = Session[Logements.SESSIONMEMBRE] as Membre;
            if (membre != null)
            {
                if (!Page.IsPostBack)
                {
                    int id = membre.Id;
                    Membre membreUpToDate = MembreFactory.Get(((Logements)Master).CnnStr, "", id)[0];
                    Txt_ID.Value = membreUpToDate.Id.ToString();
                    Txt_Email.Value = membreUpToDate.Courriel;
                    Txt_Nom.Value = membreUpToDate.Nom;
                    Txt_Prenom.Value = membreUpToDate.Prenom;
                    Txt_Telephone.Value = membreUpToDate.Telephone;
                    Txt_Adresse.Value = membreUpToDate.Adresse;
                    buttonConfirm.CommandArgument = id.ToString();
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void updateMembre(object sender, EventArgs e)
        {
            Membre membre = Session[Logements.SESSIONMEMBRE] as Membre;
            Membre updated = new Membre(int.Parse(buttonConfirm.CommandArgument), Txt_Nom.Value, Txt_Prenom.Value, Txt_Adresse.Value, Txt_Telephone.Value, Txt_Email.Value, "", membre.IsAdmin, membre.IsActive, membre.ChgMDP);
            MembreFactory.update(updated, ((Logements)Master).CnnStr);
            profileChanged.Visible = true;
        }

        protected void changePass(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#changeModal').modal('show');</script>");
            buttonChangeFinal.CommandArgument = Txt_ID.Value;
        }

        protected void change_final(object sender, EventArgs e)
        {
            string oldPass = OldPW.Value;
            string newPass1 = NewPW1.Value;
            string newPass2 = NewPW2.Value;
            if(newPass1 != newPass2)
            {
                passesDontFit.Visible = true;
                wrongPassword.Visible = false;
                return;
            }
            Membre membre = Session[Logements.SESSIONMEMBRE] as Membre;
            Membre working = MembreFactory.Login(membre.Courriel, oldPass, ((Logements)Master).CnnStr);
            if(working != null)
            {
                MembreFactory.changePassword(membre.Id, newPass1, ((Logements)Master).CnnStr);
                passChanged.Visible = true;
                passesDontFit.Visible = false;
                wrongPassword.Visible = false;
                return;
            }
            else
            {
                wrongPassword.Visible = true;
                passesDontFit.Visible = false;
                return;
            }
        }
    }
}