using System.Windows;
using System.Windows.Controls;

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
    }
}
