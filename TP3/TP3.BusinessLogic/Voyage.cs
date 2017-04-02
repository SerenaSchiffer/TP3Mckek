using System;
using System.Collections.Generic;
using System.Text;

namespace TP3.businessLogic
{
    class Voyage
    {
        private int _id;
        private int _idConducteur;
        private double _prix;
        private string _depart;
        private string _destination;
        private DateTime _heureDepart;
        private bool _animaux;
        private bool _fumeur;
        private bool _bienEquipe;
        private int _nbPassagers;

        public Voyage(int id, int idConducteur, double prix, string depart, string destination, DateTime heureDepart, bool animaux, bool fumeur, bool bienEquipe, int nbPassagers)
        {
            _id = id;
            _idConducteur = idConducteur;
            _prix = prix;
            _depart = depart;
            _destination = destination;
            _heureDepart = heureDepart;
            _animaux = animaux;
            _fumeur = fumeur;
            _bienEquipe = bienEquipe;
            _nbPassagers = nbPassagers;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdConducteur { get => _idConducteur; set => _idConducteur = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public string Depart { get => _depart; set => _depart = value; }
        public string Destination { get => _destination; set => _destination = value; }
        public DateTime HeureDepart { get => _heureDepart; set => _heureDepart = value; }
        public bool Animaux { get => _animaux; set => _animaux = value; }
        public bool Fumeur { get => _fumeur; set => _fumeur = value; }
        public bool BienEquipe { get => _bienEquipe; set => _bienEquipe = value; }
        public int NbPassagers { get => _nbPassagers; set => _nbPassagers = value; }
    }
}
