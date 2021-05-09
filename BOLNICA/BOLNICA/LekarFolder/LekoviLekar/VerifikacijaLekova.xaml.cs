﻿using Bolnica.LekarFolder.LekoviLekar;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bolnica.LekarFolder
{
    public partial class VerifikacijaLekova : UserControl
    {
        public static ObservableCollection<Zahtjev> Zahtevi { get; set; } = new ObservableCollection<Zahtjev>();
        public static ObservableCollection<Sastojak> Sastojci { get; set; } = new ObservableCollection<Sastojak>();
        String KorisnickoImeLekara = null;

        public VerifikacijaLekova(string korisnickoImeLekara)
        {
            InitializeComponent();
            KorisnickoImeLekara = korisnickoImeLekara;
            this.DataContext = this;

            inicijalizacijaTabeleZahteva();

            this.dataGridZahtevi.ItemsSource = Zahtevi;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(dataGridZahtevi.ItemsSource);
            view2.Filter = FiltriranjeZahteva;

        }

        private void inicijalizacijaTabeleZahteva()
        {
            Zahtevi.Clear();

            foreach (Zahtjev z in RukovanjeZahtjevima.SviZahtevi)
            {
                Zahtevi.Add(z);
            }
        }

        private void dataGridZahtevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vecPostojiOdgovor.Visibility = Visibility.Hidden;
            Zahtjev izabranZahtev = (Zahtjev)dataGridZahtevi.SelectedItem;

            if (izabranZahtev != null)
            {
                PopunjavanjeSastojakaZamena(izabranZahtev.Lijek.IDLeka);

            }
        }


        private void PopunjavanjeSastojakaZamena(String idIzabranogLeka)
        {
            Sastojci.Clear();

            foreach (Sastojak s in RukovanjeZahtjevima.pretraziLekPoId(idIzabranogLeka).Sastojci)
            {
                Sastojci.Add(s);
            }

        }

        private void pretragaZahteva_TextChanged(object sender, TextChangedEventArgs e)
        {
            vecPostojiOdgovor.Visibility = Visibility.Hidden;
            CollectionViewSource.GetDefaultView(dataGridZahtevi.ItemsSource).Refresh();
        }

        private bool FiltriranjeZahteva(object item)
        {
            if (String.IsNullOrEmpty(pretragaZahteva.Text))
                return true;
            else
                return ((item as Zahtjev).DatumSlanja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(pretragaZahteva.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Odbijanje(object sender, RoutedEventArgs e)
        {

            Zahtjev izabranZahtev = (Zahtjev)dataGridZahtevi.SelectedItem;

            if (Validacija(izabranZahtev))
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new OdbijanjeLeka(izabranZahtev.IdZahtjeva, KorisnickoImeLekara));

            }

        }

        private void Odobravanje(object sender, RoutedEventArgs e)
        {
            Zahtjev izabranZahtev = (Zahtjev)dataGridZahtevi.SelectedItem;

            if (Validacija(izabranZahtev))
            {
                RukovanjeZahtjevima.OdobriZahtev(izabranZahtev.IdZahtjeva);
                inicijalizacijaTabeleZahteva();
                RukovanjeZahtjevima.SerijalizacijaZahtjeva();
                RukovanjeOdobrenimLekovima.SerijalizacijaLekova();

            }
        }

        private bool Validacija(Zahtjev izabranZahtev)
        {
            if (izabranZahtev != null && izabranZahtev.Odgovor == Model.Enumi.VrsteOdgovora.Čekanje) return true;

            vecPostojiOdgovor.Visibility = Visibility.Visible;
            return false;
        }

        private void PrikazBazeLekova(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoImeLekara));

        }

        private void pretragaZahteva_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            vecPostojiOdgovor.Visibility = Visibility.Hidden;
        }
    }
}
