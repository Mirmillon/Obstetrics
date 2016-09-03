using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Echographie.Utilitaires
{
    public class GestionGrille
    {
        public void GridVisibilty(Grid g, int pos)
        {
            int nb = g.Children.Count;
            g.Children[pos].Visibility = Visibility.Visible;
            for (int i = 0; i < pos; ++i)
            {
                g.Children[i].Visibility = Visibility.Hidden;
            }

            for (int i = pos + 1; i < nb; ++i)
            {
                g.Children[i].Visibility = Visibility.Hidden;
            }
        }

        public void GridAjout(Grid g)
        {
           g.ShowGridLines = false;
           for(int j = 0; j < g.RowDefinitions.Count; ++j)
            {
                for (int i = 0; i < g.ColumnDefinitions.Count; i = i + 3)
                {
                    Grid grid = new Grid();
                    grid.Background = System.Windows.Media.Brushes.LightSeaGreen;
                    for (int k = 0; k < 4; ++k)
                    {
                        ColumnDefinition c = new ColumnDefinition();
                        grid.ColumnDefinitions.Add(c);
                    }

                    Grid.SetColumnSpan(grid, 3);
                    Grid.SetRow(grid, j);
                    Grid.SetColumn(grid, i);
                    g.Children.Add(grid);

                }
            }
        }
    }
}
