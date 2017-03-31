using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnConn_Click(object sender, EventArgs e)
        {
            string courriel = txtCourriel.Text;
            string mdp = txtMDP.Text;
            Membre membre = MembreFactory.Login(courriel, mdp, ((Logements)Master).CnnStr);
            if (membre != null)
            {
                if (membre.ChgMDP == false)
                {
                    Session[Logements.SESSIONMEMBRE] = membre;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#changeMDP').modal('show');</script>");
                    buttonConfirm.CommandArgument = membre.Id.ToString();
                }
            }
            else
            {
                loginFailed.Visible = true;
                generatedPassword.Visible = false;
                passwordChanged.Visible = false;
            }
        }

        protected void newPassword(object sender, EventArgs e)
        {
            if (Pass.Value == Pass2.Value)
            {
                MembreFactory.changePassword(int.Parse(buttonConfirm.CommandArgument), Pass.Value, ((Logements)Master).CnnStr);
                passwordChanged.Visible = true;
                loginFailed.Visible = false;
                generatedPassword.Visible = false;
            }
        }

        protected void generatePassword(object sender, EventArgs e)
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            MembreFactory.changePassword(myEmail.Value, password, ((Logements)Master).CnnStr);
            EmailFacilitator.sendEmail(myEmail.Value, "Réinitialisation de mot de Passe", "Mot de passe temporaire : " + password);
            loginFailed.Visible = false;
            passwordChanged.Visible = false;
            generatedPassword.Visible = true;
        }
    }
}