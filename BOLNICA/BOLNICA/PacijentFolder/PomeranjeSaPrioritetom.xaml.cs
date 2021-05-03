﻿using Model;
using MoreLinq;
using PowerfulExtensions.Linq;
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
    /// Interaction logic for PomeranjeSaPrioritetom.xaml
    /// </summary>
    public partial class PomeranjeSaPrioritetom : Window
    {
        public static List<Termin> datumiZaIzmenu = new List<Termin>();
        public String idTermina = null;
        public PomeranjeSaPrioritetom(Termin termin)
        {
            InitializeComponent();
            PodesavanjePrikaza(termin);
        }

        private void PodesavanjePrikaza(Termin termin) 
        {
            lekar.Text = termin.Lekar.KorisnickoIme;
            datum.Text = termin.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            vreme.Text = termin.PocetnoVreme;
            idTermina = termin.IdTermina;
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (prioritet.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            datumiZaIzmenu.Clear();
            UkloniDupleDatume(RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumeUIntervalu(), PrikazRasporedaPacijent.TerminZaPomeranje.Lekar.KorisnickoIme));

            if (datumiZaIzmenu.Count == 0)
                NadjiDatumeSaPrioritetom(prioritet.SelectedIndex);
            else
            { 
                PrikazDatumaZaPomeranjeLekar pd = new PrikazDatumaZaPomeranjeLekar();
                pd.Show();
                this.Close();
            }
        }

        private void NadjiDatumeSaPrioritetom(int prioritet)
        {
            if (prioritet == 0)
                NadjiDatumeKodIzabranogLekara();
            else if (prioritet == 1)
                NadjiDatumeKodSvihLekara();
        }

        public static List<Termin> NadjiDatumeUIntervalu()
        {
            DateTime pocetniDatum = PrikazRasporedaPacijent.TerminZaPomeranje.Datum.AddDays(-2);
            DateTime krajnjiDatum = PrikazRasporedaPacijent.TerminZaPomeranje.Datum.AddDays(2);
            return RukovanjeTerminima.NadjiTermineUIntervalu(pocetniDatum,krajnjiDatum);
        }
        private void NadjiDatumeKodIzabranogLekara()
        {
            UkloniDupleDatume(RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumeUIntervalu(), PrikazRasporedaPacijent.TerminZaPomeranje.Lekar.KorisnickoIme));
            PrikazDatumaZaPomeranjeLekar pd = new PrikazDatumaZaPomeranjeLekar();
            pd.Show();
            this.Close();
        }

        private void NadjiDatumeKodSvihLekara()
        {
            UkloniDupleDatume(NadjiDatumeUIntervalu());
            PrikazDatumaZaPomeranjePrioritet pd = new PrikazDatumaZaPomeranjePrioritet();
            pd.Show();
            this.Close();
        }

        private void UkloniDupleDatume(List<Termin> dupliTermini)
        {
            foreach (Termin t in dupliTermini.DistinctBy(t => t.Datum))
                datumiZaIzmenu.Add(t);
        }

   

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
