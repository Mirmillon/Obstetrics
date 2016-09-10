namespace Echographie.Classes.Parametres
{
    public class ReferenceLangue : Reference
    {
        int cleLangue;
        string langue;

        public ReferenceLangue() : base() { }

        public int CleLangue
        {
            get { return cleLangue; }
            set { cleLangue = value; }
        }

        public string Langue
        {
            get { return langue; }
            set { langue = value; }
        }

    }
}
