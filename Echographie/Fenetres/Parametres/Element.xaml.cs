using Echographie.Classes;
using Echographie.RDMS;
using Echographie.RDMS.Parametres;
using Echographie.Utilitaires;
using System.Collections.Generic;
using System.Linq;
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

        public Element(int cleElement  ) : this()
        {
            List<Classes.Element> listes = new ElementBase().GetElementLangue(cleElement);
            List<Reference> langues = new ElementBase().GetLangue();
            List<Classes.Element> l = new List<Classes.Element>();
            for (int i = 0; i < langues.Count; ++ i)
            {
                int cle = langues[i].Cle;
                bool absent = true;
                for (int j =0; j < listes.Count;++j)
                {
                    if (listes[j].CleLangue == cle)
                    {
                        absent = false;
                    }
                }
                if(absent)
                {
                    Classes.Element elt = new Classes.Element();
                    elt.CleElement = cleElement;
                    elt.CleLangue = cle;
                    elt.Label = string.Empty;
                    l.Add(elt);
                }
            }
            //MessageBox.Show(l.Count.ToString());
            if (l.Count >0)
            {
                foreach(Classes.Element e in l)
                {
                    listes.Add(e);
                }
            }
           
            //foreach(Classes.Element e in listes)
            //{
            //    MessageBox.Show(e.CleLangue + " " + e.Label);
            //}
           
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

        private void SetElement()
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
