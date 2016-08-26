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
            get { return numeroPatient; }
            set
            {
                if (this.numeroPatient != value)
                {
                    this.numeroPatient = value;
                    OnPropertyChanged("NumeroPatient");
                }
            }
        }
    }
}
