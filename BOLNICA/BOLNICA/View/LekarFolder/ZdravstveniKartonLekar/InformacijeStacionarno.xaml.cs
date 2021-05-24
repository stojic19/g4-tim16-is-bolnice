﻿using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
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

namespace Bolnica.LekarFolder.ZdravstveniKartonLekar
{
    public partial class InformacijeStacionarno : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        Pregled izabranPregled = null;
        Uput izabranUput = null;
        public InformacijeStacionarno(Uput informacijeUput, string idIzabranogPregleda)
        {
            InitializeComponent();
            InitializeComponent();
            izabranUput = informacijeUput;
            izabranPregled = preglediKontroler.PretraziPoId(idIzabranogPregleda);

            inicijalizacijaPolja();
        }

        private void inicijalizacijaPolja()
        {

            Pacijent p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            Lekar specijalista = TerminiServis.pretraziLekare(izabranUput.IDLekaraSpecijaliste);

            imePacijenta.Text = p.Ime;
            prezimePacijenta.Text = p.Prezime;
            jmbgPacijenta.Text = p.Jmbg;
            datumIzdavanjaStacionarnog.Text = izabranUput.DatumIzdavanja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            nalaz.Text = izabranUput.NalazMisljenje;
            pocetakStacionarnog.Text = izabranUput.PocetakStacionarnog.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture);
            krajStacionarnog.Text = izabranUput.KrajStacionarnog.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        }

        private void ProduzavanjeLecenja(object sender, RoutedEventArgs e)
        {

        }
    }
}
