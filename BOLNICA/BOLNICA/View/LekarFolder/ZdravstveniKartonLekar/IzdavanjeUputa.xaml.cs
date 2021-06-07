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

        PregledDTO izabranPregled = null;
        String idLekaraSpecijaliste = null;
        UputDTO noviUput = null;

        public static ObservableCollection<ProstorDTO> slobodneSobe { get; set; } = new ObservableCollection<ProstorDTO>();

        public IzdavanjeUputa(string idPregleda)
        {
            InitializeComponent();
            izabranPregled = preglediKontroler.DobaviPregled(idPregleda);

            InicijalizacijaPoljaSpecijalisticki();
            InicijalizacijaPoljaStacionarno();

            this.TabelaLekara.ItemsSource = lekariKontroler.DobaviSpecijaliste();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;

            this.DataContext = this;
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
            Console.WriteLine(this.nalazMisljenje.Text);

            zdravstvenKartoniKontroler.DodajUput(izabranPregled.Termin.Pacijent.KorisnickoIme, noviUput);
            preglediKontroler.DodajUput(izabranPregled.IdPregleda, noviUput);
        }

        private Boolean ProveraPopunjenostiPolja()
        {
            if (this.nalazMisljenje.Text.Equals("") || this.imeLekaraSpecijaliste.Text.Equals("") || this.prezimeLekaraSpecijaliste.Text.Equals(""))
            {
                validacijaPolja.Visibility = Visibility.Visible;
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
                LekarGlavniProzor.postaviPrethodnu(this);
            }
        }

        private void CuvanjeStacionarnog(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaDatumaStacionarno() || !ProveraPopunjenostiPoljaStac()) return;

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
                LekarGlavniProzor.postaviPrethodnu(this);
            }
        }

        private Boolean ProveraPopunjenostiPoljaStac()
        {
            if (this.nalazStac.Text.Equals("") || !pocetakStacionarnog.SelectedDate.HasValue || !krajStacionarnog.SelectedDate.HasValue || soba.SelectedItem == null)
            {
                validacijaStac.Content = "Niste popunili sva polja!";
                validacijaStac.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private Boolean ValidacijaDatumaStacionarno()
        {

            DateTime pocetakLecenja = (DateTime)pocetakStacionarnog.SelectedDate;
            DateTime krajLecenja = (DateTime)krajStacionarnog.SelectedDate;

            if (pocetakLecenja.CompareTo(krajStacionarnog.SelectedDate) > 0)
            {
                validacijaStac.Content = "Datumi nisu validni!";
                validacijaStac.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private void Otkazivanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
            LekarGlavniProzor.postaviPrethodnu(this);
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
            LekarGlavniProzor.postaviPrethodnu(this);
        }

        private void pretragaLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
            CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource).Refresh();
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

        private void KlikNaPolja(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
            validacijaStac.Visibility = Visibility.Hidden;
        }

        private void PromenaTeksta(object sender, TextChangedEventArgs e)
        {
            validacijaPolja.Visibility = Visibility.Hidden;
            validacijaStac.Visibility = Visibility.Hidden;
        }

        private void soba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void promenaDatuma(object sender, SelectionChangedEventArgs e)
        {
            if (!pocetakStacionarnog.SelectedDate.HasValue || !krajStacionarnog.SelectedDate.HasValue) return;

            foreach (ProstorDTO p in prostoriKontroler.DobaviSveSlobodneSobe((DateTime)krajStacionarnog.SelectedDate))
            {
                slobodneSobe.Add(p);
            }
        }
    }
}
