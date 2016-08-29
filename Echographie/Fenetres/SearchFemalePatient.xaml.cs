using System.Windows;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour SearchFemalePatient.xaml
    /// </summary>
    public partial class SearchFemalePatient : Window
    {
        public SearchFemalePatient()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
