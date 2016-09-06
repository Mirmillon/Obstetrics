using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using Echographie.Utilitaires;
using Echographie.RDMS;
using Echographie.Classes;
using Echographie.WinForms;
using Echographie.Acteurs;
using Echographie.Graphes;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour UsScan.xaml
    /// </summary>
    public partial class UsScan : Window
    {
        private ChartBiometrics chartBiometrie = null;
        private ChartCroissancePonderale chartCroissance = null;
        private Patient _patient = null;
        private Grossesse _pregnancy = null;
        private Echo _echographie = null;
        private List<Foetus> _listFoetus = null;
  
        public UsScan()
        {
            InitializeComponent();

            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyKind(), comboBoxPregnancyKind, 0);
            new GestionComboBox().SetComboxReference(new DataBase().GetTwin(), comboBoxTwin, 0);
            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyUscKind(), comboBoxPregnancyUscKind, 1);

            ChartHumerus chartHumerus = new ChartHumerus();
            chartHumerus.ChartHumerusLoaded();
            hostGrapheHumerus.Child = chartHumerus;

            chartBiometrie = new ChartBiometrics();
            chartBiometrie.ChartBiometricsLoader();
            hostGrapheBiometrics.Child = chartBiometrie;

            chartCroissance = new ChartCroissancePonderale();
            chartCroissance.CroissancePonderaleLoaded();
            hostGrapheCroissance.Child = chartCroissance;

            comboBoxPregnancyUscKind.SelectedIndex = 0;

            new GestionGrille().GridAjoutUnitDataBiometrie(gridBiometricUnique1T, 4, 4, new DataBase().GetElementBiometrie1T());
            new GestionGrille().SetBindingUnitDataBiometrie(gridBiometricUnique1T, new DataBase().GetElementBiometrie1T());
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyUnique, 0, 0);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyUnique,1,3);
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyUnique, 4, 4);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyUnique, 5, 8);
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyUnique, 9, 9);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyUnique, 10, 11);

            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyTNonUniqueTwin1, 0, 0);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyTNonUniqueTwin1, 1, 3);
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyTNonUniqueTwin1, 4, 4);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyTNonUniqueTwin1, 5, 8);
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyTNonUniqueTwin1, 9, 9);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyTNonUniqueTwin1, 10, 11);

            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyTNonUniqueTwin2, 0, 0);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyTNonUniqueTwin2, 1, 3);
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyTNonUniqueTwin2, 4, 4);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyTNonUniqueTwin2, 5, 8);
            //new GestionGrille().GridAjoutUserDataAnatomieLigne(gridMorphologyTNonUniqueTwin2, 9, 9);
            //new GestionGrille().GridAjoutUserDataAnatomie(gridMorphologyTNonUniqueTwin2, 10, 11);


            //new GestionGrille().GridAjoutUserDataBiometrieLigne(gridBiometricUnique, 0, 0);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricUnique,1,3);
            //new GestionGrille().GridAjoutUserDataBiometrieLigne(gridBiometricUnique, 4, 4);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricUnique, 5, 6);
            //new GestionGrille().GridAjoutUserDataBiometrieLigne(gridBiometricUnique, 7, 7);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricUnique, 8, 9);

            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricTNonUniqueTwin1, 1, 3);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricTNonUniqueTwin1, 5, 6);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricTNonUniqueTwin1, 8, 9);

            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricTNonUniqueTwin2, 1, 3);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricTNonUniqueTwin2, 5, 6);
            //new GestionGrille().GridAjoutUserDataBiometrie(gridBiometricTNonUniqueTwin2, 8, 9);

            SetFoetus(3);
        }

        public UsScan(int clePeople):this()
        {
            _patient = new Patient();
            _patient.ClePeople = clePeople;
            _patient = new DataBase().GetPeopleFemaleByKey(_patient.ClePeople);
            labelTitre.Content = _patient.FullName + " - " + _patient.AgeToday().ToString() + " Y.O";
        }

        public UsScan(int clePeople, int cleGrossesse) : this()
        {
            _patient = new Patient();
            _patient.ClePeople = clePeople;
            _patient = new DataBase().GetPeopleFemaleByKey(_patient.ClePeople);
            labelTitre.Content = _patient.FullName + " - " + _patient.AgeToday().ToString() + " Y.O";

            _pregnancy = new Grossesse();
            _pregnancy.CleGrossesse = cleGrossesse;
            _pregnancy = new DataBase().GetPregnancyByKey(_pregnancy.CleGrossesse);
            stackPanelHautSup.DataContext = _pregnancy;
            if (new Calcul().NbreSemParDdg(_pregnancy.Ddg) > 15)
            {
                comboBoxPregnancyUscKind.SelectedIndex = 1;
            }
            else
            {
                comboBoxPregnancyUscKind.SelectedIndex = 0;
            }
            SetFoetus(_pregnancy.NombreFoetus);
        }

        #region BUTTON

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonIdentification_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));}

        private void ButtonGrowthChart_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));}

        private void ButtonBiometricsChart_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
            chartBiometrie.AreaHead.Visible = true;
            chartBiometrie.AreaAbdo.Visible = false;
            chartBiometrie.AreaFemur.Visible = false;
        }

        private void ButtonChartAreaHead_Click(object sender, RoutedEventArgs e)
        {
            chartBiometrie.AreaHead.Visible = true;
            chartBiometrie.AreaAbdo.Visible = false;
            chartBiometrie.AreaFemur.Visible = false;
        }

        private void ButtonChartAreaAddo_Click(object sender, RoutedEventArgs e)
        {
            chartBiometrie.AreaHead.Visible = false;
            chartBiometrie.AreaAbdo.Visible = true;
            chartBiometrie.AreaFemur.Visible = false;
        }

        private void ButtonChartAreaFemur_Click(object sender, RoutedEventArgs e)
        {
            chartBiometrie.AreaHead.Visible = false;
            chartBiometrie.AreaAbdo.Visible = false;
            chartBiometrie.AreaFemur.Visible = true;
        }

        private void ButtonValidate_Click(object sender, RoutedEventArgs e)
        {
            //Si la personne n'a pas de numero _patient
            if (_patient.NumeroPatient < 1)
            {
                //JE Cree un numero _patient
                _patient.NumeroPatient = new DataBase().SetPatient(_patient.ClePeople);
                // Puis un num grossesse
                SetGrossesse();
                // Puis un num echo
                _echographie = new Echo(new DataBase().SetUS(_pregnancy.CleGrossesse));
                SetDataBase();
            }
            else if (_pregnancy.CleGrossesse < 1)
            {
                //Je cree un dossier obs
                SetGrossesse();
                // Puis un num echo
                _echographie = new Echo(new DataBase().SetUS(_pregnancy.CleGrossesse));
                SetDataBase();
            }
            else
            {
                _echographie = new Echo(new DataBase().SetUS(_pregnancy.CleGrossesse));
                SetDataBase();
            }
        }

        #endregion END BUTTON

        #region COMBOBOX
        //TODO Methode pour ajuster le nombre de serie foetale 
        private void ComboBoxPregnancyUscKind_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (comboBoxPregnancyUscKind.SelectedIndex)
            {
                case 0://1 Trimestre
                    AddTextChanged();
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
                       //TODO Verification du nombre de serie dans l'aire croissance 
                    if(chartCroissance != null)
                    {
                        if (chartCroissance.Series.Count > 12)//Signifie qu'il y a plus de serie que de foetus
                        {
                            //TODO Remove serie supplementaire
                        }
                    }
                    RemoveTextChanged();
                    SetSecondQuarter();
                    new GestionGrille().GridVisibilty(gridCentre, 1);//Demarre sur le 2T
                    break;
                case 3://Croissance  
                       //TODO Verification du nombre de serie dans l'aire croissance 
                    if (chartCroissance != null)
                    {
                        if (chartCroissance.Series.Count > 12)//Signifie qu'il y a plus de serie que de foetus
                        {
                            //TODO Remove serie supplementaire
                        }
                    }
                    break;
                case 4://Morphologie
                case 5://Pathologie maternelle
                case 6://Pathologie foetale
                    RemoveTextChanged();
                    SetSecondQuarter();
                    break;
                default:
                    RemoveTextChanged();
                    SetSecondQuarter();
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
                            //TODO Verification du nombre de serie dans l'aire croissance 
                            if (chartCroissance.Series.Count > 12)//Signifie qu'il y a plus de serie que de foetus
                            {
                                //TODO Remove serie supplementaire
                            }
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
                    //TODO Verification du nombre de serie dans l'aire croissance

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

        private void TextBoxTerme_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {}

        private void TextBoxCn_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            //if (t.Text.Trim().Length == 3 && textBoxLlc.Text.Trim().Length == 2)
            //{
            //    textBoxMedianeCn.Text = new DownSyndrome().ClarteNuqualeAttendue(Convert.ToInt32(textBoxLlc.Text)).ToString();
            //}
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

        #region CHECKBOX

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

        #endregion END CHECKBOX

        #region LISTS

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

        #region METHODES LOCALES

        private void SetBindingUnique1T()
        {
            List<ElementAnatomique> elements = new List<ElementAnatomique>();
            elements = new DataBase().GetElementsAnatomiques1T();
            List<ElementBiometrique> elementsBio = new List<ElementBiometrique>();
            elementsBio = new DataBase().GetElementBiometrie1T();
            new GestionGrille().SetBindingBiometrics(gridBiometricUnique1T, elementsBio);
            new GestionGrille().SetBindingMorphology(gridMorphologyUnique1T,elements);
        }

        private void SetBindingTwin1T()
        {
            List<ElementAnatomique> elements = new List<ElementAnatomique>();
            elements = new DataBase().GetElementsAnatomiques1T();
            List<ElementBiometrique> elementsBio = new List<ElementBiometrique>();
            elementsBio = new DataBase().GetElementBiometrie1T();
            new GestionGrille().SetBindingBiometrics(gridBiometricNonUnique1TTwin1, elementsBio);
            new GestionGrille().SetBindingMorphology(gridMorphologyNonUnique1TTwin1, elements);
            new GestionGrille().SetBindingBiometrics(gridBiometricNonUnique1TTwin2, elementsBio);
            new GestionGrille().SetBindingMorphology(gridMorphologyNonUnique1TTwin2, elements);
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

        private void SetDataBase()
        {
            switch (comboBoxPregnancyUscKind.SelectedIndex)
            {
                case 0://1 Trimestre
                    switch (comboBoxPregnancyKind.SelectedIndex)
                    {
                        case 0://Single
                            List<ElementBiometrique> l = new GestionGrille().GetBindingBiometrics(gridBiometricUnique1T);
                            List<ElementAnatomique> listeAnatomique = new GestionGrille().GetBindingAnatomie(gridMorphologyUnique1T);
                            SetListeElmentsBiometricsDataBase(l, 1);
                            SetListeElementsAnatomieDataBase(listeAnatomique, 1);
                            break;
                        case 1://Twin
                            List<ElementBiometrique> l1 = new GestionGrille().GetBindingBiometrics(gridBiometricNonUnique1TTwin1);
                            List<ElementAnatomique> listeAnatomiqueT1 = new GestionGrille().GetBindingAnatomie(gridMorphologyNonUnique1TTwin1);
                            SetListeElmentsBiometricsDataBase(l1, 1);
                            SetListeElementsAnatomieDataBase(listeAnatomiqueT1, 1);
                            List<ElementBiometrique> l2 = new GestionGrille().GetBindingBiometrics(gridBiometricNonUnique1TTwin2);
                            List<ElementAnatomique> listeAnatomiqueT2 = new GestionGrille().GetBindingAnatomie(gridMorphologyNonUnique1TTwin2);
                            SetListeElementsAnatomieDataBase(listeAnatomiqueT2, 2);
                            SetListeElmentsBiometricsDataBase(l2, 2);
                            break;
                        case 2://Multiple
                            
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                case 2://2 et 3 Trimestre
                    switch (comboBoxPregnancyKind.SelectedIndex)
                    {
                        case 0://Single
                            List<ElementBiometrique> l = new GestionGrille().GetBindingUnitDataBiometrics(gridBiometricUnique);
                            SetListeElmentsBiometricsDataBase(l, 1);
                            break;
                        case 1://Twin

                            break;
                        case 2://Multiple

                            break;
                        default:
                            break;
                    }
                    break;
                case 3://Croissance             
                case 4://Morphologie
                case 5://Pathologie maternelle
                case 6://Pathologie foetale
                    switch (comboBoxPregnancyKind.SelectedIndex)
                    {
                        case 0://Single

                            break;
                        case 1://Twin

                            break;
                        case 2://Multiple

                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    switch (comboBoxPregnancyKind.SelectedIndex)
                    {
                        case 0://Single

                            break;
                        case 1://Twin

                            break;
                        case 2://Multiple

                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        private void SetListeElmentsBiometricsDataBase(List<ElementBiometrique> l, int numFoetus)
        {
            for (int i = 0; i < l.Count; ++i)
            {
                new DataBase().SetBiometrieFoetus(_echographie.CleEchographie, numFoetus, l[i].CleElement, l[i].CleDimension, l[i].Dimension);
            }
        }

        private void SetListeElementsAnatomieDataBase(List<ElementAnatomique> l, int numFoetus)
        {
            for (int i = 0; i < l.Count; ++i)
            {
                new DataBase().SetMorphologie(_echographie.CleEchographie, numFoetus, l[i].CleElement, l[i].Evaluation);
            }
        }

        private void SetGrossesse()
        {
            _pregnancy = new Grossesse();
            _pregnancy.Ddg = Convert.ToDateTime(textBoxDdg.Text);
            _pregnancy.PregnancyKind = ((Reference)comboBoxPregnancyKind.SelectedItem).Cle;
            _pregnancy.NombreFoetus = Convert.ToInt32(textBoxNumberFoetus.Text);
            _pregnancy.CleGrossesse = new DataBase().SetPregnancy(_patient.ClePeople, _pregnancy.Ddr, _pregnancy.Ddr, _pregnancy.PregnancyKind);
            stackPanelHautSup.DataContext = _pregnancy;
        }

        private void RemoveTextChanged()
        {
            //textBoxLlc.TextChanged -= TextBox_TextChanged;
            textBoxLlcTwin1.TextChanged -= TextBox_TextChanged;
            textBoxLlctwin2.TextChanged -= TextBox_TextChanged;
        }

        private void AddTextChanged()
        {
            //textBoxLlc.TextChanged += TextBox_TextChanged;
            textBoxLlcTwin1.TextChanged += TextBox_TextChanged;
            textBoxLlctwin2.TextChanged += TextBox_TextChanged;
        }

        //Paramétres de l'application en fo,ction du nombre de foestus
        //TODO Ajoutez des tabcontrol si nombre de foetus sup à 2
        private void SetFoetus(int nbFoetus)
        {
            _listFoetus = new List<Foetus>();
            for (int i = 0; i < nbFoetus; ++i)
            {
                Foetus f = new Foetus();
                _listFoetus.Add(f);

                SeriePoidsFoetale seriePoidsFoetale = new SeriePoidsFoetale();
                chartCroissance.Series.Add(seriePoidsFoetale);
                seriePoidsFoetale.ChartArea = "aireCroissance";
            }
        }

        #region GESTION DES CHIFFRES
        private void pnl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            short val;
            if (!Int16.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void pnl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        #endregion END GESTION DES CHIFFRES
        #endregion END METHODES LOCALES
    }
}
