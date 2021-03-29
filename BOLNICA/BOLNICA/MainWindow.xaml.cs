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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RukovanjeTerminima.PrivremenaInicijalizacijaLekara();
            RukovanjeNalozimaPacijenata.Ucitaj();
            RukovanjeTerminima.DeserijalizacijaTermina();
            RukovanjeProstorom.DeserijalizacijaProstora();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrikazProstora prikaz = new PrikazProstora();
            prikaz.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrikazNalogaSekretar prikaz = new PrikazNalogaSekretar();
            prikaz.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PrikazTerminaLekara prikaz = new PrikazTerminaLekara();
            prikaz.Show();
            this.Close();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PrikazTerminaPacijent prikaz = new PrikazTerminaPacijent();
            prikaz.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeProstorom.SerijalizacijaProstora();
        }
    }
}
