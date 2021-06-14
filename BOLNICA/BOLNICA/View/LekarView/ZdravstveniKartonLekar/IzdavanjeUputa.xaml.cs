using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.LekarFolder
{

    public partial class IzdavanjeUputa : UserControl
    {
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private DispatcherTimer dispatcherTimer;

        PregledDTO izabranPregled = null;
        String idLekaraSpecijaliste = null;
        UputDTO noviUput = null;

        public static ObservableCollection<ProstorDTO> slobodneSobe { get; set; } = new ObservableCollection<ProstorDTO>();

        public IzdavanjeUputa(string idPregleda)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            izabranPregled = preglediKontroler.DobaviPregled(idPregleda);

            InicijalizacijaPoljaSpecijalisticki();
            InicijalizacijaPoljaStacionarno();

            this.TabelaLekara.ItemsSource = lekariKontroler.DobaviSpecijaliste();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;
            PodesavanjeTajmera();
            this.DataContext = this;
        }

        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
            validacijaStac.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }

        private void InicijalizacijaPoljaSpecijalisticki()
        {
            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            LekarDTO l = lekariKontroler.PretraziPoId(izabranPregled.Termin.Lekar.KorisnickoIme);

            imePacijenta.Text = p.Ime;
            prezimePacijenta.Text = p.Prezime;
            jmbgPacijenta.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            datumIzdavanjaUputa.Text = (DateTime.Now.ToString("dd/MM/yyyy"));

        }

        private void InicijalizacijaPoljaStacionarno()
        {
            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            LekarDTO l = lekariKontroler.PretraziPoId(izabranPregled.Termin.Lekar.KorisnickoIme);

            imePacijentaStac.Text = p.Ime;
            prezimePacijentaStac.Text = p.Prezime;
            jmbgPacijentaStac.Text = p.Jmbg;
            imeLekaraStac.Text = l.Ime;
            prezimeLekaraStac.Text = l.Prezime;
            datumIzdavanjaStacionarnog.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            pocetakStacionarnog.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            krajStacionarnog.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));

        }

        private void CuvanjeSpecijalistickog(object sender, RoutedEventArgs e)
        {
            DodavanjeNovogSpecijalistickog();
            PrikazSvihUputa();

        }

        private void DodavanjeNovogSpecijalistickog()
        {
            if (!ProveraPopunjenostiPolja()) return;

            String imeprezime = lekariKontroler.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);
            noviUput = new UputDTO(Guid.NewGuid().ToString(), TipoviUputa.SPECIJALISTA, DateTime.Now, imeprezime, idLekaraSpecijaliste, this.nalazMisljenje.Text);

            zdravstvenKartoniKontroler.DodajUput(izabranPregled.Termin.Pacijent.KorisnickoIme, noviUput);
            preglediKontroler.DodajUput(izabranPregled.IdPregleda, noviUput);
        }

        private Boolean ProveraPopunjenostiPolja()
        {
            if (this.nalazMisljenje.Text.Equals("") || this.imeLekaraSpecijaliste.Text.Equals("") || this.prezimeLekaraSpecijaliste.Text.Equals(""))
            {
                validacijaPolja.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;

            }

            return true;
        }

        private void CuvanjeIZakazivanjeSpecijalistickog(object sender, RoutedEventArgs e)
        {

            DodavanjeNovogSpecijalistickog();
            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeIzUputa(noviUput.IdLekaraSpecijaliste, izabranPregled.IdPregleda));
            }
        }

        private void CuvanjeStacionarnog(object sender, RoutedEventArgs e)
        {
            if (!ProveraPopunjenostiPoljaStac()) return;
            if (!ValidacijaDatumaStacionarno()) return;

            String imeprezime = lekariKontroler.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);

            ProstorDTO izabranaSoba = (ProstorDTO)soba.SelectedItem;

            noviUput = new UputDTO(Guid.NewGuid().ToString(), TipoviUputa.STACIONARNO, DateTime.Now, nalazStac.Text, imeprezime,
                    (DateTime)pocetakStacionarnog.SelectedDate, (DateTime)krajStacionarnog.SelectedDate, izabranaSoba);

            zdravstvenKartoniKontroler.DodajUput(izabranPregled.Termin.Pacijent.KorisnickoIme, noviUput);
            preglediKontroler.DodajUput(izabranPregled.IdPregleda, noviUput);
            prostoriKontroler.SmanjiBrojSlobodnihKreveta(izabranaSoba.IdProstora);

            PrikazSvihUputa();
        }

        private void PrikazSvihUputa()
        {
            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
            }
        }

        private Boolean ProveraPopunjenostiPoljaStac()
        {
            if (this.nalazStac.Text.Equals("") || !pocetakStacionarnog.SelectedDate.HasValue || !krajStacionarnog.SelectedDate.HasValue || soba.SelectedItem == null)
            {
                validacijaStac.Content = Properties.Resources.Nepopunjeno;
                validacijaStac.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;
            }

            return true;
        }

        private Boolean ValidacijaDatumaStacionarno()
        {
            if (!pocetakStacionarnog.SelectedDate.HasValue) return false;
            if (!krajStacionarnog.SelectedDate.HasValue) return false;


            DateTime pocetakLecenja = (DateTime)pocetakStacionarnog.SelectedDate;
            DateTime krajLecenja = (DateTime)krajStacionarnog.SelectedDate;

            if (pocetakLecenja.CompareTo(krajStacionarnog.SelectedDate) > 0)
            {
                validacijaStac.Content = Properties.Resources.DatumiNevalid;
                validacijaStac.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;
            }

            return true;
        }

        private void Otkazivanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
        }

        private void pretragaLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
            CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource).Refresh();

            if (imeLekara.Text.Equals(string.Empty))
            {
                imeLekara.BorderBrush = System.Windows.Media.Brushes.Red;
                prezimeLekara.BorderBrush = System.Windows.Media.Brushes.Red;

            }
            else
            {
                imeLekara.BorderBrush = System.Windows.Media.Brushes.Black;
                prezimeLekara.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        private bool UserFilterLekar(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekara.Text))
                return true;
            else
                return ((item as LekarDTO).Prezime.IndexOf(pretragaLekara.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TabelaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (TabelaLekara.SelectedItems.Count > 0)
            {
                validacijaPolja.Visibility = Visibility.Hidden;
                LekarDTO item = (LekarDTO)TabelaLekara.SelectedItems[0];
                imeLekaraSpecijaliste.Text = item.Ime;
                prezimeLekaraSpecijaliste.Text = item.Prezime;
                pretragaLekara.Text = String.Empty;
                idLekaraSpecijaliste = item.KorisnickoIme;

            }
        }


        private void soba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (soba.SelectedIndex < 0)
            {
                soba.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                soba.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        private void promenaDatuma(object sender, SelectionChangedEventArgs e)
        {
            if (!pocetakStacionarnog.SelectedDate.HasValue) return;
            if (!krajStacionarnog.SelectedDate.HasValue) return;

            DateTime pocetakLecenja = (DateTime)pocetakStacionarnog.SelectedDate;

            if (!pocetakStacionarnog.SelectedDate.HasValue || !krajStacionarnog.SelectedDate.HasValue)
            {
                pocetakStacionarnog.BorderBrush = System.Windows.Media.Brushes.Red;
                krajStacionarnog.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            else if (pocetakLecenja.CompareTo(krajStacionarnog.SelectedDate) > 0)
            {
                pocetakStacionarnog.BorderBrush = System.Windows.Media.Brushes.Red;
                krajStacionarnog.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }


            pocetakStacionarnog.BorderBrush = System.Windows.Media.Brushes.Black;
            krajStacionarnog.BorderBrush = System.Windows.Media.Brushes.Black;

            foreach (ProstorDTO p in prostoriKontroler.DobaviSveSlobodneSobe((DateTime)krajStacionarnog.SelectedDate))
            {
                slobodneSobe.Add(p);
            }
        }

        private void nalazMisljenje_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nalazMisljenje.Text.Equals(string.Empty))
            {
                nalazMisljenje.BorderBrush = System.Windows.Media.Brushes.Red;

            }
            else
            {
                nalazMisljenje.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        private void nalazStac_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nalazStac.Text.Equals(string.Empty))
            {
                nalazStac.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                nalazStac.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }
    }
}
