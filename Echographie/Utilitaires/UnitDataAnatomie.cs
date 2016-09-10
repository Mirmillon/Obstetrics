using Echographie.Classes;
using System.Windows.Controls;
using System.Windows.Data;

namespace Echographie.Utilitaires
{
    public class UnitDataAnatomie : UnitData
    {
        public UnitDataAnatomie():base()
        {
            Cb1.Visibility = System.Windows.Visibility.Visible;
            Label2.Visibility = System.Windows.Visibility.Collapsed;
            Tb3.Visibility = System.Windows.Visibility.Collapsed;
            Background = System.Windows.Media.Brushes.Transparent; 
        }
    }
}
