using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Logements.BusinessLogic
{
    public class MembreFactory
    {
        public static void Save(string cnnStr, Membre membre)
        {
            //Encryption du mot de passe en MD5
            MD5CryptoServiceProvider MD5HASHER = new MD5CryptoServiceProvider();
            Byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = MD5HASHER.ComputeHash(encoder.GetBytes(membre.Mdp));


            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@Nom", membre.Nom));
            mySqlCmd.Parameters.Add(new MySqlParameter("@Prenom", membre.Prenom));
            mySqlCmd.Parameters.Add(new MySqlParameter("@Adresse", membre.Adresse));
            mySqlCmd.Parameters.Add(new MySqlParameter("@Telephone", membre.Telephone));
            mySqlCmd.Parameters.Add(new MySqlParameter("@Courriel", membre.Courriel));
            mySqlCmd.Parameters.Add(new MySqlParameter("@MDP", hashedBytes));
            mySqlCmd.CommandText = ("INSERT INTO membre (nom,prenom,adresse,telephone,courriel,motDePasse) VALUES(@Nom,@Prenom,@Adresse,@Telephone,@Courriel,@MDP)");
            mySqlCmd.ExecuteNonQuery();

        }

        public static bool checkIfExists(string cnnStr, string email)
        {
            bool isUnique = true;
            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;
            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                MySqlCommand mySqlCmd = connexion.CreateCommand();
                mySqlCmd.Parameters.Add(new MySqlParameter("@Courriel", email));
                mySqlCmd.CommandText = "SELECT * FROM membre WHERE courriel = @Courriel";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                isUnique =  mySqlDataReader.Read();
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();
                if (connexion != null)
                    connexion.Close();
            }
            return isUnique;
        }


        public static void Accept(string cnnStr, int id)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
            mySqlCmd.CommandText = ("UPDATE membre SET isActive=true WHERE ID=@Id");
            mySqlCmd.ExecuteNonQuery();
        }

        public static void Delete(string cnnStr, int id)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
            mySqlCmd.CommandText = ("DELETE FROM membre WHERE ID=@Id");
            mySqlCmd.ExecuteNonQuery();
        }

        public static Membre[] Get(string cnnStr, string category, int id)
        {
            List<Membre> membre = new List<Membre>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;
            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                if (category == "all" && id == 0)
                {
                    MySqlCommand mySqlCmd = connexion.CreateCommand();
                    mySqlCmd.CommandText = "SELECT * FROM membre ORDER BY ID";

                    mySqlDataReader = mySqlCmd.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        int ID = int.Parse(mySqlDataReader["ID"].ToString());
                        string nom = mySqlDataReader["nom"].ToString();
                        string prenom = mySqlDataReader["prenom"].ToString();
                        string adresse = mySqlDataReader["adresse"].ToString();
                        string telephone = mySqlDataReader["telephone"].ToString();
                        string courriel = mySqlDataReader["courriel"].ToString();
                        string mdp = mySqlDataReader["motDePasse"].ToString();
                        bool isAdmin = bool.Parse(mySqlDataReader["isAdmin"].ToString());
                        bool isActive = bool.Parse(mySqlDataReader["isActive"].ToString());
                        bool chgMDP = bool.Parse(mySqlDataReader["ChangeMDP"].ToString());



                        membre.Add(new Membre(ID, nom, prenom, adresse, telephone,courriel,mdp,isAdmin,isActive,chgMDP));
                    }
                }
                else if (category == "notAccepted" && id == 0)
                {
                    MySqlCommand mySqlCmd = connexion.CreateCommand();
                    mySqlCmd.CommandText = "SELECT * FROM membre WHERE isActive=false ORDER BY ID";

                    mySqlDataReader = mySqlCmd.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        int ID = int.Parse(mySqlDataReader["ID"].ToString());
                        string nom = mySqlDataReader["nom"].ToString();
                        string prenom = mySqlDataReader["prenom"].ToString();
                        string adresse = mySqlDataReader["adresse"].ToString();
                        string telephone = mySqlDataReader["telephone"].ToString();
                        string courriel = mySqlDataReader["courriel"].ToString();
                        string mdp = mySqlDataReader["motDePasse"].ToString();
                        bool isAdmin = bool.Parse(mySqlDataReader["isAdmin"].ToString());
                        bool isActive = bool.Parse(mySqlDataReader["isActive"].ToString());
                        bool chgMDP = bool.Parse(mySqlDataReader["ChangeMDP"].ToString());



                        membre.Add(new Membre(ID, nom, prenom, adresse, telephone,courriel,mdp,isAdmin,isActive,chgMDP));
                    }
                }
                else if (id != 0)
                {
                    MySqlCommand mySqlCmd = connexion.CreateCommand();
                    mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
                    mySqlCmd.CommandText = "SELECT * FROM membre WHERE ID=@Id";

                    mySqlDataReader = mySqlCmd.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        string nom = mySqlDataReader["nom"].ToString();
                        string prenom = mySqlDataReader["prenom"].ToString();
                        string telephone = mySqlDataReader["telephone"].ToString();
                        string courriel = mySqlDataReader["courriel"].ToString();
                        string adresse = mySqlDataReader["adresse"].ToString();
                        int ID = int.Parse(mySqlDataReader["ID"].ToString());
                        bool isAdmin = bool.Parse(mySqlDataReader["isAdmin"].ToString());
                        bool isActive = bool.Parse(mySqlDataReader["isActive"].ToString());
                        bool chgMDP = bool.Parse(mySqlDataReader["ChangeMDP"].ToString());

                        membre.Add(new Membre(ID, nom, prenom, adresse, telephone, courriel, "", isAdmin, isActive, chgMDP));
                    }

                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return membre.ToArray();
        }

        public static Membre Login(string courriel, string mdp, string cnnStr)
        {
            Membre membre = null;
            MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;


            //Encryption du mot de passe en MD5
            MD5CryptoServiceProvider MD5HASHER = new MD5CryptoServiceProvider();
            Byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = MD5HASHER.ComputeHash(encoder.GetBytes(mdp));


            try
            {
                mySqlCnn = new MySqlConnection(cnnStr);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM membre WHERE courriel = @Courriel AND motDePasse = @mdp  ORDER BY ID";
                mySqlCmd.Parameters.Add(new MySqlParameter("@mdp", hashedBytes));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Courriel", courriel));
                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    int ID = Int16.Parse(mySqlDataReader["ID"].ToString());
                    string nom = mySqlDataReader["nom"].ToString();
                    string prenom = mySqlDataReader["prenom"].ToString();
                    string adresse = mySqlDataReader["adresse"].ToString();
                    string telephone = mySqlDataReader["telephone"].ToString();
                    string courriel2 = mySqlDataReader["courriel"].ToString();
                    string mdp2 = mySqlDataReader["motDePasse"].ToString();
                    bool isAdmin = bool.Parse(mySqlDataReader["isAdmin"].ToString());
                    bool isActive = bool.Parse(mySqlDataReader["isActive"].ToString());
                    bool chgMDP = bool.Parse(mySqlDataReader["ChangeMDP"].ToString());



                    membre = new Membre(ID, nom, prenom, adresse, telephone, courriel2, mdp2, isAdmin, isActive, chgMDP);
                }

            }
            finally
            {
                if (mySqlCnn != null)
                    mySqlCnn.Close();
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();
            }
            return membre;
        }

        public static void update(Membre membre, string cnnStr)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            MySqlCommand mySqlCmd = connexion.CreateCommand();

            try
            {
                connexion.Open();
                mySqlCmd.Parameters.Add(new MySqlParameter("@Id", membre.Id));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Email", membre.Courriel));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Prenom", membre.Prenom));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Nom", membre.Nom));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Adresse", membre.Adresse));
                mySqlCmd.Parameters.Add(new MySqlParameter("@Tel", membre.Telephone));
                mySqlCmd.Parameters.Add(new MySqlParameter("@isAdmin", membre.IsAdmin));
                mySqlCmd.Parameters.Add(new MySqlParameter("@isActive", membre.IsActive));

                mySqlCmd.CommandText = ("UPDATE membre SET courriel=@Email, prenom=@Prenom, nom=@Nom, adresse=@Adresse, telephone=@Tel, isAdmin=@isAdmin, isActive=@isActive WHERE ID=@Id");
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }
        }


        public static void changePassword(int id, string newPwd, string cnnStr)
        {
            //Encryption du mot de passe en MD5
            MD5CryptoServiceProvider MD5HASHER = new MD5CryptoServiceProvider();
            Byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = MD5HASHER.ComputeHash(encoder.GetBytes(newPwd));

            MySqlConnection connexion = new MySqlConnection(cnnStr);
            MySqlCommand mySqlCmd = connexion.CreateCommand();

            try
            {
                connexion.Open();
                mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
                mySqlCmd.Parameters.Add(new MySqlParameter("@PWD", hashedBytes));
                mySqlCmd.CommandText = ("UPDATE membre SET motDePasse=@PWD, ChangeMDP=false WHERE ID=@Id");
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }
        }

        public static void changePassword(string email, string newPwd, string cnnStr)
        {
            //Encryption du mot de passe en MD5
            MD5CryptoServiceProvider MD5HASHER = new MD5CryptoServiceProvider();
            Byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = MD5HASHER.ComputeHash(encoder.GetBytes(newPwd));

            MySqlConnection connexion = new MySqlConnection(cnnStr);
            MySqlCommand mySqlCmd = connexion.CreateCommand();

            try
            {
                connexion.Open();
                mySqlCmd.Parameters.Add(new MySqlParameter("@Courriel", email));
                mySqlCmd.Parameters.Add(new MySqlParameter("@PWD", hashedBytes));
                mySqlCmd.CommandText = ("UPDATE membre SET motDePasse=@PWD, ChangeMDP=true WHERE courriel=@Courriel");
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
