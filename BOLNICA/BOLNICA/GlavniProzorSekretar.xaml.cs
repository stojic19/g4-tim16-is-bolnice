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

namespace Bolnica
{ 
    public partial class GlavniProzorSekretar : Window
    {
        public GlavniProzorSekretar()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrikazNalogaSekretar prikaz = new PrikazNalogaSekretar();
            prikaz.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ObavestenjaSekretar prikaz = new ObavestenjaSekretar();
            prikaz.Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //TO DO
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //TO DO
        }
    }
}
