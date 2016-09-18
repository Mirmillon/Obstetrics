using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

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
            Background = Brushes.White;
            Style = (Style)FindResource("CheckBoxGroupBox");
            IsThreeState = false;
            grd = new Grid();
            grd.ShowGridLines = false;
            for (int k = 0; k < 4; ++k)
            {
                ColumnDefinition c = new ColumnDefinition();
                grd.ColumnDefinitions.Add(c);
            }
            tb = new TextBox();
            tb.Background = Brushes.Red;
            tb.Visibility = Visibility.Visible;
            Grid.SetColumnSpan(tb, 1);
            grd.Children.Add(tb);
            lbl = new Label();
            Grid.SetColumn(lbl, 2);
            Grid.SetColumnSpan(lbl, 2);
            grd.Children.Add(lbl);
            Content = grd;

        }
    }
}
