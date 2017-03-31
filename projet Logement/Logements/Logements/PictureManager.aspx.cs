using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logements.BusinessLogic;

namespace Logements
{
    public partial class WebForm5 : System.Web.UI.Page
    {
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

                Chambre chambreModif = ChambreFactory.Get(((Logements)Master).CnnStr, ID, "", 0)[0];

                if (!proprio.IsAdmin && chambreModif.IdMembre != proprio.Id)
                {
                    Response.Redirect("Default.aspx");
                }

                if (!Page.IsPostBack)
                {
                    fillGrid();
                }
            }

            
            protected void fillGrid()
            {
                Picture[] pictures = new Picture[6];
                pictures = PictureFactory.GetImages(int.Parse(Request.QueryString["ID"]), ((Logements)Master).CnnStr);
                PicturesGridView.DataSource = pictures;
                PicturesGridView.DataBind();
            }

            protected void OnPaging(object sender, GridViewPageEventArgs e)
            {
                PicturesGridView.PageIndex = e.NewPageIndex;
                PicturesGridView.DataBind();
            }


            protected void deletePicture(object sender, GridViewDeleteEventArgs e)
            {
                ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#modalDelImage').modal('show');</script>");
                int row = e.RowIndex;
                string id = PicturesGridView.DataKeys[row].Value.ToString();
                Session["imageDelete"] = id;
            }

            protected void confirmDelete(object sender, EventArgs e)
            {
                int id = int.Parse(Session["imageDelete"].ToString());
                PictureFactory.Delete(id, ((Logements)Master).CnnStr);
                fillGrid();
            }

            protected void sendPicture(object sender, EventArgs e)
            {
                int ID = int.Parse(Request.QueryString["ID"]);
                int numb = PictureFactory.numberOfPictures(ID, ((Logements)Master).CnnStr);

                if (numb < 5)
                {
                    byte[] imageData = FileUpload1.FileBytes;
                    PictureFactory.Insert(imageData, ID, ((Logements)Master).CnnStr);
                    fillGrid();
                    pictureAdded.Visible = true;
                    pictureFailed.Visible = false;
                }
                else
                {
                    pictureAdded.Visible = false;
                    pictureFailed.Visible = true;
                }
            }
        }
    }