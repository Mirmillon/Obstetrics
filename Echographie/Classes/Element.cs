using System.ComponentModel;

namespace Echographie.Classes
{
    public class Element : INotifyPropertyChanged
    {
        private int cleElement;
        private string label;
        private int cleLangue;
        private string langue;
        private string description = null;
        private int[] indicateur = new int[] { -1, -1, -1,-1,-1};
     
        public Element(){ }

        public int CleElement
        {
            get { return cleElement; }
            set { cleElement = value;}
        }

        public string Label
        {
            get { return label.ToUpper(); }
            set
            {
                if (label != value)
                {
                    label = value;
                    indicateur[0] = 0;
                    OnPropertyChanged("Label");
                }               
            }
        }

       

        public string Description
        {
            get { return description;}
            set
            {
                if (description != value)
                {
                    description = value;
                    indicateur[1] = 0;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string Langue
        {
            get {return langue;}
            set {langue = value;}
        }

        public int CleLangue
        {
            get { return cleLangue; }
            set { cleLangue = value; }
        }

        public int[] Indicateur
        {
            get {return indicateur;}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
