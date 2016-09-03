using System;
using System.Windows;
using System.Windows.Controls;

namespace Echographie.ControlUser
{
    /// <summary>
    /// Logique d'interaction pour UnitBiometrie.xaml
    /// </summary>
    public partial class UnitBiometrie : UserControl
    {
        public static DependencyProperty ElementProperty;
        public static DependencyProperty CleProperty;
        public static DependencyProperty DimensionProperty;
        public static DependencyProperty TailleProperty;
      
        public UnitBiometrie()
        {
            InitializeComponent();
        }

        static UnitBiometrie()
        {
            FrameworkPropertyMetadata mdElement = new FrameworkPropertyMetadata();
            FrameworkPropertyMetadata mdCle = new FrameworkPropertyMetadata();
            FrameworkPropertyMetadata mdDimension = new FrameworkPropertyMetadata();
            FrameworkPropertyMetadata mdTaile = new FrameworkPropertyMetadata();

            ElementProperty = DependencyProperty.Register("Element",
                                                           typeof(string),
                                                           typeof(Label),
                                                           mdElement);

            CleProperty = DependencyProperty.Register("Cle",
                                                       typeof(int),
                                                       typeof(TextBox),
                                                       mdCle);

            DimensionProperty = DependencyProperty.Register("Dimension",
                                                            typeof(int),
                                                            typeof(TextBox),
                                                            mdDimension);

            TailleProperty = DependencyProperty.Register("Taille",
                                                           typeof(double),
                                                           typeof(TextBox),
                                                           mdTaile);

        }

        public string Element
        {
            get { return (String)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public int Cle
        {
            get { return (int)GetValue(CleProperty); }
            set { SetValue(CleProperty, value); }
        }

        public int Dimension
        {
            get { return (int)GetValue(DimensionProperty); }
            set { SetValue(DimensionProperty, value); }
        }

        public double Taille
        {
            get { return (double)GetValue(TailleProperty); }
            set { SetValue(TailleProperty, value); }
        }
    }
}
