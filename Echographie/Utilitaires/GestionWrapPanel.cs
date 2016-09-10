using Echographie.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Echographie.Utilitaires
{
    public class GestionWrapPanel
    {
        public void AjoutCheckBox(WrapPanel wp, List<Reference> l)
        {
            for(int i = 0; i < l.Count; ++i)
            {
                UnitCheckBox c = new UnitCheckBox();
                c.Lbl.Content = l[i].Label;
                wp.Children.Add(c);
            }
        }
    }
}
