﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Echographie.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour SearchPeople.xaml
    /// </summary>
    public partial class SearchPeople : Window
    {
        public SearchPeople()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
