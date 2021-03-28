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
    public partial class ZakazivanjeTerminaPacijent : Window
    {

        public ZakazivanjeTerminaPacijent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String idTermina = RukovanjeTerminima.generisiIDTermina();

            Lekar l = RukovanjeTerminima.pretraziLekare(lekar.Text);
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(pacijent.Text);

            String idProstorije = null;

            VrsteTermina vrstaTermina = VrsteTermina.pregled;
            VrsteProstora vrstaProstorije = VrsteProstora.ordinacija;
            Prostor prostor = new Prostor(idProstorije, vrstaProstorije);
            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            String vremePocetka = vreme.Text;

            Double trajanje = 30;

            Termin t = new Termin(idTermina, vrstaTermina, vremePocetka, trajanje, formatirano, prostor, p, l);
            RukovanjeTerminima.ZakaziPregled(t);

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
