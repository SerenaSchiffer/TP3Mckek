using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logements.BusinessLogic
{
    public class Picture
    {
        private int _noImage;
        public int NoImage
        {
            get { return _noImage; }
            set { _noImage = value; }
        }


        private int _noChanbre;
        public int IdChambre
        {
            get { return _noChanbre; }
            set { _noChanbre = value; }
        }


        private byte[] _imageData;
        public byte[] ImageData
        {
            get { return _imageData; }
            set { _imageData = value; }
        }


        public Picture(int noImage, int noChambre, byte[] imageBlob)
        {
            NoImage = noImage;
            IdChambre = noChambre;
            ImageData = imageBlob;
        }
    }
}
