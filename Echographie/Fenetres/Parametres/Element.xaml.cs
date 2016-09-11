using Echographie.Classes;
using Echographie.RDMS;
using Echographie.RDMS.Parametres;
using Echographie.Utilitaires;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Echographie.Fenetres.Parametres
{
    /// <summary>
    /// Logique d'interaction pour Element.xaml
    /// </summary>
    public partial class Element : Window
    {

      
        List<Classes.Element> listes = null;

        public Element()
        {
            InitializeComponent();
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionFrench, new ElementBase().GetDimensionFr());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionEnglish, new ElementBase().GetDimensionEng());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionTagalog, new ElementBase().GetDimensionTag());

            new GestionComboBox().SetComboxReference(new ElementBase().GetLangue(), comboBoxLangue,0);

           
        }

        public Element(int cleElement  ) : this()
        {
            listes = new ElementBase().GetElementLangue(cleElement);
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
  
            if (l.Count >0)
            {
                foreach(Classes.Element e in l)
                {
                    listes.Add(e);
                }
            }

            var r = from e in listes
                    orderby e.CleLangue
                    select e;

            listes = r.ToList();

            SetBinding();
            SetBindingGrid();

        }

        private void buttonClose_Click(object sender, RoutedEventArgs e){Close();}

        private void buttonIdentification_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender)); }

       
        private void buttonValidate_Click(object sender, RoutedEventArgs e)
        {

            if (listes == null)
            {
                listes = new List<Classes.Element>();
                List<Reference> langues = new ElementBase().GetLangue();
                for (int j = 0; j < langues.Count; ++j)
                {
                    Classes.Element elt = new Classes.Element();
                    elt.CleLangue = langues[j].Cle;
                    elt.Label = string.Empty;
                    listes.Add(elt);
                }

                SetBinding();
                SetBindingGrid();

                //TODO Insertion dans LE RDMS d'un elment n'existant pas
            }
            else
            {
                for(int i = 0; i < listes.Count;++i )
                {
                    if(listes[i].Indicateur[0] == 0 || listes[i].Indicateur[1] == 0)
                    {
                        MessageBox.Show(listes[i].Label + " changé");
                    }
                }

                //TODO Insertion dans le RDMS d'elment à modifier ou à ajouter
            }

            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBoxLangue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Binding b = new Binding();
            b.Path = new PropertyPath("Text");
            b.Mode = BindingMode.TwoWay;

            switch (comboBoxLangue.SelectedIndex)
            {
                case 0://Francais
                    b.Source = textBoxDescriptionFrench;
                    textBoxDescription.SetBinding(TextBox.TextProperty, b);
                    break;
                case 1://Anglais
                    b.Source = textBoxDescriptionEnglish;
                    textBoxDescription.SetBinding(TextBox.TextProperty, b);
                    break;
                case 2://Tagalog
                    b.Source = textBoxDescriptionTagalog;
                    textBoxDescription.SetBinding(TextBox.TextProperty, b);
                    break;
                default:
                    break;
            }
        }

        private  void SetBinding()
        {
            //Mettre le binding sur les textbox de la premiere page
            List<TextBox> listesTb = GetTextBox();

            for (int i = 0; i < listesTb.Count; ++i)
            {
                Binding b = new Binding();
                b.Source = listes[i];
                b.Mode = BindingMode.TwoWay;
                b.Path = new PropertyPath("Label");
                listesTb[i].SetBinding(TextBox.TextProperty, b);
            }

         
           
        }

        private void SetBindingGrid()
        {
            List<Grid> listesG = GetGrid();
       
            //if (listesG != null)
            //{
                for (int i = 0; i < listes.Count; ++i)
                {
                    listesG[i + 1].DataContext = listes[i];

                }
            //}
        }

        private List<TextBox> GetTextBox()
        {
            List<TextBox> listes = new List<TextBox>();
            foreach (Control c in gridElement.Children)
            {            
                if(c is TextBox)
                {                    
                    if(c.BorderBrush.ToString() == "#FFFFFF00")
                    {
                        TextBox tb = (TextBox)c;
                        listes.Add(tb);
                    }
                }
            }
            return listes;
        }

        private int GetIndexGrille()
        {
            //Recherche de la grille qui est visible
            int i = -1;
            foreach (Grid g in gridCentre.Children)
            {
                if (g.IsVisible)
                {
                    i = gridCentre.Children.IndexOf(g);
                }
            }
            return i;
        }

        private List<Grid> GetGrid()
        {
            List<Grid> listes = new List<Grid>();
            foreach (Grid g in gridCentre.Children)
            {
                listes.Add(g);
            }
            return listes;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            List<Grid> listes =  GetGrid();
            int i = GetIndexGrille();

            Classes.Element elt = new Classes.Element();
            elt = (Classes.Element)listes[i].DataContext;
            MessageBox.Show(elt.Description);

        }
    }
}

