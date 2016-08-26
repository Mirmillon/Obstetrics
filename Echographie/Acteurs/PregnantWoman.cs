using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Echographie.Classes;

namespace Echographie.Acteurs
{
    public class PregnantWoman : People
    {
        Grossesse uneGrossesse = null;

        public PregnantWoman(): base()
        {
            uneGrossesse = new Grossesse();
        }
        public PregnantWoman(string firstName, string lastname) : base( firstName,  lastname)
        {
            uneGrossesse = new Grossesse();
        }

        public PregnantWoman(string firstName, string lastname, DateTime dateBirth) : base(firstName, lastname, dateBirth)
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
