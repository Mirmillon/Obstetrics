using System.Windows;
using Echographie.Utilitaires;
using System;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Pregnancy.xaml
    /// </summary>
    public partial class Pregnancy : Window
    {
        public Pregnancy()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonLateralGauche_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            buttonValidate.IsEnabled = SetValidateEnable() ? true : false;
        }

        private bool SetValidateEnable()
        {
            bool f = textBoxName.Text.Trim().Length > 0;
            bool m = textBoxMiddleName.Text.Trim().Length > 0;
            bool l = textBoxLastName.Text.Trim().Length > 0;
            bool d = datePickerTextBoxDateBitrth.Text.Trim().Length == 10;
            bool ddg = datePickerTextBoxDdg.Text.Trim().Length == 10;
            bool numberFoetus = textBoxNumberFoetus.Text.Trim().Length > 0;

            switch (comboBoxPregnancyKind.SelectedIndex)
            {
                case 0:
                case 1:
                    return ((f) && (l) && (d) && (ddg)) ? true : false;
                case 2:
                    return ((f) && (l) && (d) && (ddg) && (numberFoetus)) ? true : false;
                default:
                    return false;
            }
        }

        private void ButtonValidate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxPregnancyKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            textBoxRisqueAgeMaternel.Text = Convert.ToString(new DownSyndrome().RisqueT21AgeMaternelTerme(33, false));
            textBoxRisqueRelatifAgeEcho.Text = new DownSyndrome().RisqueRelatifAgeEcho(11);
        }
    }
}
