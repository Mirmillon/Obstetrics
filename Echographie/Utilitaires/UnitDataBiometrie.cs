using Echographie.Classes;
using System.Windows.Controls;
using System.Windows.Data;

namespace Echographie.Utilitaires
{
    public class UnitDataBiometrie : UnitData
    {       
        public UnitDataBiometrie():base()
        {
            Cb1.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
