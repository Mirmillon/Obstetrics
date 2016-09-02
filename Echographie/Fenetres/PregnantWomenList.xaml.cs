using Echographie.Acteurs;
using Echographie.RDMS;
using Echographie.Utilitaires;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

            List<PregnantWoman> pregnantWomen = new DataBase().GetListPregnantWomen();
            gridData.ItemsSource = pregnantWomen;

            new GestionComboBox().SetComboxReference(new DataBase().GetPregnancyKind(), dataGridComboBoxKind);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void ButtonEchographie_Click(object sender, RoutedEventArgs e)
        {
            PregnantWoman p = (PregnantWoman)gridData.SelectedItem as PregnantWoman;
            if (p!=null)
            {
                new UsScan(p.ClePeople,p.UneGrossesse.CleGrossesse).Show();
                Close();
            }
        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(gridData.ItemsSource) as ListCollectionView;
            
            if (view != null)
            {
                if(textBoxFilter.Text.Trim().Length > 0 && (view != null))
                {
                    
                }
            }
        }
    }
}
