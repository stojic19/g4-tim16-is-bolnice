using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder.LekoviLekar;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Bolnica.LekarFolder
{
    public partial class VerifikacijaLekova : UserControl
    {
        public static ObservableCollection<ZahtjevDTO> Zahtevi { get; set; } = new ObservableCollection<ZahtjevDTO>();
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; } = new ObservableCollection<SastojakDTO>();
        private LekoviKontroler lekoviKontroler = new LekoviKontroler();
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        private DispatcherTimer dispatcherTimer;

        public VerifikacijaLekova( )
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.DataContext = this;

            inicijalizacijaTabeleZahteva();

            this.dataGridZahtevi.ItemsSource = Zahtevi;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(dataGridZahtevi.ItemsSource);
            view2.Filter = FiltriranjeZahteva;
            PodesavanjeTajmera();
        }

        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            vecPostojiOdgovor.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }

        private void inicijalizacijaTabeleZahteva()
        {
            Zahtevi.Clear();

            foreach (ZahtjevDTO z in zahtjeviKontroler.SviZahtjevi())
            {
                Zahtevi.Add(z);
            }
        }

        private void dataGridZahtevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vecPostojiOdgovor.Visibility = Visibility.Hidden;
            ZahtjevDTO izabranZahtev = (ZahtjevDTO)dataGridZahtevi.SelectedItem;

            if (izabranZahtev != null)
            {
                PopunjavanjeSastojakaZamena(izabranZahtev.Lek.IdLeka);

            }
        }

        private void PopunjavanjeSastojakaZamena(String idIzabranogLeka)
        {
            Sastojci.Clear();

            foreach (SastojakDTO s in zahtjeviKontroler.DobaviSastojkeLeka(idIzabranogLeka))
            {
                Sastojci.Add(s);
            }

        }

        private void pretragaZahteva_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridZahtevi.ItemsSource).Refresh();
        }

        private bool FiltriranjeZahteva(object item)
        {
            if (String.IsNullOrEmpty(pretragaZahteva.Text))
                return true;
            else
                return ((item as ZahtjevDTO).DatumSlanja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(pretragaZahteva.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Odbijanje(object sender, RoutedEventArgs e)
        {

            ZahtjevDTO izabranZahtev = (ZahtjevDTO)dataGridZahtevi.SelectedItem;

            if (Validacija(izabranZahtev))
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new OdbijanjeLeka(izabranZahtev.IDZahtjeva));
            }

        }

        private void Odobravanje(object sender, RoutedEventArgs e)
        {
            ZahtjevDTO izabranZahtev = (ZahtjevDTO)dataGridZahtevi.SelectedItem;

            if (Validacija(izabranZahtev))
            {
                if (zahtjeviKontroler.OdobriZahtev(izabranZahtev.IDZahtjeva))
                {
                    lekoviKontroler.DodajLek(izabranZahtev.Lek);
                }

                inicijalizacijaTabeleZahteva();

            }
        }

        private bool Validacija(ZahtjevDTO izabranZahtev)
        {
            if (izabranZahtev != null && izabranZahtev.Odgovor == Model.Enumi.VrsteOdgovora.Čekanje) return true;

            vecPostojiOdgovor.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
            return false;
        }

        private void PrikazBazeLekova(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova());
        }

        private void pretragaZahteva_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            vecPostojiOdgovor.Visibility = Visibility.Hidden;
        }
    }
}
