using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echographie.Acteurs
{
    public class Patient : People
    {
        int numeroPatient;

        public Patient() : base() { }

        public Patient(int numeroPatient) : base()
        {
            this.numeroPatient = numeroPatient;
        }


        public int NumeroPatient
        {
            get {return numeroPatient;}
            set {numeroPatient = value;}
        }
    }
}
