using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logements.BusinessLogic;

namespace Logements
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["number"] != null)
            {
                Response.ContentType = "image/jpeg";
                byte[] imageBlob = PictureFactory.GetOnePictureBlob(int.Parse(Request.QueryString["number"]), ((Logements)Master).CnnStr);
                Response.BinaryWrite(imageBlob);
            }
            if (Request.QueryString["Chambre"] != null)
            {
                Response.ContentType = "image/jpeg";
                if (PictureFactory.numberOfPictures(int.Parse(Request.QueryString["Chambre"]), ((Logements)Master).CnnStr) != 0)
                {
                    Picture pic = PictureFactory.GetFirstImage(int.Parse(Request.QueryString["Chambre"]), ((Logements)Master).CnnStr);
                    Response.BinaryWrite(pic.ImageData);
                }
                else Response.Redirect("images/defaut_image.gif");
            }
        }
    }
}