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
        List<Classes.Element> listesNew = null;
        List<Classes.Element> listesModifie = null;
        List<Classes.Element> listesAjoute = null;

        //Variable cree uniqueemnt pour la methode GETBINDING
        List<Classes.Element> elements = null;
        List<Grid> grids = null;


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
            List<Reference> langues = new ElementBase().GetLangue();
            for (int j = 0; j < langues.Count; ++j)
            {
                Classes.Element elt = new Classes.Element();
                elt.CleLangue = langues[j].Cle;
                elt.Label = string.Empty;
                listes.Add(elt);
            }

            listesNew = new List<Classes.Element>();
            foreach(Classes.Element e in listes)
            {
                listesNew.Add(e);
            }

            SetBindingGrid();


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
            listesNew = new List<Classes.Element>();
            foreach (Classes.Element e in listes)
            {
                listesNew.Add(e);
            }
            SetBindingGrid(); 
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e){Close();}

        private void buttonIdentification_Click(object sender, RoutedEventArgs e) { new GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender)); }

        private void buttonValidate_Click(object sender, RoutedEventArgs e)
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

        private List<Classes.Element> GetBinding()
        {
            //Creation d'une liste d'elements
            elements = new List<Classes.Element>();
            //Creation de la liste des grids
            grids = new GestionGrille().GetGrid(gridCentre);
            //Recuperation des datacontexts et conversion en elment ajoute à la liste des elelemntd
            for (int i = 1; i < grids.Count;++i)
            {
                Classes.Element e = (Classes.Element)grids[i].DataContext;
                elements.Add(e);
            }
            return elements;
        }

        private void SetBindingGrid()
        {
            List<Grid> grids = new GestionGrille().GetGrid(gridCentre);          
            for (int i = 0; i < listesNew.Count; ++i)
            {
                //Pas de datacontext sur la premiere grille
                grids[i +1].DataContext = listesNew[i];
            }
        }     

        private void buttonCancel_Click(object sender, RoutedEventArgs arg)
        {
           
        }

        private void SendDatabase_CanExecute(object sender, CanExecuteRoutedEventArgs arg)
        {
            bool different = false;
            if(listes != null && listesNew != null)
            {
                for (int i = 0; i < listes.Count; ++i)
                {
                    if(!(listes[i].Equals(listesNew[i])))
                    {
                        different = true;
                    }
                }
            }
        
            arg.CanExecute = different;          
        }

        private void SendDatabase_Executed(object sender, ExecutedRoutedEventArgs arg)
        {
          
                #region Traitement de la listeAjoute
            
                if (listesAjoute.Count > 0)
                {
                    for (int j = listesAjoute.Count; j > 0; --j)
                    {
                        for (int i = listesModifie.Count; i > 0; --i)
                        {
                            if (listesAjoute[j].CleLangue == listesModifie[i].CleLangue)
                            {
                                if (listesAjoute[j].Equals(listesModifie[i]))
                                {
                                    listesAjoute.RemoveAt(j);
                                    listesModifie.RemoveAt(i);
                                }
                                else
                                {
                                    new ElementBase().SetNewElementLangue(listesAjoute[j].CleElement, listesAjoute[j].CleLangue, listesAjoute[j].Label, listesAjoute[j].Description);
                                }
                            }
                        }
                    }
                }
                #endregion

                /////////
                for (int j = listes.Count; j > 0; --j)
                {
                    for (int i = listesModifie.Count; i > 0; --i)
                    {
                        if (listes[j].CleLangue == listesModifie[i].CleLangue)
                        {
                            if (!(listes[j].Equals(listesModifie[i])))
                            {
                                new ElementBase().UpdateElementLangue(listesAjoute[j].CleElement, listesAjoute[j].CleLangue, listesAjoute[j].Label, listesAjoute[j].Description);
                            }
                           
                        }
                    }
                }
                ///////////
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //TextBox tb = (TextBox)sender;
            //if(tb.Text.Trim().Length > 4)
                //listesModifie = GetBinding();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //listesModifie = GetBinding();
        }

        private void checkBox_Clicked(object sender, RoutedEventArgs e)
        {
            ////Conversion du sender
            //CheckBox cb = (CheckBox)sender;
            ////Recherche du parent du sender
            //Panel panel = (Panel)cb.Parent;
            //GroupBox groupBox = (GroupBox)panel.Parent;
            //Grid grid = (Grid)groupBox.Parent;
            //Grid grid1 = (Grid)grid.Parent;
            //MessageBox.Show("Grid n° " + new GestionGrille().GetIndexGrille(grid1).ToString());
            

        }

        private void buttonTerminer_Click(object sender, RoutedEventArgs e)
        {
            listesNew = GetBinding();
        }
    }
}


