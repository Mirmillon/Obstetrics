using System.Collections.Generic;
using System.ComponentModel;

namespace Echographie.Classes
{
    public class Element : INotifyPropertyChanged
    {
        private int cleElement;
        private string label;
        private int langue;
        private string description = null;
        private List<Reference> labels = null;
        private List<Reference> descriptions = null;

        public Element()
        {
            labels = new List<Reference>();
            descriptions = new List<Reference>();
        }

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
                if (this.label != value)
                {
                    this.label = value;
                    OnPropertyChanged("Label");
                }
               
            }
        }

        public List<Reference> Labels
        {
            get { return labels;}
            set
            {
                if (this.labels != value)
                {
                    this.labels = value;
                    OnPropertyChanged("Labels");
                }
            }
        }

        public string Description
        {
            get { return description;}
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public List<Reference> Descriptions
        {
            get{return descriptions;}
            set
            {
                if (this.descriptions != value)
                {
                    this.descriptions = value;
                    OnPropertyChanged("Descriptions");
                }
            }
        }

        public int Langue
        {
            get {return langue;}
            set {langue = value;}
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
