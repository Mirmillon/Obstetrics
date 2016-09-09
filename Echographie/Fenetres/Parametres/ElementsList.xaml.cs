using Echographie.RDMS;
using Echographie.Utilitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Echographie.Fenetres.Parametres
{
    /// <summary>
    /// Logique d'interaction pour ElementsList.xaml
    /// </summary>
    public partial class ElementsList : Window
    {
        public ElementsList()
        {
            InitializeComponent();

            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyUscKind(), comboBoxPregnancyUscKind, 1);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
