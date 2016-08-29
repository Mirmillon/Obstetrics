using System.Windows;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using Echographie.Utilitaires;
using Echographie.RDMS;
using Echographie.Classes;
using Echographie.WinForms;

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

            ChartHumerus chartHumerus = new ChartHumerus();
            chartHumerus.ChartHumerusLoaded();
            hostGrapheHumerus.Child = chartHumerus;

            comboBoxPregnancyUscKind.SelectedIndex = 0;
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
                    new GestionGrille().GridVisibilty(gridCentre, 0);//Demarre sur le 1T
                    switch (comboBoxPregnancyKind.SelectedIndex)
                    {
                        case 0://Single
                            SetBindingUnique1T();
                            break;
                        case 1://Twin
                            SetBindingTwin1T();
                            break;
                        case 2://Multiple
                            SetBindingTwin1T();
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                case 2://2 et 3 Trimestre
                    SetSecondQuarter();
                    new GestionGrille().GridVisibilty(gridCentre, 1);//Demarre sur le 2T
                    break;
                case 3://Croissance             
                case 4://Morphologie
                case 5://Pathologie maternelle
                case 6://Pathologie foetale
                    SetSecondQuarter();
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
                    switch(comboBoxPregnancyUscKind.SelectedIndex)
                    {
                        case 0:
                            SetBindingUnique1T();
                            break;
                        case 1:
                        case 2:
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            break;

                    }
                    break;
                case 1://Twin
                    SetPregnancyNonUnique();
                    comboBoxTwin.Visibility = Visibility.Visible;
                    textBoxNumberFoetus.Visibility = Visibility.Collapsed;
                    switch (comboBoxPregnancyUscKind.SelectedIndex)
                    {
                        case 0:
                            SetBindingTwin1T();
                            break;
                        case 1:
                        case 2:
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            break;

                    }
                    break;
                case 2://Multiple
                    SetPregnancyNonUnique();
                    comboBoxTwin.Visibility = Visibility.Collapsed;
                    textBoxNumberFoetus.Visibility = Visibility.Visible;
                    switch (comboBoxPregnancyUscKind.SelectedIndex)
                    {
                        case 0:
                            SetBindingTwin1T();
                            break;
                        case 1:
                        case 2:
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            break;

                    }
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
            if (textBoxLlc.Text.Trim().Length > 0 && Convert.ToInt32(textBoxLlc.Text) > 0)
            {

                textBoxDdg.Text = new Calcul().CalculerDdgParLcc(textBoxLlc.Text, DateTime.Today).ToShortDateString();
                textBoxTerme.Text = new Calcul().AfficherTerme(new Calcul().NbrJour(Convert.ToDateTime(textBoxDdg.Text)));
            }
            else
            {
                textBoxTerme.Text = String.Empty;
                textBoxDdg.Text = String.Empty;
            }
        }

        #endregion END TEXTBOX

        #region LISTS

        private List<TextBox> GetMandatoryTextBox(Grid g)
        {
            List<TextBox> listes = new List<TextBox>();
            foreach (Control control in g.Children)
            {
                TextBox t = control as TextBox;
                if (t is TextBox)
                {
                    if (t.BorderBrush.ToString() == "#FFFFFF00")
                    {
                        listes.Add(t);
                    }
                }
            }
            return listes;
        }

        private List<TextBox> GetTextBoxPoids(Grid g)
        {
            List<TextBox> listes = new List<TextBox>();
            foreach (Control control in g.Children)
            {
                TextBox t = control as TextBox;
                if (t is TextBox)
                {
                    if (t.Background.ToString() == "#FFFFFF00")
                    {
                        t.TextChanged += TextBoxTerme_TextChanged;
                        listes.Add(t);
                    }
                }
            }
            return listes;
        }

        #endregion FIN LISTS

        #region BINDINGS

        private void SetBindingMorphology(Grid grid)
        {
            //Liste des elements du 1T
            List<ElementAnatomique> elements = new List<ElementAnatomique>();
            elements = new DataBase().GetElementsAnatomiques1T();
            //Liaison DataContext pour chaque uniteData de la grid biometric 1T
            //Le seul moyen en attendant les UserControl eest de slectionner les UnitData sur leur nom gridUD
            //1.Liste des gridUnit
            List<Grid> grids = new List<Grid>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        grids.Add(g);
                    }
                }
            }
            //2.Affection du DataContext
            for (int i = 0; i < grids.Count; ++i)
            {
                grids[i].DataContext = elements[i];
            }
        }

        private void SetBindingBiometrics(Grid grid)
        {
            //Liste des elements du 1T
            List<ElementBiometrique> elements = new List<ElementBiometrique>();
            elements = new DataBase().GetElement1T();
            //Liaison DataContext pour chaque uniteData de la grid biometric 1T
            //Le seul moyen en attendant les UserControl eest de slectionner les UnitData sur leur nom gridUD
            //1.Liste des gridUnit
            List<Grid> grids = new List<Grid>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {

                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        grids.Add(g);
                    }
                }
            }
            //2.Affection du DataContext
            for (int i = 0; i < grids.Count; ++i)
            {
                grids[i].DataContext = elements[i];
            }
        }

        private List<ElementBiometrique> GetBindingBiometrics(Grid grid)
        {
            //Liste des elements du 1T
            List<ElementBiometrique> elements = new List<ElementBiometrique>();

            //Liaison DataContext pour chaque uniteData de la grid biometric 1T
            //Le seul moyen en attendant les UserControl eest de slectionner les UnitData sur leur nom gridUD
            //1.Liste des gridUnit

            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    //if (new GestionGrille().GridName(g, "gridUD"))
                    {
                        object o = g.DataContext;
                        ElementBiometrique elt = o as ElementBiometrique;
                        if (elt is ElementBiometrique)
                        {
                            elements.Add(elt);
                        }
                    }
                }
            }
            return elements;
        }

        private List<ElementAnatomique> GetBindingAnatomie(Grid grid)
        {
            //Liste des elements du 1T
            List<ElementAnatomique> elements = new List<ElementAnatomique>();

            //1.Liste des gridUnit
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        object o = g.DataContext;
                        ElementAnatomique elt = o as ElementAnatomique;
                        if (elt is ElementAnatomique)
                        {
                            elements.Add(elt);
                        }
                    }
                }
            }
            return elements;
        }
        #endregion END BINDINGS

        #region METHODES LOCALES

        private void SetBindingUnique1T()
        {
            SetBindingBiometrics(gridBiometricUnique1T);
            SetBindingMorphology(gridMorphologyUnique1T);
        }

        private void SetBindingTwin1T()
        {
            SetBindingBiometrics(gridBiometricNonUnique1TTwin1);
            SetBindingMorphology(gridMorphologyNonUnique1TTwin1);
            SetBindingBiometrics(gridBiometricNonUnique1TTwin2);
            SetBindingMorphology(gridMorphologyNonUnique1TTwin2);
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
            buttonEcho1T.Visibility = Visibility.Visible;
            buttonBiometrics.Visibility = Visibility.Collapsed;
            buttonMorphology.Visibility = Visibility.Collapsed;
            buttonHeart.Visibility = Visibility.Collapsed;
            buttonBiometricsBoneChart.Visibility = Visibility.Collapsed;
            buttonBiometricsChart.Visibility = Visibility.Collapsed;
            buttonGrowthChart.Visibility = Visibility.Collapsed;
            labelWeightEstimation.Visibility = Visibility.Collapsed;
            comboBoxWeightEstimation.Visibility = Visibility.Collapsed;
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
            labelWeightEstimation.Visibility = Visibility.Visible;
            comboBoxWeightEstimation.Visibility = Visibility.Visible;
        }

        #endregion END METHODES LOCALES

        private void CheckBoxAnatomie_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb is CheckBox)
            {
                if (cb.IsChecked == true)
                {
                    cb.Content = "Checked";
                }
                else if (cb.IsChecked == false)
                {
                    cb.Content = "Not Checked";
                }
                else
                {
                    cb.Content = "To Check Again";
                }
            }
        }
    }
}
