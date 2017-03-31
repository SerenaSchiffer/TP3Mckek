using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logements.BusinessLogic
{
    public static class PictureFactory
    {
        public static Picture[] GetImages(int noChambre, string cnnString)
        {
            List<Picture> lines = new List<Picture>();
            MySql.Data.MySqlClient.MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.Parameters.Add(new MySqlParameter("@IDChambre", noChambre));
                mySqlCmd.CommandText = "SELECT * FROM image WHERE IDChambre = @IDChambre";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    int noImage = int.Parse(mySqlDataReader["ID"].ToString());
                    byte[] imageBlob = (byte[])mySqlDataReader["image"];

                    lines.Add(new Picture(noImage, noChambre, imageBlob));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
            return lines.ToArray();
        }

        public static Picture GetFirstImage(int noChambre, string cnnString)
        {
            Picture image = null;
            MySql.Data.MySqlClient.MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.Parameters.Add(new MySqlParameter("@IDChambre", noChambre));
                mySqlCmd.CommandText = "SELECT * FROM image WHERE IDChambre = @IDChambre ORDER BY ID";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                mySqlDataReader.Read();
                int noImage = int.Parse(mySqlDataReader["ID"].ToString());
                byte[] imageBlob = (byte[])mySqlDataReader["image"];
                image = new Picture(noImage, noChambre, imageBlob);
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
            return image;
        }


        public static byte[] GetOnePictureBlob(int noImage, string cnnString)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;
            byte[] imageBlob = null;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.Parameters.Add(new MySqlParameter("@IDImage", noImage));
                mySqlCmd.CommandText = "SELECT image FROM image WHERE ID = @IDImage";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                mySqlDataReader.Read();
                imageBlob = (byte[])mySqlDataReader["image"];
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
            return imageBlob;
        }
        
        public static int numberOfPictures(int noChambre, string cnnString)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;
            int number = 0;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.Parameters.Add(new MySqlParameter("@IDChambre", noChambre));
                mySqlCmd.CommandText = "SELECT count(image) FROM image WHERE IDChambre =  @IDChambre";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                mySqlDataReader.Read();
                number = int.Parse(mySqlDataReader["count(image)"].ToString());
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
            return number;
        }

        public static void Insert(byte[] imageData, int noChambre, string cnnString)
        {
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO image (IDChambre, image) VALUES (@IDChambre, @Image);";
                mySqlCmd.Parameters.Add(new MySqlParameter("@Image", imageData));
                mySqlCmd.Parameters.Add(new MySqlParameter("@IDChambre", noChambre));
                mySqlCmd.ExecuteScalar();
            }
            finally
            {
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
        }


        public static void Update(byte[] imageData, int imageNumber, string cnnString)
        {
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "UPDATE image SET image = @Image_Data WHERE ID = @noImage";
                mySqlCmd.Parameters.Add(new MySqlParameter("@Image_Data", imageData));
                mySqlCmd.Parameters.Add(new MySqlParameter("@noImage", imageNumber));
                mySqlCmd.ExecuteScalar();
            }
            finally
            {
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
        }

        public static void Delete(int imageNumber, string cnnString)
        {
            MySqlConnection mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(cnnString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM image WHERE ID = @noImage";
                mySqlCmd.Parameters.Add(new MySqlParameter("@noImage", imageNumber));
                mySqlCmd.ExecuteScalar();
            }
            finally
            {
                if (mySqlCnn != null)
                    mySqlCnn.Close();
            }
        }
    }
}
