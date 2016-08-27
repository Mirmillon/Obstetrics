using Echographie.Classes;

namespace Echographie.Acteurs
{
    public class Foetus : UsScan
    {
        int numeroFoetus;
        int poids;

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

        public int Poids
        {
            get {return poids;}
            set {poids = value;}
            
        }
    }
}
