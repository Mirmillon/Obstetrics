using System;
using Echographie.Utilitaires;
using Echographie.Acteurs;

namespace Echographie.Classes
{
    public class Echographie : Foetus
    {
        int cleEchographie;
        DateTime dateUsc;
        int poids;

        public Echographie()
        {
            dateUsc = DateTime.Today;
        }


        public Echographie(int cleEchographie) : this()
        {
            this.cleEchographie = cleEchographie;
        }

        public int CleEchographie
        {
            get { return cleEchographie; }
            set { cleEchographie = value; }
        }

        public DateTime DateUsc
        {
            get { return dateUsc; }
            set { dateUsc = value; }
        }


        public int NombreSemaine
        {
            get { return new Calcul().NbrJour(Ddg, DateUsc) / 7; }
        }

        public int Poids
        {
            get {return poids;}
            set {poids = value;}
        }
    }
}
