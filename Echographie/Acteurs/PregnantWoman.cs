using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Echographie.Classes;

namespace Echographie.Acteurs
{
    public class PregnantWoman : Patient
    {
        Grossesse uneGrossesse = null;

        public PregnantWoman(): base()
        {
            uneGrossesse = new Grossesse();
        }
       
        public Grossesse UneGrossesse
        {
            get {return uneGrossesse;}
            set {uneGrossesse = value;}
        }
    }
}
