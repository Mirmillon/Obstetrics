using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Echographie.Utilitaires
{
    public class UnitData:Grid
    {
       
        private Label label1 = null;
        private Label label2 = null;
        private TextBox tb1 = null;
        private TextBox tb2 = null;
        private TextBox tb3 = null;
        private CheckBox cb1 = null;
       
        public Label Label1
        {
            get {return label1;}
            set {label1 = value;}
        }

        public Label Label2
        {
            get { return label2; }
            set { label2 = value; }
        }

        public TextBox Tb1
        {
            get {return tb1;}
            set {tb1 = value;}
        }

        public TextBox Tb2
        {
            get { return tb2; }
            set { tb2 = value; }
        }

        public TextBox Tb3
        {
            get { return tb3; }
            set { tb3 = value; }
        }

        public CheckBox Cb1
        {
            get { return cb1; }
            set { cb1 = value; }
        }

        public UnitData()
        {
            //CAracteristique de la grille
                
            Background = System.Windows.Media.Brushes.Transparent;
            for (int k = 0; k < 4; ++k)
            {
                ColumnDefinition c = new ColumnDefinition();
                ColumnDefinitions.Add(c);
            }
            //TODO Mettre la derniere colonne à Auto
            ColumnDefinitions[3].Width = new System.Windows.GridLength(0, System.Windows.GridUnitType.Auto);
            //< Label Grid.Row = "0" Grid.Column = "0" Grid.ColumnSpan = "2" Grid.RowSpan = "1" Style = "{DynamicResource LabelStandard}" > NUCHAL THICKNESS </ Label >
            label1 = new Label();
            label1.Style = (Style)label1.FindResource("LabelStandard");
           
            Grid.SetColumn(label1, 0);
            Grid.SetRow(label1, 0);
            Grid.SetRowSpan(label1, 1);
            Grid.SetColumnSpan(label1, 2);
            Children.Add(label1);
            //  < TextBox Grid.Row = "0" Grid.Column = "0" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Background = "Red" Text = "{Binding CleElement}"  Visibility = "Hidden" ></ TextBox >          
            tb1 = new TextBox();
            Grid.SetColumn(tb1, 0);
            Grid.SetRow(tb1, 0);
            Grid.SetRowSpan(tb1, 1);
            Grid.SetColumnSpan(tb1, 2);
            tb1.Background = System.Windows.Media.Brushes.Red;
            tb1.Visibility = System.Windows.Visibility.Hidden;
            Children.Add(tb1);
            //  < TextBox Grid.Row = "0" Grid.Column = "1" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Background = "Green" Text = "{Binding CleDimension}"  Visibility = "Hidden" ></ TextBox >                        
            tb2 = new TextBox();
            Grid.SetColumn(tb2, 1);
            Grid.SetRow(tb2, 0);
            Grid.SetRowSpan(tb2, 1);
            Grid.SetColumnSpan(tb2, 1);
            tb2.Background = System.Windows.Media.Brushes.Green;
            tb2.Visibility = System.Windows.Visibility.Hidden;
            Children.Add(tb2);
            //  < TextBox  Grid.Row = "0" Grid.Column = "2" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Style = "{DynamicResource TextBoxBiometric}" Text = "{Binding Dimension}" TextChanged = "TextBoxCn_TextChanged" ></ TextBox >                                                 
            tb3 = new TextBox();
            Grid.SetColumn(tb3, 2);
            Grid.SetRow(tb3, 0);
            Grid.SetRowSpan(tb3, 1);
            Grid.SetColumnSpan(tb3, 1);
            tb3.Style = (Style)tb3.FindResource("TextBoxBiometric");
            tb3.Visibility = System.Windows.Visibility.Visible;
            Children.Add(tb3);
            //  < Label Grid.Row = "0" Grid.Column = "3" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Style = "{DynamicResource LabelMm}" > MM </ Label >*/
            label2 = new Label();
            Grid.SetColumn(label2, 3);
            Grid.SetRow(label2, 0);
            Grid.SetRowSpan(label2, 1);
            Grid.SetColumnSpan(label2, 1);
            label2.Content = "MM";
            label2.Style = (Style)label2.FindResource("LabelMm");
            Children.Add(label2);
             //< CheckBox Grid.Row = "0" Grid.Column = "2" Grid.ColumnSpan = "1" Grid.RowSpan = "1" Style = "{StaticResource CheckBoxAnatomie}" Click = "CheckBoxAnatomie_Click" IsChecked = "{Binding Evaluation}" ></ CheckBox >
            cb1 = new CheckBox();
            Grid.SetColumn(cb1, 2);
            Grid.SetRow(cb1, 0);
            Grid.SetRowSpan(cb1, 1);
            Grid.SetColumnSpan(cb1, 1);
            cb1.Style = (Style)cb1.FindResource("CheckBoxAnatomie");
            cb1.Click += CheckBoxAnatomie_Click;
            cb1.Content = "Not Checked";
            cb1.IsChecked = false;
            Children.Add(cb1);
        }

        private void CheckBoxAnatomie_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb is CheckBox)
            {
                if (cb.IsChecked == true)
                {
                    cb.Content = "Checked";
                }
                else if (cb.IsChecked == false)
                {
                    cb.Content = "Not Checked";
                }
                else
                {
                    cb.Content = "To Check Again";
                }
            }
        }
    }
}
