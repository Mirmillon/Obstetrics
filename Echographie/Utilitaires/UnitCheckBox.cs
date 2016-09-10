using System.Windows.Controls;
using System.Windows;

namespace Echographie.Utilitaires
{
    public class UnitCheckBox : CheckBox
    {
        TextBox tb = null;
        Label lbl = null;
        Grid grd = null;

        public TextBox Tb
        {
            get { return tb; }
            set { tb = value; }
        }

        public Label Lbl
        {
            get { return lbl; }
            set { lbl = value; }
        }

        public Grid Grd
        {
            get { return grd; }
            set { grd = value; }
        }

        public UnitCheckBox()
        {
            Style = (Style)FindResource("CheckBoxGroupBox");
            IsThreeState = false;
            grd = new Grid();
            for (int k = 0; k < 4; ++k)
            {
                ColumnDefinition c = new ColumnDefinition();
                grd.ColumnDefinitions.Add(c);
            }
            tb = new TextBox();
            tb.Visibility = Visibility.Collapsed;
            grd.Children.Add(tb);
            lbl = new Label();
            Grid.SetColumnSpan(lbl, 2);
            grd.Children.Add(lbl);
            Content = grd;

        }
    }
}
