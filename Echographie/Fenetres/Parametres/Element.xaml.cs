using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Echographie.Classes;
using Echographie.Classes.Parametres;
using Echographie.RDMS.Parametres;
using Echographie.Utilitaires;


namespace Echographie.Fenetres.Parametres
{
    /// <summary>
    /// Logique d'interaction pour Element.xaml
    /// </summary>
    public partial class Element : Window
    {

        List<Classes.Element> listes = null;
        List<Classes.Element> listesConnecte = null;
        List<Classes.Element> listesModifie = null;
        List<Classes.Element> listesAjoute = null;

        public Element()
        {
            InitializeComponent();
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionFrench, new ElementBase().GetDimensionFr(), checkBox_Clicked);
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionEnglish, new ElementBase().GetDimensionEng(), checkBox_Clicked);
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionTagalog, new ElementBase().GetDimensionTag(), checkBox_Clicked);

            new GestionComboBox().SetComboxReference(new ElementBase().GetLangue(), comboBoxLangue,0);

            buttonValidate.Command = DatabaseCommand.SendDatabase;

            CommandBinding binding = new CommandBinding();
            binding.Command = DatabaseCommand.SendDatabase;
            binding.Executed += SendDatabase_Executed;
            binding.CanExecute += SendDatabase_CanExecute;
            CommandBindings.Add(binding);

            /////////
            listes = new List<Classes.Element>();
            listesConnecte = new List<Classes.Element>();
            listesAjoute = new List<Classes.Element>();
            List<Reference> langues = new ElementBase().GetLangue();
            for (int j = 0; j < langues.Count; ++j)
            {
                Classes.Element elt = new Classes.Element();
                Classes.Element elt1 = new Classes.Element();
                Classes.Element elt2 = new Classes.Element();
                elt2.CleLangue = elt1.CleLangue = elt.CleLangue = langues[j].Cle;
                elt2.Langue = elt1.Langue = elt.Langue = langues[j].Label;
                elt2.Label = elt1.Label = elt.Label = string.Empty;
                elt2.Description = elt1.Description = elt.Description = string.Empty;
                listes.Add(elt);
                listesConnecte.Add(elt1);
                listesAjoute.Add(elt2);
            }

            SetBindingGrid(listesConnecte);
        }

        public Element(int cleElement  ) : this()
        {
            listes = new ElementBase().GetElementLangue(cleElement);
            List<Reference> langues = new ElementBase().GetLangue();
            listesAjoute = new List<Classes.Element>();
            ////////////////////////////////////////
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
                    listesAjoute.Add(elt);
                }
            }
            ////////////////////////////////////
            if (listesAjoute.Count >0)
            {             
                foreach(Classes.Element e in listesAjoute)
                {
                    listes.Add(e);
                }              
            }
            ////////////////////////////////////////////
            var r = from e in listes
                    orderby e.CleLangue
                    select e;

            listes = r.ToList();
            ///////////////////////////////////////////////
            listesConnecte = new List<Classes.Element>();
            new GestionListe().Copier(listes, listesConnecte);
            SetBindingGrid(listesConnecte);
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e){Close();}

        private void buttonIdentification_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender)); }

        private void buttonValidate_Click(object sender, RoutedEventArgs e){}

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

        private List<Classes.Element> GetBinding()
        {
            //Creation d'une liste d'elements
            List<Classes.Element> elements = new List<Classes.Element>();
            //Recuperation des datacontexts et conversion en elment ajoute à la liste des elelemntd
            List<Grid>  grids = new GestionGrille().GetGrid(gridCentre);
            //Recuperation des datacontexts et conversion en elment ajoute à la liste des elelemntd
            for (int i = 1; i < grids.Count; ++i)
            {
                Classes.Element e = (Classes.Element)grids[i].DataContext;
                elements.Add(e);
            }
            return elements;
        }

        private void SetBindingGrid(List<Classes.Element> l)
        {
            List<Grid> grids = new GestionGrille().GetGrid(gridCentre);          
            for (int i = 0; i < l.Count; ++i)
            {
                //Pas de datacontext sur la premiere grille
                grids[i +1].DataContext = l[i];
            }
        }     

        private void buttonCancel_Click(object sender, RoutedEventArgs arg)
        {
           
        }

        private void SendDatabase_CanExecute(object sender, CanExecuteRoutedEventArgs arg)
        {
            bool different = false;
            if (listes != null && listesModifie != null)
            {
                for (int i = 0; i < listes.Count; ++i)
                {
                    bool d = listes[i].Description == listesModifie[i].Description;
                    bool l = listes[i].Label == listesModifie[i].Label;

                    if ((!d) || (!l))
                        different = true;
                }
            }
            arg.CanExecute = different;
        }

        private void SendDatabase_Executed(object sender, ExecutedRoutedEventArgs arg)
        {

            #region Traitement de la listeAjoute

            if (listesAjoute.Count > 0)
            {
                List<Classes.Element> listesAAjouter = new List<Classes.Element>();
                //listesAjoute et listesModifie doivent etre de la meme longuer
                for (int j = listesAjoute.Count - 1; j >= 0; --j)
                {
                    for (int i = listesModifie.Count -1; i >= 0; --i)
                    {
                        bool d = listesAjoute[j].Description == listesModifie[i].Description;
                        bool l = listesAjoute[j].Label == listesModifie[i].Label;
                        bool langue = listesAjoute[j].CleLangue == listesModifie[i].CleLangue;
                        if ((langue) && (!(d) || !(l)))
                        {
                            listesAAjouter.Add(listesModifie[i]);
                        }
                    }
                }

                if (listesAAjouter.Count > 0)
                {
                    int cle = listesAAjouter[0].CleElement;
                    if (cle > 0)
                    {
                        foreach (Classes.Element e in listesAAjouter)
                        {
                            new ElementBase().SetNewElementLangue(e.CleElement, e.CleLangue, e.Label, e.Description);
                        }
                    }
                    else
                    {
                        cle = new ElementBase().SetElement("XXXXX");
                        foreach (Classes.Element e in listesAAjouter)
                        {
                            new ElementBase().SetNewElementLangue(cle, e.CleLangue, e.Label, e.Description);
                        }

                    }
                }
            }

            #endregion
            else
            {
                for (int j = 0; j < listes.Count; ++j)
                {
                    bool d = listes[j].Description == listesModifie[j].Description;
                    bool l = listes[j].Label == listesModifie[j].Label;
                    bool langue = listes[j].CleLangue == listesModifie[j].CleLangue;

                    if  ((langue) && (!(d) || !(l)))
                    {
                        //new ElementBase().UpdateElement(listesModifie[j].CleElement);
                      new ElementBase().UpdateElementLangue(listesModifie[j].CleElement, listesModifie[j].CleLangue, listesModifie[j].Label, listesModifie[j].Description);
                    }
                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {}

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {}

        private void checkBox_Clicked(object sender, RoutedEventArgs e) {}

        private void buttonTerminer_Click(object sender, RoutedEventArgs e)
        {
            listesModifie =  new List<Classes.Element>();
            listesModifie = GetBinding();
        }
    }
}


