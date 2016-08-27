using System.Windows;
using Echographie.Utilitaires;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour UsScan.xaml
    /// </summary>
    public partial class UsScan : Window
    {
        public UsScan()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonIdentification_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }

        private void ButtonGrowthChart_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }
    }
}
