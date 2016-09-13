using System.Collections.Generic;
using System.Windows.Controls;
using Echographie.Classes;
using System.Windows;

namespace Echographie.Utilitaires
{
    public class GestionWrapPanel
    {
        public void AjoutCheckBox(WrapPanel wp, List<Reference> l, RoutedEventHandler routed)
        {
            for(int i = 0; i < l.Count; ++i)
            {
                UnitCheckBox c = new UnitCheckBox();
                c.Lbl.Content = l[i].Label;
                c.Click += routed;
                wp.Children.Add(c);
            }
        }
    }
}
