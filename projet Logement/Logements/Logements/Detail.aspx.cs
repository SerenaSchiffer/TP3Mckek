using Logements.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logements
{
    public partial class Detail : System.Web.UI.Page
    {
        Membre membre;
        Chambre chambre;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            if (Request.QueryString["ID"] != null)
            {
                ID = int.Parse(Request.QueryString["ID"]);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            if (Session[Logements.SESSIONMEMBRE] as Membre != null)
            {
                membre = Session[Logements.SESSIONMEMBRE] as Membre;
            }
            chambre = ChambreFactory.Get(((Logements)Master).CnnStr, ID, "", 0)[0];
            lblPrix.Text = chambre.Prix.ToString();
            lblAdresse.Text = chambre.Adresse;
            lblVille.Text = chambre.Ville;
            lblCodePostal.Text = chambre.CodePostal;
            chkAnimaux.Checked = chambre.Animaux;
            chkInternet.Checked = chambre.Internet;
            chkStationnement.Checked = chambre.Stationnement;
            chkDeneigement.Checked = chambre.Deneigement;
            if(chambre.Meuble == 0)
            {
                lblMeuble.Text = "Vide";
            }
            else if (chambre.Meuble == 1)
            {
                lblMeuble.Text = "Semi-meublé";
            }
            else if (chambre.Meuble == 2)
            {
                lblMeuble.Text = "Meublé";
            }
            chkMobile.Checked = chambre.MobiliteReduite;
            chkFumeur.Checked = chambre.Fumeur;
            lblDetails.Text = chambre.Details;
            lblCategory.Text = chambre.Category;
            lblQuantite.Text = chambre.Quantite.ToString();


            Membre[] proprio = MembreFactory.Get(((Logements)Master).CnnStr, "", chambre.IdMembre);

            lblNom.Text = proprio[0].Prenom + " " + proprio[0].Nom;
            lblCourriel.Text = proprio[0].Courriel;
            lblTelephone.Text = proprio[0].Telephone;

            if (membre != null )
            {
                if(membre.IsAdmin == true || membre.Id == chambre.IdMembre)           
                {
                    btnEdit.Visible = true;
                    btnImage.Visible = true;
                    btnEdit.PostBackUrl = "Edit.aspx?ID=" + chambre.Id;
                    btnImage.PostBackUrl = "PictureManager.aspx?ID=" + chambre.Id;
                }
            }

            /* Caroussel D'images */
            if (!Page.IsPostBack)
            {
                Picture[] pictures = PictureFactory.GetImages(ID,((Logements)Master).CnnStr);
                Repeater_Caroussel.DataSource = pictures;
                Repeater_Caroussel.DataBind();
            }
        }

        protected void report_final(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            Chambre chambre = ChambreFactory.Get(((Logements)Master).CnnStr, ID, "", 0)[0];
            EmailFacilitator.sendEmail("testlogement123@gmail.com", "Report d'abus", "La chambre suivante a été reportée pour la raison suivante : \n ID : " + ID.ToString() + " \n Raison : " + ZoneTexte.Value);
        }
    }
}