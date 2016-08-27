using System.Windows;

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
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
