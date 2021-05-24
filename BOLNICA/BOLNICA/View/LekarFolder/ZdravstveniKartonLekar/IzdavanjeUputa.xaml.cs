using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.LekarFolder
{
    
    public partial class IzdavanjeUputa : UserControl
    {
        //Dodato dok ne dodas kontroler za to
        ZdravstveniKartoniServis zdravstveniKartoniServis = new ZdravstveniKartoniServis();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        Pregled izabranPregled = null;
        String idLekaraSpecijaliste = null;
        Uput noviUput = null;
        public static ObservableCollection<Prostor> slobodneSobe { get; set; } = new ObservableCollection<Prostor>();
        public IzdavanjeUputa(string idPregleda)
        {
            InitializeComponent();
            izabranPregled = preglediKontroler.PretraziPoId(idPregleda);

            InicijalizacijaPoljaSpecijalisticki();
            InicijalizacijaPoljaStacionarno();
            InicijalizacijaSobaStacionarno();

            this.TabelaLekara.ItemsSource = TerminiServis.DobaviSpecijaliste();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;

            this.DataContext = this;
        }

        private void InicijalizacijaPoljaSpecijalisticki()
        {
            Pacijent p = izabranPregled.Termin.Pacijent;
            Lekar l = izabranPregled.Termin.Lekar;

            imePacijenta.Text = p.Ime;
            prezimePacijenta.Text = p.Prezime;
            jmbgPacijenta.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            datumIzdavanjaUputa.Text = (DateTime.Now.ToString("dd/MM/yyyy"));

        }

        private void InicijalizacijaPoljaStacionarno()
        {
            Pacijent p = izabranPregled.Termin.Pacijent;
            Lekar l = izabranPregled.Termin.Lekar;

            imePacijentaStac.Text = p.Ime;
            prezimePacijentaStac.Text = p.Prezime;
            jmbgPacijentaStac.Text = p.Jmbg;
            imeLekaraStac.Text = l.Ime;
            prezimeLekaraStac.Text = l.Prezime;
            datumIzdavanjaStacionarnog.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            pocetakStacionarnog.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            krajStacionarnog.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));

        }

        private void InicijalizacijaSobaStacionarno()
        {
            foreach(Prostor p in ProstoriServis.SviProstori())
            {
                if(p.VrstaProstora == VrsteProstora.soba && !p.JeRenoviranje)
                {
                    slobodneSobe.Add(p);
                }
            }
        }

        private void CuvanjeSpecijalistickog(object sender, RoutedEventArgs e)
        {

            DodavanjeNovogSpecijalistickog();
            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
            }

        }

        private void DodavanjeNovogSpecijalistickog()
        {

            if (this.nalazMisljenje.Text.Equals("") || this.imeLekaraSpecijaliste.Text.Equals("") || this.prezimeLekaraSpecijaliste.Text.Equals(""))
            {
                validacijaPolja.Visibility = Visibility.Visible;
                return;

            }

            String imeprezime = TerminiServis.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);
            noviUput = new Uput(Guid.NewGuid().ToString(), TipoviUputa.SPECIJALISTA, DateTime.Now, idLekaraSpecijaliste, nalazMisljenje.Text, imeprezime);

            zdravstveniKartoniServis.DodajUput(izabranPregled.Termin.Pacijent.KorisnickoIme, noviUput);
            preglediKontroler.DodajUput(izabranPregled.IdPregleda, noviUput);
        }


        private void CuvanjeIZakazivanjeSpecijalistickog(object sender, RoutedEventArgs e)
        {

            DodavanjeNovogSpecijalistickog();
            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeIzUputa(noviUput.IDLekaraSpecijaliste, izabranPregled.IdPregleda));
            }
        }

        private void CuvanjeStacionarnog(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaStacionarnog()) return;

            String imeprezime = TerminiServis.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);
            Console.WriteLine(imeprezime);
            noviUput = new Uput(Guid.NewGuid().ToString(), TipoviUputa.STACIONARNO, DateTime.Now, nalazStac.Text, imeprezime,
                    (DateTime)pocetakStacionarnog.SelectedDate, (DateTime)krajStacionarnog.SelectedDate, null); //ispravi

            zdravstveniKartoniServis.DodajUput(izabranPregled.Termin.Pacijent.KorisnickoIme, noviUput);
            preglediKontroler.DodajUput(izabranPregled.IdPregleda, noviUput);

            if (noviUput != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
            }

        }

        private Boolean ValidacijaStacionarnog()
        {

            if (this.nalazStac.Equals("") || !pocetakStacionarnog.SelectedDate.HasValue || !krajStacionarnog.SelectedDate.HasValue || soba.SelectedItem == null)
            {
                validacijaStac.Content = "Niste popunili sva polja!";
                validacijaStac.Visibility = Visibility.Visible;
                return false;
            }

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
        }

        private bool UserFilterLekar(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekara.Text))
                return true;
            else
                return ((item as Lekar).Prezime.IndexOf(pretragaLekara.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TabelaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (TabelaLekara.SelectedItems.Count > 0)
            {
                validacijaPolja.Visibility = Visibility.Hidden;
                Lekar item = (Lekar)TabelaLekara.SelectedItems[0];
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

        private void krevet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
