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
{
    /// <summary>
    /// Interaction logic for IzmenaTerminaPacijent.xaml
    /// </summary>
    public partial class IzmenaTerminaPacijent : Window
    {

        public String str = null;
        public IzmenaTerminaPacijent(Termin termin)
        {
            InitializeComponent();
            str = termin.IdTermina;
            lekar.Text = termin.Lekar.korisnickoIme;
            pacijent.Text = termin.Pacijent.korisnickoIme;
            datum.SelectedDate = DateTime.Parse(termin.Datum);
            vreme.Text = termin.PocetnoVreme;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            RukovanjeTerminima rukovanje = new RukovanjeTerminima();

            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            rukovanje.IzmeniPregled(str, lekar.Text, formatirano, vreme.Text);

            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
