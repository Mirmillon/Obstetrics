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

        //public UnitDataAnatomie(ElementAnatomique elt):this()
        //{
        //    Binding bElement = new Binding();
        //    Binding bCle = new Binding();
        //    Binding bEvaluation = new Binding();
          
        //    bElement.Source = elt;
        //    bCle.Source = elt;
        //    bEvaluation.Source = elt;

        //    bElement.Path = new System.Windows.PropertyPath("Element");
        //    bCle.Path = new System.Windows.PropertyPath("Cle");
        //    bEvaluation.Path = new System.Windows.PropertyPath("Evaluation");

        //    Label1.SetBinding(Label.ContentProperty, bElement);
        //    Tb1.SetBinding(TextBox.TextProperty, bCle);
        //    Cb1.SetBinding(CheckBox.IsCheckedProperty, bEvaluation);
           
        //}
    }
}
