using System.Windows;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour PeopleList.xaml
    /// </summary>
    public partial class PeopleList : Window
    {
        public PeopleList()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }

    
}
