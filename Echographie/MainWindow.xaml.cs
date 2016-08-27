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

        private void ButtonNewPatiente_Click(object sender, RoutedEventArgs e)
        {
            new Patiente().Show();
            WindowState = WindowState.Minimized;
        }

        private void ButtonNewPregnantWoman_Click(object sender, RoutedEventArgs e)
        {
            new Pregnancy().Show();
            WindowState = WindowState.Minimized;
        }

        private void ButtonNewUltrasound_Click(object sender, RoutedEventArgs e)
        {
            new UsScan().Show();
            WindowState = WindowState.Minimized;
        }
    }
}
