using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using Echographie.Classes;
using Echographie.Classes.Parametres;

namespace Echographie.Utilitaires
{
    public class GestionWrapPanel
    {
        public void AjoutCheckBox(WrapPanel wp, List<Reference> l, RoutedEventHandler routed)
        {
            for(int i = 0; i < l.Count; ++i)
            {
                UnitCheckBox c = new UnitCheckBox();
                //c.Lbl.Content = l[i].Label;
                c.Click += routed;
                wp.Children.Add(c);
            }
        }

        public void SetBinding(WrapPanel wp, List<ReferenceCheck> l)
        {
            for (int i = 0; i < l.Count; ++i)
            {
               if (wp.Children[i] is UnitCheckBox)
               {
                    UnitCheckBox u = (UnitCheckBox)wp.Children[i];

                    Binding bCheck = new Binding();
                    bCheck.Source = l[i];
                    bCheck.Mode = BindingMode.TwoWay;
                    bCheck.Path = new PropertyPath("Check");
                    u.SetBinding(CheckBox.IsCheckedProperty, bCheck);

                    Binding bCle = new Binding();
                    bCle.Source = l[i];
                    bCle.Mode = BindingMode.TwoWay;
                    bCle.Path = new PropertyPath("Cle");
                    u.Tb.SetBinding(TextBox.TextProperty, bCle);

                    Binding bLabel = new Binding();
                    bLabel.Source = l[i];
                    bLabel.Mode = BindingMode.TwoWay;
                    bLabel.Path = new PropertyPath("Label");
                    u.Lbl.SetBinding(Label.ContentProperty,bLabel);



                }
            }
        }
    }
}
