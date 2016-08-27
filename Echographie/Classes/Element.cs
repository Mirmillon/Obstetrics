using System.ComponentModel;

namespace Echographie.Classes
{
    public class Element : INotifyPropertyChanged
    {
        private int cleElement;
        private string label;

        public Element() { }

        public int CleElement
        {
            get { return cleElement; }
            set
            {
                cleElement = value;
            }
        }

        public string Label
        {
            get { return label.ToUpper(); }
            set
            {
                label = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
