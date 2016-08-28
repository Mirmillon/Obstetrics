using Echographie.Acteurs;
using Echographie.RDMS;
using Echographie.Utilitaires;
using System.Windows;
using System.Windows.Controls;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Patiente.xaml
    /// </summary>
    public partial class Patiente : Window
    {
        Patient personne = null;

        public Patiente()
        {
            InitializeComponent();

            new GestionComboBox().SetComboxReference(new DataBase().GetCivilStatut(), comboBoxCivilStatut, 1);
            new GestionComboBox().SetComboxReference(new DataBase().GetGenre(), comboBoxGender, 1);

            personne = new Patient();
            personne.Statut = 2;
            personne.Gender = 2;
            gridCentre.DataContext = personne;
        }

        public Patiente(int clePersonne) : this()
        {
            personne = new DataBase().GetPeopleByKey(clePersonne);
            gridCentre.DataContext = personne;
            labelTitre.Content = "PATIENT INFORMATION FORM";
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonIdentification_Click(object sender, RoutedEventArgs e)
        {
            new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }

        private void ButtonValidate_Click(object sender, RoutedEventArgs e)
        {
            SetDataBase();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            buttonValidate.IsEnabled = SetValidateEnable() ? true : false;            
        }

        private bool SetValidateEnable()
        {
            bool f = textBoxName.Text.Trim().Length > 0;
            bool m = textBoxMiddleName.Text.Trim().Length > 0;
            bool l = textBoxLastName.Text.Trim().Length > 0;
            bool d = datePickerTextBoxDateBitrth.Text.Trim().Length == 10;

            return ((f) && (l) && (d)) ? true : false;
        }

        private void SetDataBase()
        {
            if (personne.ClePeople < 1)
            {
                personne.ClePeople = new DataBase().SetPersonne(personne.FirstName, personne.MiddleName, personne.LastName, personne.DateBirth, personne.Gender, personne.Statut);
                personne.NumeroPatient = new DataBase().SetPatient(personne.ClePeople);
                if (personne.NumeroPatient > 0)
                {
                    labelInfo.Content = "Patiente registered";
                    buttonValidate.IsEnabled = false;
                }
            }
            else if (personne.ClePeople > 0 && personne.NumeroPatient < 1)
            {
                personne.NumeroPatient = new DataBase().SetPatient(personne.ClePeople);
                if (personne.NumeroPatient > 0)
                {
                    labelInfo.Content = "Patiente registered";
                    buttonValidate.IsEnabled = false;
                }

            }
            else
            {

            }
        }
    }
}
