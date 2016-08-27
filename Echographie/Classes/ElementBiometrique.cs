namespace Echographie.Classes
{
    public class ElementBiometrique : Element
    {

        int cleDimension;
        double dimension;

        public ElementBiometrique() : base() { }

        public ElementBiometrique(int element) : this()
        {
            CleElement = element;
        }

        public ElementBiometrique(int element, int typeDimension) : this()
        {
            cleDimension = typeDimension;
        }

        public ElementBiometrique(int element, int typeDimension, double dimension) : this()
        {
            this.dimension = dimension;
        }


        public int CleDimension
        {
            get { return cleDimension; }
            set { cleDimension = value; }
        }

        public double Dimension
        {
            get { return dimension; }
            set { dimension = value; }
        }
    }
}
