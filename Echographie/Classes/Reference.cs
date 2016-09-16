using System.ComponentModel;

namespace Echographie.Classes
{
    public class Reference : INotifyPropertyChanged
    {        
        int cle;
        string label = string.Empty;

        public Reference() { }

        public Reference(int cle , string label)
        {
            this.cle = cle;
            this.label = label;
        }

        public int Cle
        {
            get { return cle; }
            set { cle = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
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
