using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Echographie.Utilitaires
{
    public class UnitData:Control
    {
        private Grid grid = null;

        public UnitData()
        {
            //CAracteristique de la grille
            grid = new Grid();
          
            grid.Background = System.Windows.Media.Brushes.Transparent;
            for (int k = 0; k < 4; ++k)
            {
                ColumnDefinition c = new ColumnDefinition();
                grid.ColumnDefinitions.Add(c);
            }
            //TODO Mettre la derniere colonne à Auto
            //< Label Grid.Row = "0" Grid.Column = "0" Grid.ColumnSpan = "2" Grid.RowSpan = "1" Style = "{DynamicResource LabelStandard}" > NUCHAL THICKNESS </ Label >
            Label label1 = new Label();
            Grid.SetColumn(label1, 0);
            Grid.SetRow(label1, 0);
            Grid.SetRowSpan(label1, 1);
            Grid.SetColumnSpan(label1, 2);
            label1.Background = System.Windows.Media.Brushes.LightSeaGreen;
            grid.Children.Add(label1);
            //  < TextBox Grid.Row = "0" Grid.Column = "0" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Background = "Red" Text = "{Binding CleElement}"  Visibility = "Hidden" ></ TextBox >          
            //  < TextBox Grid.Row = "0" Grid.Column = "1" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Background = "Green" Text = "{Binding CleDimension}"  Visibility = "Hidden" ></ TextBox >                        
            //  < TextBox  Grid.Row = "0" Grid.Column = "2" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Style = "{DynamicResource TextBoxBiometric}" Text = "{Binding Dimension}" TextChanged = "TextBoxCn_TextChanged" ></ TextBox >                                                 
            //  < Label Grid.Row = "0" Grid.Column = "3" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Style = "{DynamicResource LabelMm}" > MM </ Label >*/




        }
    }
}
