﻿using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Bolnica
{

    public partial class ZakazivanjeTerminaLekar : System.Windows.Controls.UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        SlobodniTerminiKontroler slobodniTerminiKontroler = new SlobodniTerminiKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        ZakazaniTerminiKontroler terminKontroler = new ZakazaniTerminiKontroler();

        DateTime izabranDatum;
        String izabranLekar = null;
        String izabranPacijent = null;
        String izabranaVrstaTermina = null;
        int izabranoTrajanje = 1;
        private DispatcherTimer dispatcherTimer;
        public static ObservableCollection<TerminDTO> slobodniTermini { get; set; } = new ObservableCollection<TerminDTO>();
        public ObservableCollection<String> VrsteTermina { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<int> BrojTermina { get; set; } = new ObservableCollection<int>();

        public ZakazivanjeTerminaLekar()
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            datum.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));

            this.TabelaPacijenata.ItemsSource = naloziPacijenataKontroler.DobaviSveNaloge();
            CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaPacijenata.ItemsSource);
            view1.Filter = UserFilterPacijent;

            this.TabelaLekara.ItemsSource = lekariKontroler.DobaviSveLekare();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;

            PodesavanjeTajmera();
            this.DataContext = this;
            VrsteTermina.Clear();
            BrojTermina.Clear();
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara());
        }

        private void Potvrda(object sender, RoutedEventArgs e)
        {

            if (!ProveraPopunjenostiPolja()) return;

            TerminDTO t = (TerminDTO)pocVreme.SelectedItem;

            t.Lekar = (LekarDTO)TabelaLekara.SelectedItems[0];
            t.Pacijent = (PacijentDTO)TabelaPacijenata.SelectedItems[0];

            t.TrajanjeDouble = izabranoTrajanje*30;

            terminKontroler.ZakaziTerminLekar(t);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara());

        }

        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            popunjenost.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }

        private Boolean ProveraPopunjenostiPolja()
        {
            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1 || brojTermina.SelectedIndex == -1  || idPacijenta.Text.Equals("") )
            {
                popunjenost.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;

            }
            return true;
        }

        private void TabelaPacijenata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaPacijenata.SelectedItems.Count > 0)
            {
                PacijentDTO item = (PacijentDTO)TabelaPacijenata.SelectedItems[0];
                idPacijenta.Text = item.Ime + " " + item.Prezime;
                izabranPacijent = item.KorisnickoIme;
                idPacijenta.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                idPacijenta.BorderBrush = System.Windows.Media.Brushes.Red;
            }

        }

        private void TabelaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekara.SelectedItems.Count > 0)
            {
                LekarDTO item = (LekarDTO)TabelaLekara.SelectedItems[0];
                idLekara.Text = item.Ime + " " + item.Prezime;
                izabranLekar = item.KorisnickoIme;

                VrsteTermina.Clear();
                VrsteTermina.Add("Pregled");
                
                if (lekariKontroler.DobaviSpecijalizaciju(item.KorisnickoIme) != SpecijalizacijeLekara.nema)
                {
                    VrsteTermina.Add("Operacija");
                }
                idLekara.BorderBrush = System.Windows.Media.Brushes.Black;
                refresujPocetnoVreme();
            }
            else
            {
                idLekara.BorderBrush = System.Windows.Media.Brushes.Red;
            }

        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? datum = this.datum.SelectedDate;

            if (datum.HasValue)
            {
                izabranDatum = datum.Value;
                refresujPocetnoVreme();
                this.datum.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                this.datum.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        private void vrTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int maks = 0;
            if (vrTermina.SelectedIndex == 0)
            {
                izabranaVrstaTermina = "Pregled";
                maks = 4;
                vrTermina.BorderBrush = System.Windows.Media.Brushes.Black;

            }
            else if (vrTermina.SelectedIndex == 1)
            {
                maks = 11;
                izabranaVrstaTermina = "Operacija";
                vrTermina.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                vrTermina.BorderBrush = System.Windows.Media.Brushes.Red;
            }

            BrojTermina.Clear();
            for (int i = 1; i < maks; i++)
            {
                BrojTermina.Add(i);
            }

            refresujPocetnoVreme();
        }

        private void refresujPocetnoVreme()
        {
            slobodniTermini.Clear();

            if (izabranaVrstaTermina == null || brojTermina.SelectedIndex < 0) return;

            TerminDTO terminZaPoredjenje = new TerminDTO(izabranDatum, null, izabranaVrstaTermina);
           
            foreach (TerminDTO t in slobodniTerminiKontroler.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar, izabranoTrajanje))
            {
                slobodniTermini.Add(t);
            }

        }

        private void brojTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brojTermina.SelectedIndex < 0)
            {
                brojTermina.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }

            brojTermina.BorderBrush = System.Windows.Media.Brushes.Black;
            izabranoTrajanje = (int)brojTermina.SelectedItem;
            refresujPocetnoVreme();
        }

        private bool UserFilterPacijent(object item)
        {
            if (String.IsNullOrEmpty(pretragaPacijenata.Text))
                return true;
            else
                return ((item as PacijentDTO).Prezime.IndexOf(pretragaPacijenata.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool UserFilterLekar(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekara.Text))
                return true;
            else
                return ((item as LekarDTO).Prezime.IndexOf(pretragaLekara.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void pretragaPacijenata_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaPacijenata.ItemsSource).Refresh();
        }

        private void pretragaLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource).Refresh();
        }
    }
}
