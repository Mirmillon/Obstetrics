using System.ComponentModel;

namespace Echographie.Acteurs
{
    public class People: INotifyPropertyChanged
    {

        public People() { }

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
