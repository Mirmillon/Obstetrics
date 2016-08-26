using System.ComponentModel;

namespace Echographie.Classes
{
    public class Reference : INotifyPropertyChanged
    {
        public Reference() { }

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
