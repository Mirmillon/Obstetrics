using System.Windows;
using Echographie.Utilitaires;
using Echographie.RDMS;
using System;
using System.Windows.Controls;

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
            new GestionComboBox().SetComboxReference(new DataBase().GetTwin(), comboBoxTwin, 0);
            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyUscKind(), comboBoxPregnancyUscKind, 1);
        }

        #region BUTTON

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonIdentification_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }

        private void ButtonGrowthChart_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }

        #endregion END BUTTON

        #region COMBOBOX

        private void ComboBoxPregnancyUscKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (comboBoxPregnancyUscKind.SelectedIndex)
            {
                case 0://1 Trimestre
                    SetFirstQuarter();
                    labelWeightEstimation.Visibility = Visibility.Collapsed;
                    comboBoxWeightEstimation.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                case 2://2 et 3 Trimestre
                    SetSecondQuarter();
                    labelWeightEstimation.Visibility = Visibility.Visible;
                    comboBoxWeightEstimation.Visibility = Visibility.Visible;
                    break;
                case 3://Croissance
                    SetSecondQuarter();
                    labelWeightEstimation.Visibility = Visibility.Visible;
                    comboBoxWeightEstimation.Visibility = Visibility.Visible;
                    break;
                case 4://Morphologie
                    SetSecondQuarter();
                    labelWeightEstimation.Visibility = Visibility.Visible;
                    comboBoxWeightEstimation.Visibility = Visibility.Visible;
                    break;
                case 5://Pathologie maternelle
                    SetSecondQuarter();
                    labelWeightEstimation.Visibility = Visibility.Visible;
                    comboBoxWeightEstimation.Visibility = Visibility.Visible;
                    break;
                case 6://Pathologie foetale
                    SetSecondQuarter();
                    labelWeightEstimation.Visibility = Visibility.Visible;
                    comboBoxWeightEstimation.Visibility = Visibility.Visible;
                    break;
                default:
                    SetSecondQuarter();
                    labelWeightEstimation.Visibility = Visibility.Visible;
                    comboBoxWeightEstimation.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void ComboBoxPregnancyKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (comboBoxPregnancyKind.SelectedIndex)
            {
                case 0://Single
                    SetPregnancyUnique();
                    comboBoxTwin.Visibility = Visibility.Collapsed;
                    textBoxNumberFoetus.Visibility = Visibility.Collapsed;
                    break;
                case 1://Twin
                    SetPregnancyNonUnique();
                    comboBoxTwin.Visibility = Visibility.Visible;
                    textBoxNumberFoetus.Visibility = Visibility.Collapsed;
                    break;
                case 2://Multiple
                    SetPregnancyNonUnique();
                    comboBoxTwin.Visibility = Visibility.Collapsed;
                    textBoxNumberFoetus.Visibility = Visibility.Visible;
                    break;
                default:
                    SetPregnancyUnique();
                    comboBoxTwin.Visibility = Visibility.Collapsed;
                    textBoxNumberFoetus.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        
        #endregion END COMBOBOX

        #region TEXTBOX

        private void TextBoxDdg_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (textBoxDdg.Text.Trim().Length == 10 && this.IsVisible == true)
            {
                textBoxTerme.Text = (new Calcul().NbrJour(Convert.ToDateTime(textBoxDdg.Text)) / 7).ToString();
            }
            else
            {
                textBoxTerme.Text = String.Empty;
            }
        }

        private void TextBoxTerme_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (textBoxLlc.Text.Trim().Length > 0 && Convert.ToInt32(textBoxLlc.Text) > 0)
            //{

            //    textBoxDdg.Text = new Calcul().CalculerDdgParLcc(textBoxLlc.Text, DateTime.Today).ToShortDateString();
            //    textBoxTerme.Text = new Calcul().AfficherTerme(new Calcul().NbrJour(Convert.ToDateTime(textBoxDdg.Text)));
            //}
            //else
            //{
            //    textBoxTerme.Text = String.Empty;
            //    textBoxDdg.Text = String.Empty;
            //}
        }

        #endregion END TEXTBOX

        #region METHODES LOCALES

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
            buttonEcho1T.Visibility = Visibility.Visible;
            buttonBiometrics.Visibility = Visibility.Collapsed;
            buttonMorphology.Visibility = Visibility.Collapsed;
            buttonHeart.Visibility = Visibility.Collapsed;
            buttonBiometricsBoneChart.Visibility = Visibility.Collapsed;
            buttonBiometricsChart.Visibility = Visibility.Collapsed;
            buttonGrowthChart.Visibility = Visibility.Collapsed;
        }

        private void SetSecondQuarter()
        {
            buttonEcho1T.Visibility = Visibility.Collapsed;
            buttonBiometrics.Visibility = Visibility.Visible;
            buttonMorphology.Visibility = Visibility.Visible;
            buttonHeart.Visibility = Visibility.Visible;
            buttonBiometricsBoneChart.Visibility = Visibility.Visible;
            buttonBiometricsChart.Visibility = Visibility.Visible;
            buttonGrowthChart.Visibility = Visibility.Visible;
        } 
        
        #endregion END METHODES LOCALES

    }
}
