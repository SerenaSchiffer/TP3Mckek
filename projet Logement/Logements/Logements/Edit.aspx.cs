using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logements.BusinessLogic;

namespace Logements
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Chambre chambreModif;
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
            Membre proprio = null;
            if (Session[Logements.SESSIONMEMBRE] as Membre == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                proprio = Session[Logements.SESSIONMEMBRE] as Membre;
            }

            chambreModif = ChambreFactory.Get(((Logements)Master).CnnStr,ID,"",0)[0];

            if(proprio.IsAdmin)
            {
            }
            else if(chambreModif.IdMembre != proprio.Id)
            {
                Response.Redirect("Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                txtPrix.Text = chambreModif.Prix.ToString();
                txtAddresse.Text = chambreModif.Adresse;
                txtVille.Text = chambreModif.Ville;
                txtCodePostal.Text = chambreModif.CodePostal;
                ddlCategory.SelectedValue = chambreModif.Category;
                txtDetails.Text = chambreModif.Details;
                chkAnimaux.Checked = chambreModif.Animaux;
                chkDeneige.Checked = chambreModif.Deneigement;
                chkFumeur.Checked = chambreModif.Fumeur;
                chkInternet.Checked = chambreModif.Internet;
                chkMobile.Checked = chambreModif.MobiliteReduite;
                chkStationnement.Checked = chambreModif.Stationnement;
                btnImage.PostBackUrl = "PictureManager.aspx?ID=" + chambreModif.Id;
            }

        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
                double prix = double.Parse(txtPrix.Text);
                string adresse = txtAddresse.Text;
                string ville = txtVille.Text;
                string codePostal = txtCodePostal.Text;
                string details = txtDetails.Text;
                bool animaux = chkAnimaux.Checked;
                bool internet = chkInternet.Checked;
                bool station = chkStationnement.Checked;
                bool deneigement = chkDeneige.Checked;
                int meuble = 0;
                if (rdM.Checked)
                {
                    meuble = 2;
                }
                else if (rdSM.Checked)
                {
                    meuble = 1;
                }
                else if (rdV.Checked)
                {
                    meuble = 0;
                }

                bool mobile = chkMobile.Checked;
                bool fumeur = chkFumeur.Checked;
                int quantite = int.Parse(txtQuantite.Text);
                string category = ddlCategory.SelectedValue;

                Chambre nouvChambre = new Chambre(chambreModif.Id, chambreModif.IdMembre, prix, adresse, ville, codePostal, details, animaux, internet, station, deneigement, meuble, mobile, fumeur, quantite, category);
                ChambreFactory.Update(nouvChambre, ((Logements)Master).CnnStr);
                Response.Redirect("chambres.aspx");
        }
    }
}