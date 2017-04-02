using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP3.businessLogic
{
    class VoyageFactory
    {
        public static void Save(string connexionString, Voyage voyage)
        {
            MySqlConnection connexion = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();
                command.Parameters.Add(new MySqlParameter("@Id", voyage.Id));
                command.Parameters.Add(new MySqlParameter("@IdConducteur", voyage.IdConducteur));
                command.Parameters.Add(new MySqlParameter("@Prix", voyage.Prix));
                command.Parameters.Add(new MySqlParameter("@Depart", voyage.Depart));
                command.Parameters.Add(new MySqlParameter("@Destination", voyage.Destination));
                command.Parameters.Add(new MySqlParameter("@HeureDepart", voyage.HeureDepart));
                command.Parameters.Add(new MySqlParameter("@Animaux", voyage.Animaux));
                command.Parameters.Add(new MySqlParameter("@Fumeur", voyage.Fumeur));
                command.Parameters.Add(new MySqlParameter("@BienEquipe", voyage.BienEquipe));
                command.Parameters.Add(new MySqlParameter("@NbPassagers", voyage.NbPassagers));

                command.CommandText = ("INSERT INTO voyage (ID, IDConducteur, prix, depart, destination, heureDepart, animaux, fumeur, bienEquipe, NbPassager) VALUES (@ID, @IDConducteur, @Prix, @Depart, @Destination, @HeureDepart, @Animaux, @Fumeur, @BienEquipe, @NbPassager");
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }
        }

        public static Voyage[] GetByIDConducteur(string connexionString, int idConducteur)
        {
            List<Voyage> voyages = new List<Voyage>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();
                
                command.Parameters.Add(new MySqlParameter("@IDConducteur", idConducteur));

                command.CommandText = "SELECT * FROM voyage WHERE IDConducteur = @IDConducteur";
                mySqlDataReader = command.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int id = int.Parse(mySqlDataReader["ID"].ToString());
                    int lIdConducteur = int.Parse(mySqlDataReader["IDConducteur"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string lDepart = mySqlDataReader["depart"].ToString();
                    string lDestination = mySqlDataReader["destination"].ToString();
                    DateTime heureDepart = (DateTime)mySqlDataReader["heureDepart"];
                    bool lAnimaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool lFumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    bool lBienEquipe = bool.Parse(mySqlDataReader["bienEquipe"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["NbPassagers"].ToString());

                    voyages.Add(new Voyage(id, lIdConducteur, prix, lDepart, lDestination, heureDepart, lAnimaux, lFumeur, lBienEquipe, nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return voyages.ToArray();
        }

        public static Voyage[] Search(string connexionString, bool fumeur, bool animaux, bool bienEquipe, string depart, string destination,
                                      DateTime heureDebut, DateTime heureFin)
        {
            List<Voyage> voyages = new List<Voyage>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();

                command.Parameters.Add(new MySqlParameter("@Fumeur", fumeur));
                command.Parameters.Add(new MySqlParameter("@Animaux", animaux));
                command.Parameters.Add(new MySqlParameter("@BienEquipe", bienEquipe));
                command.Parameters.Add(new MySqlParameter("@Depart", depart));
                command.Parameters.Add(new MySqlParameter("@Destination", destination));
                command.Parameters.Add(new MySqlParameter("@HeureDebut", heureDebut));
                command.Parameters.Add(new MySqlParameter("@HeureFin", heureFin));

                string commandText = "SELECT * FROM voyage WHERE animaux = @Animaux AND fumeur = @Fumeur AND bienEquipe = @BienEquipe ";
                if (depart != String.Empty)
                    commandText += "AND depart = @Depart ";

                if (destination != String.Empty)
                    commandText += "AND destination = @Destination ";

                if (heureDebut != null && heureFin != null)
                    commandText += "AND heureDepart BETWEEN @HeureDebut AND @HeureFin ";
                else if (heureDebut != null && heureFin == null)
                    commandText += "AND heureDepart >= @HeureDebut ";
                else if (heureDebut == null && heureFin != null)
                    commandText += "AND heureDepart <= @HeureFin";

                command.CommandText = commandText;
                mySqlDataReader = command.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int id = int.Parse(mySqlDataReader["ID"].ToString());
                    int idConducteur = int.Parse(mySqlDataReader["IDConducteur"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string lDepart = mySqlDataReader["depart"].ToString();
                    string lDestination = mySqlDataReader["destination"].ToString();
                    DateTime heureDepart = (DateTime)mySqlDataReader["heureDepart"];
                    bool lAnimaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool lFumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    bool lBienEquipe = bool.Parse(mySqlDataReader["bienEquipe"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["NbPassagers"].ToString());

                    voyages.Add(new Voyage(id, idConducteur, prix, lDepart, lDestination, heureDepart, lAnimaux, lFumeur, lBienEquipe, nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return voyages.ToArray();
        }

    }
}
