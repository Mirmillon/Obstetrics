using System.Windows;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Patiente.xaml
    /// </summary>
    public partial class Patiente : Window
    {
        public Patiente()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
