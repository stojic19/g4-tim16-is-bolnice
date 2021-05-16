﻿using Model;
using System;
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
/// <summary>
/// Interaction logic for UklanjanjeProstora.xaml
/// </summary>
{
    public partial class UklanjanjeProstora : Window
    {
        String izabran = null;
        public UklanjanjeProstora(String idProstora)
        {
            InitializeComponent();
            izabran = idProstora;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            RukovanjeProstorom.UkloniProstor(izabran);
            RukovanjeProstorom.SerijalizacijaProstora();
            this.Close();
        }
    }
}

