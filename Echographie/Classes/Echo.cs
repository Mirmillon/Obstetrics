using System;
using Echographie.Utilitaires;

namespace Echographie.Classes
{
    public class Echo : Grossesse
    {
        int cleEchographie;
        DateTime dateUsc;

        public Echo()
        {
            dateUsc = DateTime.Today;
        }

        public Echo(int cleEchographie) : this()
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
    }
}
