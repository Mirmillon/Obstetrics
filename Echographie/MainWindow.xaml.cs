using System.Windows;
using Echographie.Fenetres;

namespace Echographie
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {InitializeComponent();}

        private void ButtonClose_Click(object sender, RoutedEventArgs e) {Close();}

        private void ButtonNewPatiente_Click(object sender, RoutedEventArgs e)  {Show(new Patiente());}

        private void ButtonNewPregnantWoman_Click(object sender, RoutedEventArgs e) {Show(new Pregnancy());}

        private void ButtonNewUltrasound_Click(object sender, RoutedEventArgs e) {Show(new UsScan());}

        private void ButtonPeopleList_Click(object sender, RoutedEventArgs e){ Show(new PeopleList()); }

        private void ButtonPatientList_Click(object sender, RoutedEventArgs e){Show(new PatientList());}

        private void ButtonPregnantWomenList_Click(object sender, RoutedEventArgs e) {Show(new PregnantWomenList());}

        private void ButtonSearchPeople_Click(object sender, RoutedEventArgs e) {Show(new SearchPeople());}

        private void ButtonSearchFemalePatientList_Click(object sender, RoutedEventArgs e){ Show(new SearchFemalePatient()); }

        private void Show(Window w)
        {
            w.Show();
            WindowState = WindowState.Minimized;
        }
    }
}
