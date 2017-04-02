using System;
using System.Collections.Generic;
using System.Text;

namespace TP3.BusinessLogic
{
    public class Membre
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _adresse;
        private string _telephone;
        private string _courriel;
        private string _mdp;
        private bool _isAdmin;
        private bool _isDriver;
        private bool _isFumeur;
        private bool _isAnimaux;
        private bool _isEquipe;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }


        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }


        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }


        public string Courriel
        {
            get { return _courriel; }
            set { _courriel = value; }
        }


        public string Mdp
        {
            get { return _mdp; }
            set { _mdp = value; }
        }


        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public bool IsDriver
        {
            get { return _isDriver; }
            set { _isDriver = value; }
        }

        public bool IsFumeur
        {
            get { return _isFumeur; }
            set { _isFumeur = value; }
        }
        public bool IsAnimaux
        {
            get { return _isAnimaux; }
            set { _isAnimaux = value; }
        }
        public bool IsEquipe
        {
            get { return _isEquipe; }
            set { _isEquipe = value; }
        }


        public Membre(int id, string nom, string prenom, string adresse, string telephone, string courriel, string mdp, bool isAdmin, bool isDriver, bool isFumeur,bool isAnimaux,bool isEquipe)
        {
            _id = id;
            _nom = nom;
            _prenom = prenom;
            _adresse = adresse;
            _telephone = telephone;
            _courriel = courriel;
            _mdp = mdp;
            _isAdmin = isAdmin;
            _isDriver = isDriver;
            _isFumeur = isFumeur;
            _isAnimaux = isAnimaux;
            _isEquipe = isEquipe;
        }
    }
}
