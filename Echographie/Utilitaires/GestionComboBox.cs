using Echographie.Classes;
using Echographie.RDMS;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Echographie.Utilitaires
{
    public class GestionComboBox
    {
        public void SetComboxReference(List<Reference> l, ComboBox cb, int index)
        {
            cb.ItemsSource = l;
            cb.DisplayMemberPath = "Label";
            cb.SelectedValuePath = "Cle";
            cb.SelectedIndex = index;
        }

        public void SetComboxReference(List<Reference> l, DataGridComboBoxColumn cb)
        {
            cb.ItemsSource = l;
            cb.DisplayMemberPath = "Label";
            cb.SelectedValuePath = "Cle";
        }

        private void SetComboxReference(List<Reference> l, ComboBox cb)
        {
            cb.ItemsSource = l;
            cb.DisplayMemberPath = "Label";
            cb.SelectedValuePath = "Cle";
        }

        public void SetComboBoxMorphologie(Grid g)
        {
            foreach (Control control in g.Children)
            {
                ComboBox t = control as ComboBox;
                if (t is ComboBox)
                {
                    SetComboxReference(new DataBase().GetCheck(), t);
                }
            }
        }

        public void SetComboBoxDataUnit(Grid g)
        {
            foreach (Panel p in g.Children)
            {
                Grid t = p as Grid;
                if (t is Grid)
                {
                    SetComboBoxMorphologie(t);
                }
            }
        }

        public void SelectComboBoxMorphologie(Grid g)
        {
            foreach (Control control in g.Children)
            {
                ComboBox t = control as ComboBox;
                if (t is ComboBox)
                {
                    t.SelectedIndex = 0;
                }
            }
        }

        public void UnSelectComboBoxMorphologie(Grid g)
        {
            foreach (Control control in g.Children)
            {
                ComboBox t = control as ComboBox;
                if (t is ComboBox)
                {
                    t.SelectedIndex = -1;
                }
            }
        }


    }
}
