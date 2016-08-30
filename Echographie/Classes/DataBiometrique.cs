using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echographie.Classes
{
    public class DataBiometrique
    {
        double terme;
        string percentile;
        double resultat;

        public double Terme
        {
            get
            {
                return terme;
            }

            set
            {
                terme = value;
            }
        }

        public string Percentile
        {
            get
            {
                return percentile;
            }

            set
            {
                percentile = value;
            }
        }

        public double Resultat
        {
            get
            {
                return resultat;
            }

            set
            {
                resultat = value;
            }
        }
    }
}
