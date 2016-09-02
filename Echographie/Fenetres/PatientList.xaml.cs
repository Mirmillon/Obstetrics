using System.Windows;
using Echographie.RDMS;
using Echographie.Utilitaires;
using Echographie.Acteurs;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour PatientList.xaml
    /// </summary>
    public partial class PatientList : Window
    {
        public PatientList()
        {
            InitializeComponent();

            new GestionComboBox().SetComboxReference(new DataBase().GetGenre(), dataGridComboBoxGender);
            new GestionComboBox().SetComboxReference(new DataBase().GetCivilStatut(), dataGridComboBoxStatut);
            new GestionComboBox().SetComboxReference(new DataBase().GetOutcome(), dataGridComboBoxOutcome);

            radionButtonFemale.IsChecked = true;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonEchographie_Click(object sender, RoutedEventArgs e)
        {
            PregnantWoman p = (PregnantWoman)gridData.SelectedItem as PregnantWoman;
            if (p != null)
            {
                if (p.UneGrossesse.CleGrossesse > 0)
                {
                    new UsScan(p.ClePeople, p.UneGrossesse.CleGrossesse).Show();
                    Close();
                }
                else
                {
                    new UsScan(p.ClePeople).Show();
                    Close();
                }
            }
        }

        private void RadionButton_Checked(object sender, RoutedEventArgs e)
        {
            SetControl();
        }

        private void SetControl()
        {
            if (radionButtonFemale.IsChecked == true)
            {
                gridData.ItemsSource = null;
                gridData.ItemsSource = new DataBase().GetPeopleFemale();
                dataGridComboBoxGender.Visibility = Visibility.Collapsed;

                dataGridColCle.Visibility = Visibility.Collapsed;
            }
            else if (radionButtonMale.IsChecked == true)
            {
                gridData.ItemsSource = null;
                gridData.ItemsSource = new DataBase().GetPeopleMale();
                dataGridComboBoxGender.Visibility = Visibility.Collapsed;
            }
            else
            {
                gridData.ItemsSource = null;
                dataGridComboBoxGender.Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
