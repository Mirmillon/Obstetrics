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
        private List<Classes.Element> listes = null;
        private List<Classes.Element> listesConnecte = null;
        private List<Classes.Element> listesModifie = null;
        private List<Classes.Element> listesAjoute = null;
        private List<ReferenceCheck> listesDimensions = null;
        private List<ReferenceCheck> listesDimensionsModifie = null;

        private int cleElement;

        #region CONSTRUCTOR

        public Element()
        {
            InitializeComponent();
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionFrench, new ElementBase().GetDimensionFr());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionEnglish, new ElementBase().GetDimensionEng());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionTagalog, new ElementBase().GetDimensionTag());

            new GestionComboBox().SetComboxReference(new ElementBase().GetLangue(), comboBoxLangue, 0);

            List<Reference> l = new ElementBase().GetDimensionFr();
            List<ReferenceCheck> listeDFr = new List<ReferenceCheck>();
            new GestionReferenceCheck().Copier(l, listeDFr);
            listesDimensions = new List<ReferenceCheck>();
            new GestionReferenceCheck().Copier(l, listesDimensions);
           
            new GestionWrapPanel().SetBinding(wrapPanelDimensionFrench, listeDFr);
            new GestionWrapPanel().SetBinding(wrapPanelDimensionEnglish, listeDFr, new ElementBase().GetDimensionEng());
            new GestionWrapPanel().SetBinding(wrapPanelDimensionTagalog, listeDFr, new ElementBase().GetDimensionTag());

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
            new GestionGrille().SetBindingGridCentre(listesConnecte,gridCentre);


        }

        public Element(int cleElement) : this()
        {
            //GESTION DES ELEMENTS
            listes = new ElementBase().GetElementLangue(cleElement);
            List<Reference> langues = new ElementBase().GetLangue();
            listesAjoute = new List<Classes.Element>();
            ////////////////////////////////////////
            for (int i = 0; i < langues.Count; ++i)
            {
                int cle = langues[i].Cle;
                bool absent = true;
                for (int j = 0; j < listes.Count; ++j)
                {
                    if (listes[j].CleLangue == cle)
                    {
                        absent = false;
                    }
                }
                if (absent)
                {
                    Classes.Element elt = new Classes.Element();
                    elt.CleElement = cleElement;
                    elt.CleLangue = cle;
                    elt.Label = string.Empty;
                    listesAjoute.Add(elt);
                }
            }
            ////////////////////////////////////
            if (listesAjoute.Count > 0)
            {
                foreach (Classes.Element e in listesAjoute)
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
            new GestionElement().Copier(listes, listesConnecte);
            new GestionGrille().SetBindingGridCentre(listesConnecte, gridCentre);         
            //GESTION DES DIMENSIONS
            List<ReferenceCheck> listOrigine = new ElementBase().GetElementCheck(cleElement);
            List<ReferenceCheck> listConnecte = new GestionReferenceCheck().CheckListReferenceCheck(listOrigine, listesDimensions);
            listesDimensions.Clear();
            new GestionReferenceCheck().Copier(listConnecte, listesDimensions);
            new GestionWrapPanel().SetBinding(wrapPanelDimensionFrench, listConnecte);
            new GestionWrapPanel().SetBinding(wrapPanelDimensionEnglish, listConnecte, new ElementBase().GetDimensionEng());
            new GestionWrapPanel().SetBinding(wrapPanelDimensionTagalog, listConnecte, new ElementBase().GetDimensionTag());
            //GESTION DES TYPES US
        } 
       
        #endregion FIN CONSTRUCTOR

        #region CONTROLS

        private void buttonClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void buttonCancel_Click(object sender, RoutedEventArgs arg) { }

        private void buttonTerminer_Click(object sender, RoutedEventArgs e)
        {
            listesModifie = new List<Classes.Element>();
            listesModifie = GetBinding();
            listesDimensionsModifie = new GestionWrapPanel().GetBindingWrapPanel(wrapPanelDimensionFrench);
        }

        private void buttonIdentification_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender)); }

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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) { }

        #endregion FIN CONTROL

        #region BINDINGS
        private List<Classes.Element> GetBinding()
        {
            List<Classes.Element> elements = new List<Classes.Element>();
            List<Grid> grids = new GestionGrille().GetGrid(gridCentre);
            for (int i = 1; i < grids.Count; ++i)
            {
                Classes.Element e = (Classes.Element)grids[i].DataContext;
                elements.Add(e);
            }
            return elements;
        }

        #endregion FIN BINDINGS

        #region COMMANDS
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

            if(listesDimensions != null  && listesDimensionsModifie != null)
            {
                for (int i = 0; i < listesDimensions.Count; ++i)
                {
                    bool d = listesDimensions[i].Check == listesDimensionsModifie[i].Check;
                    // TODO Verifier la cle cle dimension non cle langue
                    if (!d) 
                        different = true;
                }
            }        
            arg.CanExecute = different;
        }

        private void SendDatabase_Executed(object sender, ExecutedRoutedEventArgs arg)
        {
            if (listesAjoute.Count > 0)
            {
                List<Classes.Element> listesAAjouter = new List<Classes.Element>();
                for (int j = listesAjoute.Count - 1; j >= 0; --j)
                {
                    for (int i = listesModifie.Count - 1; i >= 0; --i)
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
                    cleElement = listesAAjouter[0].CleElement;
                    if (cleElement > 0)
                    {
                        foreach (Classes.Element e in listesAAjouter)
                        {
                            new ElementBase().SetElementLangue(e.CleElement, e.CleLangue, e.Label, e.Description);
                        }
                    }
                    else
                    {
                        cleElement = new ElementBase().SetElement("XXXXX");
                        foreach (Classes.Element e in listesAAjouter)
                        {
                            new ElementBase().SetElementLangue(cleElement, e.CleLangue, e.Label, e.Description);
                        }                      
                    }
                }
                else
                {
                    cleElement = listes[0].CleElement;
                }
            }
            else
            {
                cleElement = listes[0].CleElement;
                for (int j = 0; j < listes.Count; ++j)
                {
                    bool d = listes[j].Description == listesModifie[j].Description;
                    bool l = listes[j].Label == listesModifie[j].Label;
                    bool langue = listes[j].CleLangue == listesModifie[j].CleLangue;

                    if ((langue) && (!(d) || !(l)))
                    {
                        //new ElementBase().UpdateElement(listesModifie[j].CleElement);
                        new ElementBase().UpdateElementLangue(listesModifie[j].CleElement, listesModifie[j].CleLangue, listesModifie[j].Label, listesModifie[j].Description);
                    }
                } 
            }
            //Traitements des dimensions
            new GestionReferenceCheck().SetDataBaseElementCheck(listesDimensions, listesDimensionsModifie, cleElement);
        }
        #endregion

        private void Window_Activated(object sender, System.EventArgs e)
        {
            listesModifie = new List<Classes.Element>();
            listesModifie = GetBinding();
            listesDimensionsModifie = new GestionWrapPanel().GetBindingWrapPanel(wrapPanelDimensionFrench);
        }
    }
}


