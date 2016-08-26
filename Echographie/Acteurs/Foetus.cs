using Echographie.Classes;

namespace Echographie.Acteurs
{
    public class Foetus : Grossesse
    {
        int numeroFoetus;

        public Foetus() : base() { }

        public Foetus(int numeroFoetus) : this()
        {
            this.numeroFoetus = numeroFoetus;
        }

        public int NumeroFoetus
        {
            get {return numeroFoetus;}
            set {numeroFoetus = value;}
        }
    }
}
