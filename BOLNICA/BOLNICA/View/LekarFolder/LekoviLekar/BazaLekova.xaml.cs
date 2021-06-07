using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder.LekoviLekar;
using Bolnica.Model;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bolnica.LekarFolder
{
    public partial class BazaLekova : UserControl
    {
        String KorisnickoImeLekara = null;
        public static ObservableCollection<LekDTO> Lekovi { get; set; } = new ObservableCollection<LekDTO>();
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; } = new ObservableCollection<SastojakDTO>();
        public static ObservableCollection<LekDTO> Zamenski { get; set; } = new ObservableCollection<LekDTO>();
        private LekoviKontroler lekoviKontroler = new LekoviKontroler();

        public BazaLekova(String korisnickoImeLekara)
        {
            InitializeComponent();
            KorisnickoImeLekara = korisnickoImeLekara;

            this.DataContext = this;
            Sastojci.Clear();
            Zamenski.Clear();

            InicijalizacijaTabele();
            InicijalizacijaPretrage();

        }

        private void InicijalizacijaTabele()
        {
            Lekovi.Clear();
            foreach (LekDTO l in lekoviKontroler.DobaviSveLekove())
            {
                Lekovi.Add(l);
            }
        }

        private void InicijalizacijaPretrage()
        {
            this.dataGridLekovi.ItemsSource = lekoviKontroler.DobaviSveLekove();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource);
            view2.Filter = FiltriranjeLeka;
        }

        private void IzmenaLeka(object sender, RoutedEventArgs e)
        {
            LekDTO izabranLek = (LekDTO)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaLeka(izabranLek.IdLeka, KorisnickoImeLekara));
                LekarGlavniProzor.postaviPrethodnu(this);
            }
        }

        private void VerifikacijaLeka(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova(KorisnickoImeLekara));
            LekarGlavniProzor.postaviPrethodnu(this);
        }

        private void dataGridLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LekDTO izabranLek = (LekDTO)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                PopunjavanjeSastojaka(izabranLek.IdLeka);
                PopunjavanjeZamena(izabranLek.IdLeka);
            }
        }

        private void PopunjavanjeSastojaka(String idIzabranogLeka)
        {
            Sastojci.Clear();

            foreach (SastojakDTO s in lekoviKontroler.DobaviSastojkeLeka(idIzabranogLeka))
            {
                Sastojci.Add(s);
            }
        }

        private void PopunjavanjeZamena(String idIzabranogLeka)
        {
            Zamenski.Clear();

            foreach (LekDTO l in lekoviKontroler.DobaviZameneLeka(idIzabranogLeka))
            {
                Zamenski.Add(l);
            }
        }

        private bool FiltriranjeLeka(object item)
        {
            if (String.IsNullOrEmpty(pretragaLeka.Text))
                return true;
            else
                return ((item as LekDTO).NazivLeka.IndexOf(pretragaLeka.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void pretragaLeka_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource).Refresh();
        }

        private void IzmenaZamena(object sender, RoutedEventArgs e)
        {
            LekDTO izabranLek = (LekDTO)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaZamenskihLekova(izabranLek.IdLeka, KorisnickoImeLekara));
                LekarGlavniProzor.postaviPrethodnu(this);

            }
        }

    }
}
