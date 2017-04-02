using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.BusinessLogic
{
    public class ReservationFactory
    {
        public static void Save(string cnnStr, Reservation reservation)
        {
            //Encryption du mot de passe en MD5 


            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@IDPassager", reservation.IdPassager));
            mySqlCmd.Parameters.Add(new MySqlParameter("@IDVoyage", reservation.IdVoyage));
            mySqlCmd.Parameters.Add(new MySqlParameter("@NbPassager", reservation.NbPassager));
            mySqlCmd.CommandText = ("INSERT INTO Reservation (IDPassager,IDVoyage,nbPassager) VALUES(@IDPassager,@IDVoyage,@NbPassager)");
            mySqlCmd.ExecuteNonQuery();

        }

        public static void Delete(string cnnStr, int id)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
            mySqlCmd.CommandText = ("DELETE FROM Reservation WHERE IDPassager=@Id");
            mySqlCmd.ExecuteNonQuery();
        }
    }
}
