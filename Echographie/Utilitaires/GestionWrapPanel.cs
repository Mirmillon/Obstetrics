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
        public void AjoutCheckBox(WrapPanel wp, List<Reference> l)
        {
            for(int i = 0; i < l.Count; ++i)
            {
                UnitCheckBox c = new UnitCheckBox();
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
                    u.DataContext = l[i];

                    Binding bCheck = new Binding();
                    bCheck.Mode = BindingMode.TwoWay;
                    bCheck.Path = new PropertyPath("Check");
                    u.SetBinding(CheckBox.IsCheckedProperty, bCheck);

                    Binding bCle = new Binding();
                    bCle.Mode = BindingMode.TwoWay;
                    bCle.Path = new PropertyPath("Cle");
                    u.Tb.SetBinding(TextBox.TextProperty, bCle);

                    Binding bLabel = new Binding();
                    bLabel.Mode = BindingMode.OneWay;
                    bLabel.Path = new PropertyPath("Label");
                    u.Lbl.SetBinding(Label.ContentProperty,bLabel);                   
                }
            }
        }

        public void SetBinding(WrapPanel wp, List<ReferenceCheck> l, List<ReferenceCheck> l1)
        {
            for (int i = 0; i < l.Count; ++i)
            {
                if (wp.Children[i] is UnitCheckBox)
                {
                    UnitCheckBox u = (UnitCheckBox)wp.Children[i];
                    u.DataContext = l[i];

                    Binding bCheck = new Binding();
                    bCheck.Mode = BindingMode.TwoWay;
                    bCheck.Path = new PropertyPath("Check");
                    u.SetBinding(CheckBox.IsCheckedProperty, bCheck);

                    Binding bCle = new Binding();
                    bCle.Mode = BindingMode.TwoWay;
                    bCle.Path = new PropertyPath("Cle");
                    u.Tb.SetBinding(TextBox.TextProperty, bCle);

                    Binding bLabel = new Binding();
                    bLabel.Mode = BindingMode.OneWay;
                    bLabel.Source = l1[i];
                    bLabel.Path = new PropertyPath("Label");
                    u.Lbl.SetBinding(Label.ContentProperty, bLabel);
                }
            }
        }


        public void SetBinding(WrapPanel wp, List<ReferenceCheck> l, List<Reference> l1)
        {
            for (int i = 0; i < l.Count; ++i)
            {
                if (wp.Children[i] is UnitCheckBox)
                {
                    UnitCheckBox u = (UnitCheckBox)wp.Children[i];
                    u.DataContext = l[i];

                    Binding bCheck = new Binding();
                    bCheck.Mode = BindingMode.TwoWay;
                    bCheck.Path = new PropertyPath("Check");
                    u.SetBinding(CheckBox.IsCheckedProperty, bCheck);

                    Binding bCle = new Binding();
                    bCle.Mode = BindingMode.TwoWay;
                    bCle.Path = new PropertyPath("Cle");
                    u.Tb.SetBinding(TextBox.TextProperty, bCle);

                    Binding bLabel = new Binding();
                    bLabel.Mode = BindingMode.OneWay;
                    bLabel.Source = l1[i];
                    bLabel.Path = new PropertyPath("Label");
                    u.Lbl.SetBinding(Label.ContentProperty, bLabel);
                }
            }
        }

        public List<ReferenceCheck> GetBindingWrapPanel(WrapPanel wp)
        {
            List<ReferenceCheck> dimensions = new List<ReferenceCheck>();
            foreach (UnitCheckBox u in wp.Children)
            {
                ReferenceCheck r = (ReferenceCheck)u.DataContext;
                dimensions.Add(r);
            }
            return dimensions;
        }
    }
}
