using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bolnica.LekarFolder.LekoviLekar
{
    public partial class OdbijanjeLeka : UserControl
    {
        ZahtjevDTO izabranZahtev = null;
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; } = new ObservableCollection<SastojakDTO>();

        public OdbijanjeLeka(string idZahtjeva)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            izabranZahtev = zahtjeviKontroler.PretraziPoId(idZahtjeva);
            this.DataContext = this;
            inicijalizacijaPodataka();
            
        }

        private void inicijalizacijaPodataka()
        {
            nazivLeka.Text = izabranZahtev.Lek.NazivLeka;
            jacinaLeka.Text = izabranZahtev.Lek.Jacina;
            Sastojci.Clear();

            foreach(SastojakDTO s in zahtjeviKontroler.DobaviSastojkeLeka(izabranZahtev.Lek.IdLeka))
            {
                Sastojci.Add(s);
            }


        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova());

        }

        private void Potvrda(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaUnosa()) return;


            zahtjeviKontroler.OdbijZahtev(izabranZahtev.IDZahtjeva, razlogOdbijanja.Text);
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova());

        }

        private Boolean ValidacijaUnosa()
        {
            if (razlogOdbijanja.Text.Equals(""))
            {
                validacijaOdbijanja.Visibility = Visibility.Visible;
                return false;
            }

            return true;

        }

        private void razlogOdbijanja_TextChanged(object sender, TextChangedEventArgs e)
        {
            validacijaOdbijanja.Visibility = Visibility.Hidden;

            if (razlogOdbijanja.Text.Equals(String.Empty))
            {
                razlogOdbijanja.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                razlogOdbijanja.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        private void razlogOdbijanja_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            validacijaOdbijanja.Visibility = Visibility.Hidden;
        }
    }
}
