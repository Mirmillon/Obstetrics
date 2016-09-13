﻿using System.Collections.Generic;
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
        List<Classes.Element> listesModifie = null;
        List<Classes.Element> listesAjoute = null;



        public Element()
        {
            InitializeComponent();
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionFrench, new ElementBase().GetDimensionFr());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionEnglish, new ElementBase().GetDimensionEng());
            new GestionWrapPanel().AjoutCheckBox(wrapPanelDimensionTagalog, new ElementBase().GetDimensionTag());

            new GestionComboBox().SetComboxReference(new ElementBase().GetLangue(), comboBoxLangue,0);

            buttonValidate.Command = DatabaseCommand.SendDatabase;

            CommandBinding binding = new CommandBinding();
            buttonValidate.Command = DatabaseCommand.SendDatabase;
            binding.Executed += SendDatabase_Executed;
            binding.CanExecute += SendDatabase_CanExecute;
            CommandBindings.Add(binding);
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
            SetBinding();
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

        private  void SetBinding()
        {
            //Mettre le binding sur les textbox de la premiere page
            List<TextBox> listesTb =new GestionGrille().GetTextBox(gridElement);

            for (int i = 0; i < listesTb.Count; ++i)
            {
                Binding b = new Binding();
                b.Source = listes[i];
                b.Mode = BindingMode.TwoWay;
                b.Path = new PropertyPath("Label");
                listesTb[i].SetBinding(TextBox.TextProperty, b);
            }
            SetBindingGrid();
         }

        private List<Classes.Element> GetBinding()
        {
            List<Classes.Element> l = new List<Classes.Element>();
            //TODO A FAIRE
            return l;
        }

        private void SetBindingGrid()
        {
            List<Grid> listesG = new GestionGrille().GetGrid(gridCentre);
            for (int i = 0; i < listes.Count; ++i)
            {
                listesG[i + 1].DataContext = listes[i];
            }
        }     

        private void buttonCancel_Click(object sender, RoutedEventArgs arg)
        {
           
        }

        private void SendDatabase_CanExecute(object sender, CanExecuteRoutedEventArgs arg)
        {
            bool different = false;
            if(listes != null && listesModifie != null)
            {
                for (int i = 0; i < listes.Count; ++i)
                {
                    if(!(listes[i].Equals(listesModifie[i])))
                    {
                        different = true;
                    }
                }
            }
            arg.CanExecute = different;          
        }

        private void SendDatabase_Executed(object sender, ExecutedRoutedEventArgs arg)
        {
            //Appel du constructeur par defaut
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
                listes = GetBinding();
                foreach (Classes.Element e in listes)
                {
                    if (!string.IsNullOrEmpty(e.Label) || !string.IsNullOrEmpty(e.Description))
                    {
                        new ElementBase().SetNewElement(e.CleLangue, e.Label, e.Description);
                    }
                }
            }
            //Appel second constructeur
            else
            {
                listesModifie = GetBinding();

                var r = from e in listesModifie
                        orderby e.CleLangue
                        select e;

                listesModifie = r.ToList();

                #region Traitement 
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
        }
    }
}


