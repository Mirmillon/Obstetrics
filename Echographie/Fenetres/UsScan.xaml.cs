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
            switch (comboBoxPregnancyUscKind.SelectedIndex)
            {
                case 0:
                    SetFirstQuarter();
                    break;
                case 1:
                case 2:
                    SetSecondQuarter();
                    break;
                case 3:
                    SetSecondQuarter();
                    break;
                case 4:
                    SetSecondQuarter();
                    break;
                case 5:
                    SetSecondQuarter();
                    break;
                case 6:
                    SetSecondQuarter();
                    break;
                default:
                    break;
            }

        }

        private void ComboBoxPregnancyKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch(comboBoxPregnancyKind.SelectedIndex)
            {
                case 0://Single
                    SetPregnancyUnique();
                    break;
                case 1://Twin
                    SetPregnancyNonUnique();
                    break;
                case 2://Multiple
                    SetPregnancyNonUnique();
                    break;
                default:
                    SetPregnancyUnique();
                    break;
            }
        }

        private void SetPregnancyUnique()
        {
            gridEcho1TNonUnique.Visibility = Visibility.Hidden;
            gridBiometricNonUnique.Visibility = Visibility.Hidden;
            gridMorphologyNonUnique.Visibility = Visibility.Hidden;
            gridHeartNonUnique.Visibility = Visibility.Hidden;
            gridEcho1TUnique.Visibility = Visibility.Visible;
            gridBiometricUnique.Visibility = Visibility.Visible;
            gridMorphologyUnique.Visibility = Visibility.Visible;
            gridHeartUnique.Visibility = Visibility.Visible;
        }

        private void SetPregnancyNonUnique()
        {
            gridEcho1TNonUnique.Visibility = Visibility.Visible;
            gridBiometricNonUnique.Visibility = Visibility.Visible;
            gridMorphologyNonUnique.Visibility = Visibility.Visible;
            gridHeartNonUnique.Visibility = Visibility.Visible;
            gridEcho1TUnique.Visibility = Visibility.Hidden;
            gridBiometricUnique.Visibility = Visibility.Hidden;
            gridMorphologyUnique.Visibility = Visibility.Hidden;
            gridHeartUnique.Visibility = Visibility.Hidden;
        }

        private void SetFirstQuarter()
        {
             buttonEcho1T.IsEnabled = true;
            buttonBiometrics.IsEnabled = false;
            buttonMorphology.IsEnabled = false;
            buttonHeart.IsEnabled = false;
            buttonBiometricsBoneChart.IsEnabled = false;
            buttonBiometricsChart.IsEnabled = false;
            buttonGrowthChart.IsEnabled = false;
        }

        private void SetSecondQuarter()
        {
            buttonEcho1T.IsEnabled = false;
            buttonBiometrics.IsEnabled = true;
            buttonMorphology.IsEnabled = true;
            buttonHeart.IsEnabled = true;
            buttonBiometricsBoneChart.IsEnabled = true;
            buttonBiometricsChart.IsEnabled = true;
            buttonGrowthChart.IsEnabled = true;
        }
    }
}
