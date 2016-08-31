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

   
        //////////////////////////////////////////////////////////////////////

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void TextBoxLcc_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (textBoxLcc.Text.Trim().Length == 2 && (Convert.ToInt32(textBoxLcc.Text) > 44 && Convert.ToInt32(textBoxLcc.Text) < 85))
            {

                textBoxRisqueRelatifAgeEcho.Text = new DownSyndrome().RisqueRelatifAgeEcho(new Calcul().NbrSemParLcc(textBoxLcc.Text));

                textBoxMedianeCn.Text = new DownSyndrome().ClarteNuqualeAttendue(Convert.ToInt32(textBoxLcc.Text)).ToString() ;
                if(textBoxCn.Text.Trim().Length == 3 && textBoxLcc.Text.Trim().Length == 2)
                { 
                    if (Convert.ToDouble(textBoxCn.Text) / new DownSyndrome().ClarteNuqualeAttendue(Convert.ToInt32(textBoxLcc.Text)) < 0.78)
                    {
                        textBoxMom.Text = "0,78";
                    }
                    else
                    {
                        textBoxMom.Text = (Convert.ToDouble(textBoxCn.Text) / new DownSyndrome().ClarteNuqualeAttendue(Convert.ToInt32(textBoxLcc.Text))).ToString();
                    }
                }
                else
                {
                    textBoxMom.Text = String.Empty;
                }
            }
            else
            {
                textBoxMedianeCn.Text = String.Empty;
            }
        }

        private void TextBoxAge_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(textBoxAge.Text.Trim().Length == 2 && (Convert.ToInt32(textBoxAge.Text) > 14 && Convert.ToInt32(textBoxAge.Text) < 51))
            {
                bool? b = checkBoxAtcd.IsChecked;
                textBoxRisqueAgeMaternelTerme.Text = Convert.ToString(new DownSyndrome().RisqueT21AgeMaternelTerme(Convert.ToInt32(textBoxAge.Text), (bool)b));
                if (textBoxMom.Text.Trim().Length > 0)
                {
                    textBoxRisqueAgeMaternel.Text = Math.Round(Convert.ToDouble(textBoxRisqueAgeMaternelTerme.Text)/Convert.ToDouble(textBoxRisqueRelatifAgeEcho.Text)).ToString();
                }
            }
            else
            {
                textBoxRisqueAgeMaternelTerme.Text = String.Empty;
                textBoxRisqueAgeMaternel.Text = String.Empty;
            }
        }
    }
}
