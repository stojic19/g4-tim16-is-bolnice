using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
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

namespace Bolnica.View.LekarFolder.NalogLekara
{
    public partial class IzmenaNaloga : UserControl
    {
        String idLekara = null;
        LekariKontroler lekariKontroler = new LekariKontroler();
        LekarDTO lekar = null;
        public IzmenaNaloga(String idLekara)
        {
            InitializeComponent();
            this.idLekara = idLekara;
            lekar = lekariKontroler.PretraziPoId(idLekara);
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            inicijalizacijaPolja();
        }

        private void inicijalizacijaPolja()
        {
            this.ime.Text = lekar.Ime;
            this.prezime.Text = lekar.Prezime;
            this.korIme.Text = lekar.KorisnickoIme;
            this.email.Text = "email@ftn.com";
            this.adresa.Text = "Zagrebačka 9";
            this.telefon.Text = "042151252";
        }

        private void promenaLozinke_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PromenaLozinke(idLekara));
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new NalogLekara(idLekara));
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new NalogLekara(idLekara));
        }

        private void korIme_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.korIme.Text = string.Empty;
        }

        private void ime_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ime.Text= string.Empty;
        }

        private void prezime_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.prezime.Text = string.Empty;
        }

        private void email_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.email.Text = string.Empty;
        }

        private void telefon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.telefon.Text = string.Empty;
        }

        private void adresa_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.adresa.Text = string.Empty;
        }

        private void korIme_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.korIme.Text.Equals(string.Empty)) return;
            this.korIme.Text = lekar.KorisnickoIme;
        }

        private void email_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.email.Text.Equals(string.Empty)) return;
            this.email.Text = "email@ftn.com";
        }

        private void ime_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.ime.Text.Equals(string.Empty)) return;
            this.ime.Text = lekar.Prezime;
        }

        private void prezime_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.prezime.Text.Equals(string.Empty)) return;
            this.prezime.Text = lekar.Prezime;
        }

        private void telefon_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.telefon.Text.Equals(string.Empty)) return;
            this.telefon.Text = lekar.Prezime;
        }

        private void adresa_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.adresa.Text.Equals(string.Empty)) return;

            this.adresa.Text = lekar.Prezime;
        }
    }
}
