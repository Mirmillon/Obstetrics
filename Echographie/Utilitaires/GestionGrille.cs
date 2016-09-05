using System.Windows;
using System.Windows.Controls;
using Echographie.ControlUser;
using Echographie.Classes;
using System.Collections.Generic;

namespace Echographie.Utilitaires
{
    public class GestionGrille
    {
        #region VISIBILITY

        public void GridVisibilty(Grid g, int pos)
        {
            int nb = g.Children.Count;
            g.Children[pos].Visibility = Visibility.Visible;
            for (int i = 0; i < pos; ++i)
            {
                g.Children[i].Visibility = Visibility.Hidden;
            }
            for (int i = pos + 1; i < nb; ++i)
            {
                g.Children[i].Visibility = Visibility.Hidden;
            }
        }

        #endregion END VISIBILITY

        #region AJOUT GRID CLASSIQUE

        //public void GridAjout(Grid g)
        //{
        //    for (int j = 0; j < g.RowDefinitions.Count; ++j)
        //    {
        //        for (int i = 0; i < g.ColumnDefinitions.Count; i = i + 3)
        //        {                   
        //            UnitDataAnatomie grid = new UnitDataAnatomie();
        //            Grid.SetColumnSpan(grid, 3);
        //            Grid.SetRow(grid, j);
        //            Grid.SetColumn(grid, i);
        //            g.Children.Add(grid);
        //        }
        //    }
        //}

        #endregion FIN AJOUT GRID CLASSIQUE

        #region AJOUT UNITBIOMETRIE

        //public void GridAjoutUserData(Grid g)
        //{
        //    for (int j = 0; j < g.RowDefinitions.Count; ++j)
        //    {
        //        for (int i = 0; i < g.ColumnDefinitions.Count; i = i + 3)
        //        {
        //            UnitBiometrie c = new UnitBiometrie();
        //            Grid.SetColumnSpan(c, 3);
        //            Grid.SetRow(c, j);
        //            Grid.SetColumn(c, i);
        //            g.Children.Add(c);
        //        }
        //    }
        //}

        public void GridAjoutUserDataBiometrie(Grid g, int indexDebut, int indexFin)
        {
            int nb = (indexFin - indexDebut) + 1;
            for (int j = 0; j < nb; ++j)
            {
                for (int i = 0; i < g.ColumnDefinitions.Count; i = i + 3)
                {
                    UnitDataBiometrie c = new UnitDataBiometrie(new ElementBiometrique());
                    Grid.SetColumnSpan(c, 3);
                    Grid.SetRow(c, indexDebut);
                    Grid.SetColumn(c, i);
                    g.Children.Add(c);
                }
                indexDebut = indexDebut + 1;
            }
        }

        public void GridAjoutUserDataBiometrieLigne(Grid g, int indexDebut, int indexFin)
        {
            int nb = (indexFin - indexDebut) + 1;
            for (int j = 0; j < nb; ++j)
            {
                for (int i = 3; i < g.ColumnDefinitions.Count; i = i + 3)
                {
                    UnitDataBiometrie c = new UnitDataBiometrie(new ElementBiometrique());
                    Grid.SetColumnSpan(c, 3);
                    Grid.SetRow(c, indexDebut);
                    Grid.SetColumn(c, i);
                    g.Children.Add(c);
                }
                indexDebut = indexDebut + 1;
            }
        }

        public void GridAjoutUserDataAnatomieLigne(Grid g, int indexDebut, int indexFin)
        {
            int nb = (indexFin - indexDebut) + 1;
            for (int j = 0; j < nb; ++j)
            {
                for (int i = 3; i < g.ColumnDefinitions.Count; i = i + 3)
                {
                    UnitDataAnatomie c = new UnitDataAnatomie(new ElementAnatomique());
                    Grid.SetColumnSpan(c, 3);
                    Grid.SetRow(c, indexDebut);
                    Grid.SetColumn(c, i);
                    g.Children.Add(c);
                }
                indexDebut = indexDebut + 1;
            }
        }

        public void GridAjoutUserDataAnatomie(Grid g, int indexDebut, int indexFin)
        {
            int nb = (indexFin - indexDebut) + 1;
            for (int j = 0; j < nb; ++j)
            {
                for (int i = 0; i < g.ColumnDefinitions.Count; i = i + 3)
                {
                    UnitDataAnatomie c = new UnitDataAnatomie(new ElementAnatomique());
                    Grid.SetColumnSpan(c, 3);
                    Grid.SetRow(c, indexDebut);
                    Grid.SetColumn(c, i);
                    g.Children.Add(c);
                }
                indexDebut = indexDebut + 1;
            }
        }
        #endregion FIN AJOUT UNITBIOMETRIE

        #region BINDINGS CLASSIQUE AVEC OU SANS LIST COMME PARAMETRE

        public void SetBindingMorphology(Grid grid, List<ElementAnatomique> elements)
        {
            //Liste des elements du 1T

            //Liaison DataContext pour chaque uniteData de la grid biometric 1T
            //Le seul moyen en attendant les UserControl eest de slectionner les UnitData sur leur nom gridUD
            //1.Liste des gridUnit
            List<Grid> grids = new List<Grid>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        grids.Add(g);
                    }
                }
            }
            //2.Affection du DataContext
            for (int i = 0; i < grids.Count; ++i)
            {
                grids[i].DataContext = elements[i];
            }
        }

        public void SetBindingBiometrics(Grid grid, List<ElementBiometrique> elements)
        {
            //Liste des elements du 1T

            //Liaison DataContext pour chaque uniteData de la grid biometric 1T
            //Le seul moyen en attendant les UserControl eest de slectionner les UnitData sur leur nom gridUD
            //1.Liste des gridUnit
            List<Grid> grids = new List<Grid>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {

                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        grids.Add(g);
                    }
                }
            }
            //2.Affection du DataContext
            for (int i = 0; i < grids.Count; ++i)
            {
                grids[i].DataContext = elements[i];
            }
        }

        public List<ElementBiometrique> GetBindingBiometrics(Grid grid)
        {
            List<ElementBiometrique> elements = new List<ElementBiometrique>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        object o = g.DataContext;
                        ElementBiometrique elt = o as ElementBiometrique;
                        if (elt is ElementBiometrique)
                        {
                            elements.Add(elt);
                        }
                    }
                }
            }
            return elements;
        }

        public List<ElementAnatomique> GetBindingAnatomie(Grid grid)
        {
            List<ElementAnatomique> elements = new List<ElementAnatomique>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        object o = g.DataContext;
                        ElementAnatomique elt = o as ElementAnatomique;
                        if (elt is ElementAnatomique)
                        {
                            elements.Add(elt);
                        }
                    }
                }
            }
            return elements;
        }

        public List<ElementAnatomique> GetBindingUnitAnatomie(Grid grid)
        {
            List<ElementAnatomique> elements = new List<ElementAnatomique>();
            foreach (Panel control in grid.Children)
            {
                Grid g = control as Grid;
                if (g is Grid)
                {
                    if (g.Background.ToString() == "#00FFFFFF")
                    {
                        object o = g.DataContext;
                        ElementAnatomique elt = o as ElementAnatomique;
                        if (elt is ElementAnatomique)
                        {
                            elements.Add(elt);
                        }
                    }
                }
            }
            return elements;
        }
        
        #endregion FINBINDINGS CLASSIQUE AVEC OU SANS LIST COMME PARAMETRE

        #region BINDINGS UNITBIOMETRIE

        public void SetBindingBiometricsUnitBiometrie(Grid grid, List<ElementBiometrique> elements)
        {
            List<UnitBiometrie> unites = new List<UnitBiometrie>();
            foreach (UnitBiometrie control in grid.Children)
            {
                unites.Add(control);
            }
            for (int i = 0; i < unites.Count; ++i)
            {
                unites[i].DataContext = elements[i];
            }
        }

        public List<ElementBiometrique> GetBindingUnitDataBiometrics(Grid grid)
        {
            List<ElementBiometrique> elements = new List<ElementBiometrique>();
            foreach (UnitBiometrie control in grid.Children)
            {
                object o = control.DataContext;
                ElementBiometrique elt = o as ElementBiometrique;
                if (elt is ElementBiometrique)
                {
                    elements.Add(elt);
                }
            }
            return elements;
        }

        #endregion END BINDINGS UNITBIOMETRIE
    }
}
