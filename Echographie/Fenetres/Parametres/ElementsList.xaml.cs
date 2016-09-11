using Echographie.Classes;
using Echographie.RDMS;
using Echographie.RDMS.Parametres;
using Echographie.Utilitaires;
using System.Collections.Generic;
using System.Windows;

namespace Echographie.Fenetres.Parametres
{
    /// <summary>
    /// Logique d'interaction pour ElementsList.xaml
    /// </summary>
    public partial class ElementsList : Window
    {
        List<ElementBiometrique> elementsBiometrique = null;
        List<ElementAnatomique> elementsAnatomique = null;
        List<Reference> dimensions = null;

        public ElementsList()
        {
            InitializeComponent();

            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyUscKind(), comboBoxPregnancyUscKind, 1);
            elementsBiometrique = new ElementBase().GetElementBiometrie1T();
            elementsAnatomique = new ElementBase().GetElementsAnatomiques1T();
            dimensions = new DataBase().GetDimension();
            new GestionComboBox().SetComboxReference(dimensions, dataGridComboBoxDimension);

            radionButtonBiometric.IsChecked = true;
            comboBoxPregnancyUscKind.SelectedIndex = 0;

            new GestionComboBox().SetComboxReference(new ElementBase().GetLangue(), comboBoxLangue, 1);
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void buttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            new Element().Show();
        }

        private void RadioButtonElement_Click(object sender, RoutedEventArgs e)
        {
            if (radionButtonBiometric.IsChecked == true)
            {
                switch(comboBoxPregnancyUscKind.SelectedIndex)
                {
                    case 0:
                        if(elementsBiometrique != null)
                        {
                            dataGrid.ItemsSource = null;
                            dataGrid.ItemsSource = elementsBiometrique;
                        }
                        break;
                    case 1:
                        dataGrid.ItemsSource = null;
                        break;
                }
            }
            else
            {
                switch (comboBoxPregnancyUscKind.SelectedIndex)
                {
                    case 0:
                        if(elementsAnatomique != null)
                        {
                            dataGrid.ItemsSource = null;
                            dataGrid.ItemsSource = elementsAnatomique;
                        }
                        break;
                    case 1:
                        dataGrid.ItemsSource = null;
                        break;
                }
            }

        }

        private void comboBoxLangue_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void buttonVoir_Click(object sender, RoutedEventArgs e)
        {
            Classes.Element p = (Classes.Element)dataGrid.SelectedItem as Classes.Element;
            if (p != null)
            {
                new Element(p.CleElement).Show();
                Close();
            }
        }
    }
}
