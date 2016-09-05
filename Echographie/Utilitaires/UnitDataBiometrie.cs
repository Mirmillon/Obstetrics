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

        public UnitDataBiometrie(ElementBiometrique elt) : this()
        {
            Binding bElement = new Binding();
            Binding bCle = new Binding();
            Binding bDimension = new Binding();
            Binding bTaille = new Binding();

            bElement.Source = elt;
            bCle.Source = elt;
            bDimension.Source = elt;
            bTaille.Source = elt;

            bElement.Path = new System.Windows.PropertyPath("Element");
            bCle.Path = new System.Windows.PropertyPath("Cle");
            bDimension.Path = new System.Windows.PropertyPath("Dimension");
            bTaille.Path = new System.Windows.PropertyPath("Taille");

            Label1.SetBinding(ContentControl.ContentProperty, bElement);
            Tb1.SetBinding(TextBox.TextProperty, bCle);
            Tb2.SetBinding(TextBox.TextProperty, bDimension);
            Tb3.SetBinding(TextBox.TextProperty, bTaille);
        }
    }
}
