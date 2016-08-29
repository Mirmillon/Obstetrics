using System.Windows;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour PregnantWomenList.xaml
    /// </summary>
    public partial class PregnantWomenList : Window
    {
        public PregnantWomenList()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
