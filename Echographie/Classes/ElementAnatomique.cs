namespace Echographie.Classes
{
    public class ElementAnatomique : Element

    {

        int localisation;
        int evaluation;

        public ElementAnatomique() : base() { }

        public ElementAnatomique(int element) : this()
        {
            CleElement = element;
        }

        public int Localisation
        {
            get { return localisation; }
            set { localisation = value; }
        }

        public int Evaluation
        {
            get { return evaluation; }
            set { evaluation = value; }
        }
    }
}
