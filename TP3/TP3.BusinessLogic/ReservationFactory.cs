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

        public static Reservation[] GetAllById(string cnnStr,int id)
        {
            List<Reservation> reservations = new List<Reservation>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                MySqlCommand mySqlCmd = connexion.CreateCommand();

                mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
                mySqlCmd.CommandText = "SELECT * FROM Reservation Where IDPassager=@Id";

                mySqlDataReader = mySqlCmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int ID = int.Parse(mySqlDataReader["ID"].ToString());
                    int IDPassager = int.Parse(mySqlDataReader["IDPassager"].ToString());
                    int IDVoyages = int.Parse(mySqlDataReader["IDVoyage"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["nbPassager"].ToString());

                    reservations.Add(new Reservation(ID,IDPassager,IDVoyages,nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return reservations.ToArray();
        }

        public static Reservation GetByID(string cnnStr,int id)
        {
            Reservation reservation = null;

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                MySqlCommand mySqlCmd = connexion.CreateCommand();

                mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
                mySqlCmd.CommandText = "SELECT * FROM Reservation Where ID=@Id";

                mySqlDataReader = mySqlCmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int ID = int.Parse(mySqlDataReader["ID"].ToString());
                    int IDPassager = int.Parse(mySqlDataReader["IDPassager"].ToString());
                    int IDVoyages = int.Parse(mySqlDataReader["IDVoyage"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["nbPassager"].ToString());

                    reservation = new Reservation(ID, IDPassager, IDVoyages, nbPassagers);
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return reservation;
        }

        public static void Delete(string cnnStr, int id)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
            mySqlCmd.CommandText = ("DELETE FROM Reservation WHERE ID=@Id");
            mySqlCmd.ExecuteNonQuery();
        }
    }
}
