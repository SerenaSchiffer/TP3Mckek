using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logements.BusinessLogic
{
    public class Chambre
    {
        private int _id;
        private int _idMembre;
        private double _prix;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private string _details;
        private bool _animaux;
        private bool _internet;
        private bool _stationnement;
        private bool _deneigement;
        private int _meuble;
        private bool _mobiliteReduite;
        private bool _fumeur;
        private int _quantite;
        private string _category;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }

        public string CodePostal
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        public bool Animaux
        {
            get { return _animaux; }
            set { _animaux = value; }
        }

        public bool Internet
        {
            get { return _internet; }
            set { _internet = value; }
        }

        public bool Stationnement
        {
            get { return _stationnement; }
            set { _stationnement = value; }
        }

        public bool Deneigement
        {
            get { return _deneigement; }
            set { _deneigement = value; }
        }

        public int Meuble
        {
            get { return _meuble; }
            set { _meuble = value; }
        }

        public bool MobiliteReduite
        {
            get { return _mobiliteReduite; }
            set { _mobiliteReduite = value; }
        }

        public bool Fumeur
        {
            get { return _fumeur; }
            set { _fumeur = value; }
        }

        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public Chambre(int id, int idMembre, double prix, string adresse, string ville, string codePostal, string details, bool animaux, bool internet, bool stationnement, bool deneigement, int meuble, bool mobiliteReduite, bool fumeur, int quantite, string category)
        {
            _id = id;
            _idMembre = idMembre;
            _prix = prix;
            _adresse = adresse;
            _ville = ville;
            _codePostal = codePostal;
            _details = details;
            _animaux = animaux;
            _internet = internet;
            _stationnement = stationnement;
            _deneigement = deneigement;
            _meuble = meuble;
            _mobiliteReduite = mobiliteReduite;
            _fumeur = fumeur;
            _quantite = quantite;
            _category = category;
        }
    }
}
