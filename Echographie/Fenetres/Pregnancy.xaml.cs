using System.Windows;

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
    }
}
