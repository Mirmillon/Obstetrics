using System;
using System.ComponentModel;
using Echographie.Utilitaires;

namespace Echographie.Classes
{
    public class Grossesse : INotifyPropertyChanged
    {
        private int cleGrossesse = -1;
        private DateTime ddr;
        private DateTime ddg;
        private DateTime eddD40;
        private DateTime eddD41;
        private String terme;
        private int pregnancyKind = -1;
        private int nombreFoetus;
        private int outcome = -1;
        private int datation = -1;
        private int twin = -1;

        public Grossesse() 
        { 
           
        }

        public Grossesse(DateTime ddg) : this()
        {
            pregnancyKind = 1;
            outcome = 1;
            this.Ddg = ddg; 
        }

        public int CleGrossesse
        {
            get { return cleGrossesse; }
            set { cleGrossesse = value; }
        }

        public DateTime Ddg
        {
            get { return ddg; }
            set
            {
                if (this.ddg != value)
                {
                    this.ddg = value;
                    OnPropertyChanged("Ddg");
                }
            }
        }

        public DateTime EddD40
        {
            get { return ddg.AddDays(280); }
            set { eddD40 = value; }
        }

        public DateTime EddD411
        {
            get { return ddg.AddDays(287); }
            set { eddD41 = value; }
        }

        public string Terme
        {
            get
            {
                if(ddg > DateTime.Today.AddDays(-300))
                {
                    return new Calcul().AfficherTerme(new Calcul().NbrJour(ddg));
                }
                else
                {
                    return null;
                } 
            }
            set { terme = value; }
        }

        public int PregnancyKind
        {
            get { return pregnancyKind; }
            set
            {
                if (this.pregnancyKind != value)
                {
                    this.pregnancyKind = value;
                    OnPropertyChanged("PregnancyKind");
                }
            }
        }

        public int Outcome
        {
            get { return outcome; }
            set
            {
                if (this.outcome != value)
                {
                    this.outcome = value;
                    OnPropertyChanged("Outcome");
                }
            }
        }

        public int Datation
        {
            get { return datation; }
            set
            {
                if (this.datation != value)
                {
                    this.datation = value;
                    OnPropertyChanged("Datation");
                }
            }
        }

        public DateTime Ddr
        {
            get { return ddr;}
            set
            {
                if (this.ddr != value)
                {
                    this.ddr = value;
                    OnPropertyChanged("Ddr");
                }
            }
        }

        public int NombreFoetus
        {
            get{ return nombreFoetus;}
            set
            {
                if (this.nombreFoetus != value)
                {
                    this.nombreFoetus = value;
                    OnPropertyChanged("NombreFoetus");
                }
            }
        }

        public int Twin
        {
            get { return twin; }
            set
            {
                if (this.twin != value)
                {
                    this.twin = value;
                    OnPropertyChanged("Twin");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
