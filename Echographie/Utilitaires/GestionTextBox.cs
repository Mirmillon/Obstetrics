using System.Collections.Generic;
using System.Windows.Controls;

namespace Echographie.Utilitaires
{
    public class GestionTextBox
    {
        public  List<TextBox> GetMandatoryTextBox(Grid g)
        {
            List<TextBox> listes = new List<TextBox>();
            foreach (Control control in g.Children)
            {
                TextBox t = control as TextBox;
                if (t is TextBox)
                {
                    if (t.BorderBrush.ToString() == "#FFFFFF00")
                    {
                        listes.Add(t);
                    }
                }
            }
            return listes;
        }

        private List<TextBox> GetTextBoxPoids(Grid g)
        {
            List<TextBox> listes = new List<TextBox>();
            foreach (Control control in g.Children)
            {
                TextBox t = control as TextBox;
                if (t is TextBox)
                {
                    if (t.Background.ToString() == "#FFFFFF00")
                    {
                        //t.TextChanged += TextBoxTerme_TextChanged;
                        listes.Add(t);
                    }
                }
            }
            return listes;
        }
    }
}
