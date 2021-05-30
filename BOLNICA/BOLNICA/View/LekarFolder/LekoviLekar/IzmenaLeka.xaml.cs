using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bolnica.LekarFolder.LekoviLekar
{
    public partial class IzmenaLeka : System.Windows.Controls.UserControl
    {
        LekDTO izabranLek = null;
        List<SastojakDTO> izmenjeniSastojci = new List<SastojakDTO>();
        String KorisnickoIme = null;
        private LekoviKontroler lekoviKontroler = new LekoviKontroler();
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; } = new ObservableCollection<SastojakDTO>();

        public IzmenaLeka(String idIzabranogLeka, String korisnickoImeLekara)
        {
            InitializeComponent();
            izabranLek = lekoviKontroler.PretraziPoID(idIzabranogLeka);
            KorisnickoIme = korisnickoImeLekara;

            this.DataContext = this;
            inicijalizacijaPolja();

        }

        private void inicijalizacijaPolja()
        {
            this.nazivLeka.Text = izabranLek.NazivLeka;
            this.jacinaLeka.Text = izabranLek.Jacina;

            Sastojci.Clear();
            foreach (SastojakDTO s in lekoviKontroler.DobaviSastojkeLeka(izabranLek.IdLeka))
            {
                Sastojci.Add(s);
                izmenjeniSastojci.Add(s);
            }
        }

        private void BrisanjeSastojka(object sender, RoutedEventArgs e)
        {
            SastojakDTO izabranSastojak = (SastojakDTO)dataGridSastojci.SelectedItem;

            if (izabranSastojak != null)
            {
                foreach (SastojakDTO s in izmenjeniSastojci)
                {
                    if (s.Naziv.Equals(izabranSastojak.Naziv))
                    {
                        izmenjeniSastojci.Remove(s);
                        Sastojci.Remove(s);
                        break;
                    }
                }
            }
        }

        private void DodavanjeSastojka(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaNovogSastojka()) return;

            SastojakDTO noviSastojak = new SastojakDTO(nazivSastojka.Text, Double.Parse(kolicinaSastojka.Text));

            izmenjeniSastojci.Add(noviSastojak);
            Sastojci.Add(noviSastojak);
            nazivSastojka.Text = String.Empty;
            kolicinaSastojka.Text = String.Empty;

        }

        private Boolean ValidacijaNovogSastojka()
        {
            if (nazivSastojka.Text.Equals("") || kolicinaSastojka.Text.Equals(""))
            {
                validacijaPolja.Content = "Niste popunili sva polja!";
                validacijaPolja.Visibility = Visibility.Visible;
                return false;

            }

            if (!Double.TryParse(kolicinaSastojka.Text, out Double broj))
            {
                kolicinaSastojka.Text = String.Empty;
                validacijaPolja.Content = "Količina mora biti broj!";
                validacijaPolja.Visibility = Visibility.Visible;

                return false;
            }

            return true;
        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoIme));
        }

        private void CuvanjeIzmena(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaUnosa()) return;

            izabranLek.NazivLeka = nazivLeka.Text;
            izabranLek.Jacina = jacinaLeka.Text;

            lekoviKontroler.IzmenaLeka(izabranLek, izmenjeniSastojci);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoIme));


        }

        private Boolean ValidacijaUnosa()
        {
            if (nazivLeka.Text.Equals("") || jacinaLeka.Text.Equals(""))
            {
                validacijaPolja.Content = "Niste popunili sva polja!";
                validacijaPolja.Visibility = Visibility.Visible;
                return false;

            }

            return true;
        }

        private void PromenaTekstualnihPolja(object sender, TextChangedEventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
        }

        private void KlikNaPolje(object sender, MouseButtonEventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
        }
    }
}
