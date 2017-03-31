using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logements.BusinessLogic
{
    public class ChambreFactory
    {
        public static void Save(string cnnStr, Chambre chambre)
        {
            MySqlConnection connexion = null;
            try
            {

                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                MySqlCommand mySqlCmd = connexion.CreateCommand();
                mySqlCmd.Parameters.Add(new MySqlParameter("@IDMembre", chambre.IdMembre));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Prix", chambre.Prix));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Adresse", chambre.Adresse));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Ville", chambre.Ville));
                mySqlCmd.Parameters.Add(new MySqlParameter("@CodePostal", chambre.CodePostal));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Details", chambre.Details));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Animaux", chambre.Animaux));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Internet", chambre.Internet));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Stationnement", chambre.Stationnement));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Deneigement", chambre.Deneigement));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Meuble", chambre.Meuble));
                mySqlCmd.Parameters.Add(new MySqlParameter("@MobiliteReduite", chambre.MobiliteReduite));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Fumeur", chambre.Fumeur));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Quantite", chambre.Quantite));
                mySqlCmd.Parameters.Add(new MySqlParameter("@category", chambre.Category));
                mySqlCmd.CommandText = ("INSERT INTO chambre(IDMembre,prix,adresse,ville,codePostal,details,animaux,internet,stationnement,deneigement,meuble,mobiliteReduite,fumeur,quantite,category) VALUES(@IDMembre, @Prix, @Adresse, @Ville, @CodePostal, @Details, @Animaux, @Internet, @Stationnement, @Deneigement, @Meuble, @MobiliteReduite, @Fumeur, @Quantite, @Category)");
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }

        }

        public static Chambre[] Get(string cnnStr, int ID, string categoryCh, int IDProprio)
        {
            List<Chambre> chambres = new List<Chambre>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                MySqlCommand mySqlCmd = connexion.CreateCommand();

                if (IDProprio != 0)
                {
                    mySqlCmd.Parameters.Add(new MySqlParameter("@IdProprio", IDProprio));

                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE IDMembre = @IDProprio"; 
                }
                else if (ID == 0 && categoryCh == "")
                {
                    mySqlCmd.CommandText = "SELECT * FROM chambre ORDER BY ID";                  
                }
                else if(categoryCh != "")
                {
                    string categorySQL = convertCategory(categoryCh);
                    mySqlCmd.Parameters.Add(new MySqlParameter("@category", categorySQL));

                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE category=@category";                    
                }
                else
                {
                    mySqlCmd.Parameters.Add(new MySqlParameter("@ID", ID));
                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE ID=@ID";
                   
                }
                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                    {
                        int id = int.Parse(mySqlDataReader["ID"].ToString());
                        int idMembre = int.Parse(mySqlDataReader["IDMembre"].ToString());
                        double prix = double.Parse(mySqlDataReader["prix"].ToString());
                        string adresse = mySqlDataReader["adresse"].ToString();
                        string ville = mySqlDataReader["ville"].ToString();
                        string codePostal = mySqlDataReader["codePostal"].ToString();
                        string details = mySqlDataReader["details"].ToString();
                        bool animaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                        bool internet = bool.Parse(mySqlDataReader["internet"].ToString());
                        bool stationnement = bool.Parse(mySqlDataReader["stationnement"].ToString());
                        bool deneigement = bool.Parse(mySqlDataReader["deneigement"].ToString());
                        int meuble = int.Parse(mySqlDataReader["meuble"].ToString());
                        bool mobiliteReduite = bool.Parse(mySqlDataReader["mobiliteReduite"].ToString());
                        bool fumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                        int quantite = int.Parse(mySqlDataReader["quantite"].ToString());
                        string category = mySqlDataReader["category"].ToString();


                        chambres.Add(new Chambre(id,idMembre,prix,adresse,ville,codePostal,details,animaux,internet,stationnement,deneigement,meuble,mobiliteReduite,fumeur,quantite,category));
                    }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return chambres.ToArray();
        }

        public static Chambre[] Search(string cnnStr, string categoryCh, int min, int max, string villeS)
        {
            List<Chambre> chambres = new List<Chambre>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();

                MySqlCommand mySqlCmd = connexion.CreateCommand();
                string categorySQL = convertCategory(categoryCh);
                mySqlCmd.Parameters.Add(new MySqlParameter("@category", categorySQL));
                mySqlCmd.Parameters.Add(new MySqlParameter("@min", min));
                mySqlCmd.Parameters.Add(new MySqlParameter("@max", max));
                mySqlCmd.Parameters.Add(new MySqlParameter("@ville", villeS));
                if(categoryCh != "" && villeS != "")
                {
                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE category=@category AND (prix BETWEEN @min AND @max) AND (ville LIKE @ville) ";
                }
                else if (categoryCh != "")
                {
                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE category=@category AND (prix BETWEEN @min AND @max)";
                }
                else if (villeS != "")
                {
                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE (prix BETWEEN @min AND @max) AND (ville LIKE @ville)";
                }
                else
                {
                    mySqlCmd.CommandText = "SELECT * FROM chambre WHERE prix BETWEEN @min AND @max";
                }

                mySqlDataReader = mySqlCmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int id = int.Parse(mySqlDataReader["ID"].ToString());
                    int idMembre = int.Parse(mySqlDataReader["IDMembre"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string adresse = mySqlDataReader["adresse"].ToString();
                    string ville = mySqlDataReader["ville"].ToString();
                    string codePostal = mySqlDataReader["codePostal"].ToString();
                    string details = mySqlDataReader["details"].ToString();
                    bool animaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool internet = bool.Parse(mySqlDataReader["internet"].ToString());
                    bool stationnement = bool.Parse(mySqlDataReader["stationnement"].ToString());
                    bool deneigement = bool.Parse(mySqlDataReader["deneigement"].ToString());
                    int meuble = int.Parse(mySqlDataReader["meuble"].ToString());
                    bool mobiliteReduite = bool.Parse(mySqlDataReader["mobiliteReduite"].ToString());
                    bool fumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    int quantite = int.Parse(mySqlDataReader["quantite"].ToString());
                    string category = mySqlDataReader["category"].ToString();


                    chambres.Add(new Chambre(id, idMembre, prix, adresse, ville, codePostal, details, animaux, internet, stationnement, deneigement, meuble, mobiliteReduite, fumeur, quantite, category));
                }
            }           
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return chambres.ToArray();
        }

        public static string convertCategory(string category)
        {
            string categorySQL;
            switch (category)
            {
                case "112":
                    categorySQL = "1 1/2";
                    break;

                case "212":
                    categorySQL = "2 1/2";
                    break;

                case "312":
                    categorySQL = "3 1/2";
                    break;

                case "412":
                    categorySQL = "4 1/2";
                    break;

                case "512":
                    categorySQL = "5 1/2";
                    break;

                default:
                    categorySQL = category;
                    break;

            }

            return categorySQL;
        }

        public static void Update(Chambre chambre, string cnnStr)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            MySqlCommand mySqlCmd = connexion.CreateCommand();

            try
            {
                connexion.Open();
                mySqlCmd.Parameters.Add(new MySqlParameter("@ID", chambre.Id));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Prix", chambre.Prix));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Adresse", chambre.Adresse));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Ville", chambre.Ville));
                mySqlCmd.Parameters.Add(new MySqlParameter("@CodePostal", chambre.CodePostal));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Details", chambre.Details));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Animaux", chambre.Animaux));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Internet", chambre.Internet));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Stationnement", chambre.Stationnement));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Deneigement", chambre.Deneigement));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Meuble", chambre.Meuble));
                mySqlCmd.Parameters.Add(new MySqlParameter("@MobiliteReduite", chambre.MobiliteReduite));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Fumeur", chambre.Fumeur));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Quantite", chambre.Quantite));
                mySqlCmd.Parameters.Add(new MySqlParameter("@category", chambre.Category));

                mySqlCmd.CommandText = ("UPDATE chambre SET prix=@Prix, adresse=@Adresse, ville=@Ville, codePostal=@CodePostal, details=@Details, animaux=@Animaux, internet=@Internet, stationnement=@Stationnement, deneigement=@Deneigement, meuble=@Meuble, mobiliteReduite = @MobiliteReduite, fumeur=@Fumeur, quantite=@Quantite, category=@Category WHERE ID=@ID");
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }
        }
    }
}
