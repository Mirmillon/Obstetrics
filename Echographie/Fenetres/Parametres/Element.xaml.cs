using Echographie.Classes;
using Echographie.RDMS.Parametres;
using Echographie.Utilitaires;
using System.Windows;
using System.Windows.Controls;

namespace Echographie.Fenetres.Parametres
{
    /// <summary>
    /// Logique d'interaction pour Element.xaml
    /// </summary>
    public partial class Element : Window
    {

        private Classes.Element elt = null;

        public Element()
        {
            InitializeComponent();
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionFrench, new ElementBase().GetDimensionFr());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionEnglish, new ElementBase().GetDimensionEng());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionTagalog, new ElementBase().GetDimensionTag());

            new GestionComboBox().SetComboxReference(new ElementBase().GetLangue(), comboBoxLangue,0);

            elt = new Classes.Element();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e){Close();}

        private void buttonIdentification_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender)); }

       
        private void buttonValidate_Click(object sender, RoutedEventArgs e)
        {
            //Recherche de la grille qui est visible
            int i = -1;
            foreach(Grid g in gridCentre.Children)
            {
                if(g.IsVisible)
                {
                    i = gridCentre.Children.IndexOf(g);
                }
            }
            //L'action du bouton dépend le grille qui est visible
            switch(i)
            {
                case 0:

                    break;
                case 1://Français
                    break;
                case 2://Anglais
                    break;
                case 3://Tagalog
                    break;
                default:
                    break;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBoxLangue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SetDataElement()
        {
           
            if (textBoxElementFrench.Text.Trim().Length > 0)
            {
                elt.Labels.Add(new Reference(1, textBoxElementFrench.Text));
                if (textBoxDescriptionFrench.Text.Trim().Length > 0)
                {
                    elt.Descriptions.Add(new Reference(1, textBoxDescriptionFrench.Text));
                }
            }
            if (textBoxElementEnglish.Text.Trim().Length > 0)
            {
                elt.Labels.Add(new Reference(2, textBoxElementEnglish.Text));
                if (textBoxDescriptionEnglish.Text.Trim().Length > 0)
                {
                    elt.Descriptions.Add(new Reference(2, textBoxDescriptionEnglish.Text));
                }
            }
            if (textBoxElementTagalog.Text.Trim().Length > 0)
            {
                elt.Labels.Add(new Reference(3, textBoxElementTagalog.Text));
                if (textBoxDescriptionTagalog.Text.Trim().Length > 0)
                {
                    elt.Descriptions.Add(new Reference(3, textBoxDescriptionTagalog.Text));
                }
            }


        }
    }
}
