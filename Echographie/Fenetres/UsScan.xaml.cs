using System.Windows;
using Echographie.Utilitaires;
using Echographie.RDMS;

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

            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyKind(), comboBoxPregnancyKind, 0);
            //new GestionComboBox().SetComboxReference(new DataBase().GetTwin(), comboBoxTwin, 0);
            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyUscKind(), comboBoxPregnancyUscKind, 1);

            //Premiere grille visible
            new GestionGrille().GridVisibilty(gridCentre, 0);
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

        private void ComboBoxPregnancyUscKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxPregnancyKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
