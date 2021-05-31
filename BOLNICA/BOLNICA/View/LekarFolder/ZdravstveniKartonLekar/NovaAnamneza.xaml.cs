using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{

    public partial class NovaAnamneza : UserControl
    {
        ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        PreglediKontroler preglediKontroler = new PreglediKontroler();
        LekoviKontroler lekoviKontroler = new LekoviKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        List<TerapijaDTO> izabraneTerapije = new List<TerapijaDTO>();
        PregledDTO izabranPregled = null;
        String idAnamneze = null;
        String sifraLeka = null;
        public static ObservableCollection<TerapijaDTO> Terapije { get; set; } = new ObservableCollection<TerapijaDTO>();
        public NovaAnamneza(String IDIzabranog)
        {
            InitializeComponent();
            this.izabranPregled = preglediKontroler.DobaviPregled(IDIzabranog);
            idAnamneze = Guid.NewGuid().ToString();
            inicijalizacijaPolja();

            this.DataContext = this;
            inicijalizacijaTabela();
        }

        private void inicijalizacijaTabela()
        {
            this.TabelaLekova.ItemsSource = zdravstvenKartoniKontroler.DobaviLekoveBezAlergena(izabranPregled.Termin.Pacijent.KorisnickoIme);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource);
            view.Filter = UserFilter;

        }

        private void inicijalizacijaPolja()
        {
            pocTer.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            krajTer.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            LekarDTO l = lekariKontroler.PretraziPoId(izabranPregled.Termin.Lekar.KorisnickoIme);

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            DateTime datum = DateTime.Now;
            datumPregleda.Text = (datum.ToString("dd/MM/yyyy"));
        }

        private void CuvanjeAnamneze(object sender, RoutedEventArgs e)
        {
            String imeiprezime = lekariKontroler.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);

            if (this.tekst.Text.Equals(""))
            {
                validacijaDijagnoze.Content = "Niste popunili sva polja!";
                validacijaDijagnoze.Visibility = Visibility.Visible;
                return;

            }

            AnamnezaDTO a = new AnamnezaDTO(idAnamneze, imeiprezime, DateTime.Now, izabraneTerapije, tekst.Text, izabranPregled.Termin.Lekar.KorisnickoIme, izabranPregled.Termin.Pacijent.KorisnickoIme);

            zdravstvenKartoniKontroler.DodajAnamnezu(a);
            preglediKontroler.DodajAnamnezu(izabranPregled.IdPregleda, a);
            KartonLekar.Anamneze.Add(a);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 1));
        }

        private void IzvestajAnamneza(object sender, RoutedEventArgs e) { }

        private void Otkazivanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 1));
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 1));
        }

        private void BrisanjeTerapije(object sender, RoutedEventArgs e)
        {

            TerapijaDTO izabranZaBrisanje = (TerapijaDTO)TabelaTerapija.SelectedItem;

            if (izabranZaBrisanje != null)
            {
                izabraneTerapije.Remove(izabranZaBrisanje);
                Terapije.Remove(izabranZaBrisanje);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite terapiju koju želite da otkažete!");
            }
        }

        private void DodavanjeTerapije(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaPolja() || !ValidacijaDatuma())
            {
                return;
            }

            LekDTO izabranLek = lekoviKontroler.PretraziPoID(sifraLeka);
            String idTerapije = Guid.NewGuid().ToString();
            TerapijaDTO t = new TerapijaDTO(idTerapije, idAnamneze, (DateTime)pocTer.SelectedDate, (DateTime)krajTer.SelectedDate, this.dnevnaKol.Text, this.satnica.Text, 
                   this.opisKonzumacije.Text, izabranLek);
            izabraneTerapije.Add(t);
            Terapije.Add(t);

            //magdalena
            DateTime pocetni = DateTime.Now;
            DateTime krajnji = (DateTime)krajTer.SelectedDate;
            int trajanje = (int)(krajnji - pocetni).TotalDays + 1;
            String sadrzaj = "Terapija: " + t.Lek.NazivLeka + t.Lek.Jacina +
               "\ndnevna količina: " + t.Kolicina + ",\nvremenski interval između doza: " + t.Satnica + "h.";


            Obavestenje o = new Obavestenje("Terapija", sadrzaj, pocetni, izabranPregled.Termin.Pacijent.KorisnickoIme);
            obavestenjaKontroler.DodajObavestenjePacijentu(o);

            DateTime datum;
            for (int i = 1; i <= trajanje; i++)
            {
                datum = pocetni.AddDays(i);
                String form = datum.ToString();

                String[] splits = form.Split(' ');
                String[] brojevi = splits[0].Split('/');

                DateTime konacni = new DateTime(Int32.Parse(brojevi[2]), Int32.Parse(brojevi[0]), Int32.Parse(brojevi[1]), 8, 0, 0);


                o = new Obavestenje("Terapija", sadrzaj, konacni, izabranPregled.Termin.Pacijent.KorisnickoIme);
                obavestenjaKontroler.DodajObavestenjePacijentu(o);

                //

            }

            PraznjenjePolja();

        }

        private bool ValidacijaPolja()
        {
            if (this.imeLeka.Text.Equals("") || this.jacinaLeka.Text.Equals("") || satnica.Text.Equals("") || dnevnaKol.Text.Equals(""))
            {
                validacija.Content = "Niste popunili sva polja!";
                validacija.Visibility = Visibility.Visible;
                return false;

            }
            return true;
        }

        private bool ValidacijaDatuma()
        {
            DateTime pocetak = DateTime.Now;

            if (pocTer.SelectedDate.HasValue)
            {
                pocetak = (DateTime)pocTer.SelectedDate;

            }

            if (!pocTer.SelectedDate.HasValue || !krajTer.SelectedDate.HasValue || DateTime.Now.CompareTo(pocTer.SelectedDate) > 0 ||
                    pocetak.CompareTo(krajTer.SelectedDate) > 0)
            {
                validacija.Content = "Datumi nisu validni!";
                validacija.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private void PraznjenjePolja()
        {
            this.poljeZaPreragu.Text = string.Empty;
            this.jacinaLeka.Text = String.Empty;
            this.imeLeka.Text = String.Empty;
            this.dnevnaKol.Text = String.Empty;
            this.satnica.Text = String.Empty;
            this.pocTer.SelectedDate = null;
            this.krajTer.SelectedDate = null;
            this.opisKonzumacije.Text = String.Empty;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPreragu.Text))
                return true;
            else
                return ((item as LekDTO).NazivLeka.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource).Refresh();
        }

        private void TabelaLekova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekova.SelectedItems.Count > 0)
            {
                LekDTO item = (LekDTO)TabelaLekova.SelectedItems[0];
                imeLeka.Text = item.NazivLeka;
                sifraLeka = item.IdLeka;
                jacinaLeka.Text = item.Jacina;
            }
        }

        private void PromenaPolja(object sender, TextChangedEventArgs e)
        {
            validacijaDijagnoze.Visibility = Visibility.Hidden;
            validacija.Visibility = Visibility.Hidden;
        }

        private void KlikPolja(object sender, MouseButtonEventArgs e)
        {
            validacijaDijagnoze.Visibility = Visibility.Hidden;
            validacija.Visibility = Visibility.Hidden;
        }

        private void PromenaDatuma(object sender, SelectionChangedEventArgs e)
        {
            validacijaDijagnoze.Visibility = Visibility.Hidden;
            validacija.Visibility = Visibility.Hidden;
        }
    }
}
