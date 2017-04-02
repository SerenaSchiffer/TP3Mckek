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
    }
}
