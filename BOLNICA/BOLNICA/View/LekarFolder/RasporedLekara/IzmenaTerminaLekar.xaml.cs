﻿using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    public partial class IzmenaTerminaLekar : UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        SlobodniTerminiKontroler slobodniTerminiKontroler = new SlobodniTerminiKontroler();

        String izabran = null;
        String korisnik = null;
        DateTime izabranDatum;
        String izabranaVrstaTermina = null;

        public static ObservableCollection<TerminDTO> slobodniTermini { get; set; } = new ObservableCollection<TerminDTO>();

        public IzmenaTerminaLekar(String id, String lekar)
        {
            InitializeComponent();
            korisnik = lekar;
            izabran = id;
            TerminDTO t = terminKontroler.DobaviZakazanTerminDTO(izabran);

            imePacijenta.Text = t.Pacijent.Ime;
            prezimePacijenta.Text = t.Pacijent.Prezime;
            jmbgPacijenta.Text = t.Pacijent.Jmbg;
            vrTermina.Text = t.TipTermina;
            datum.SelectedDate = t.Datum;
            izabranDatum = t.Datum;
            izabranaVrstaTermina = t.TipTermina;

            this.DataContext = this;
            refresujPocetnoVreme();

        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(korisnik));
        }

        private void PotvrdaIzmene(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaDatuma() || !ValidacijaUnosaPolja()) return;

            TerminDTO stari = terminKontroler.DobaviZakazanTerminDTO(izabran);
            TerminDTO novi = (TerminDTO)pocVreme.SelectedItem;

            terminKontroler.IzmeniTerminLekar(stari, novi);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(korisnik));
        }


        private Boolean ValidacijaUnosaPolja()
        {
            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }

        private Boolean ValidacijaDatuma()
        {
            DateTime danas = DateTime.Now;

            if (danas.CompareTo(datum.SelectedDate) > 0)
            {

                System.Windows.Forms.MessageBox.Show("Izabran datum je prošao!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void vrTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vrTermina.SelectedIndex == 0)
            {

                izabranaVrstaTermina = "Pregled";
            }
            else if (vrTermina.SelectedIndex == 1)
            {
                izabranaVrstaTermina = "Operacija";
            }


            refresujPocetnoVreme();
        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? datum = this.datum.SelectedDate;



            if (datum.HasValue)
            {
                izabranDatum = datum.Value;
                refresujPocetnoVreme();

            }
        }

        private void refresujPocetnoVreme()
        {
            TerminDTO izabranT = terminKontroler.DobaviZakazanTerminDTO(izabran);

            slobodniTermini.Clear();

            if (izabranaVrstaTermina == null) return;

            TerminDTO terminZaPoredjenje = new TerminDTO(izabranDatum, null, izabranaVrstaTermina); //PROMENI PROSTORIJE!!!!!!!!!

            foreach (TerminDTO t in terminKontroler.DobaviSlobodneTermineLekara(terminZaPoredjenje, korisnik))
            {
                slobodniTermini.Add(t);
                Console.WriteLine(t.Vreme);
            }
        }

    }
}
