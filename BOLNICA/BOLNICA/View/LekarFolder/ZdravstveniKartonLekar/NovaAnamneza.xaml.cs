using Bolnica.Kontroler;
using Bolnica.LekarFolder;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{

    public partial class NovaAnamneza : UserControl
    {
        ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();
        //Dodato dok ne dodas kontroler za to
        ZdravstveniKartoniServis zdravstveniKartoniServis = new ZdravstveniKartoniServis();

        Pregled izabranPregled = null;
        String idAnamneze = null;
        String sifraLeka = null;
        public static ObservableCollection<Terapija> Terapije { get; set; }
        public NovaAnamneza(String IDIzabranog)
        {
            InitializeComponent();
            this.izabranPregled = PreglediServis.PretraziPoId(IDIzabranog);
            idAnamneze = Guid.NewGuid().ToString();

            ZdravstveniKartoniServis.NovoPrivremeno();

            inicijalizacijaPolja();

            this.TabelaLekova.ItemsSource = zdravstveniKartoniServis.LekoviBezAlergena(izabranPregled.Termin.Pacijent.KorisnickoIme);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource);
            view.Filter = UserFilter;


            this.DataContext = this;

            Terapije = new ObservableCollection<Terapija>();

            foreach (Terapija t in ZdravstveniKartoniServis.Privremeno)
            {
                Terapije.Add(t);
            }


        }

        private void inicijalizacijaPolja()
        {
            pocTer.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            krajTer.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            Pacijent p = izabranPregled.Termin.Pacijent;
            Lekar l = izabranPregled.Termin.Lekar;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            DateTime datum = DateTime.Now;
            datumPregleda.Text = (datum.ToString("dd/MM/yyyy"));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // NaloziPacijenataServis.Sacuvaj();
        }

        private void CuvanjeAnamneze(object sender, RoutedEventArgs e)
        {
            String imeiprezime = TerminiServis.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);


            if (this.tekst.Text.Equals(""))
            {
                validacijaDijagnoze.Content = "Niste popunili sva polja!";
                validacijaDijagnoze.Visibility = Visibility.Visible;
                return;

            }

            Anamneza a = new Anamneza(idAnamneze, izabranPregled.Termin.Lekar.KorisnickoIme, imeiprezime, izabranPregled.Termin.Pacijent.KorisnickoIme, DateTime.Now, this.tekst.Text, ZdravstveniKartoniServis.Privremeno);
            // NaloziPacijenataServis.Sacuvaj();
            zdravstveniKartoniServis.DodajAnamnezu(a);
            PreglediServis.DodavanjeAnamneze(izabranPregled, a);
            ZdravstveniKartoniServis.NovoPrivremeno();

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 1));
        }

        private void IzvestajAnamneza(object sender, RoutedEventArgs e)
        {

        }

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

            Terapija izabranZaBrisanje = (Terapija)TabelaTerapija.SelectedItem;

            if (izabranZaBrisanje != null)
            {
                ZdravstveniKartoniServis.obrisiPrivremeno(izabranZaBrisanje); //TODO: ISPRAVI!!!!!
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

            Lek preporucenLek = LekoviServis.PretraziPoID(sifraLeka);
            String idTerapije = Guid.NewGuid().ToString();
            Terapija t = new Terapija(idTerapije, idAnamneze, (DateTime)pocTer.SelectedDate, (DateTime)krajTer.SelectedDate, this.dnevnaKol.Text, this.satnica.Text, this.opisKonzumacije.Text, preporucenLek);
            ZdravstveniKartoniServis.dodajPrivremeno(t);
            Terapije.Add(t);

            //magdalena
            DateTime pocetni = DateTime.Now;
            DateTime krajnji = (DateTime)krajTer.SelectedDate;
            int trajanje = (int)(krajnji - pocetni).TotalDays + 1;
            String sadrzaj = "Terapija: " + t.PreporucenLek.NazivLeka + t.PreporucenLek.Jacina +
               "\ndnevna količina: " + t.Kolicina + ",\nvremenski interval između doza: " + t.Satnica + "h.";

            String idObavestenja = obavestenjaKontroler.GenerisiIdObavestenja();
            Obavestenje o = new Obavestenje(idObavestenja, "Terapija", sadrzaj, pocetni, izabranPregled.Termin.Pacijent.KorisnickoIme);
            obavestenjaKontroler.DodajObavestenjePacijentu(o);

            DateTime datum;
            for (int i = 1; i <= trajanje; i++)
            {
                datum = pocetni.AddDays(i);
                String form = datum.ToString();

                String[] splits = form.Split(' ');
                String[] brojevi = splits[0].Split('/');

                //assigns year, month, day, hour, min, seconds
                DateTime konacni = new DateTime(Int32.Parse(brojevi[2]), Int32.Parse(brojevi[0]), Int32.Parse(brojevi[1]), 8, 0, 0);

                idObavestenja = obavestenjaKontroler.GenerisiIdObavestenja();
                o = new Obavestenje(idObavestenja, "Terapija", sadrzaj, konacni, izabranPregled.Termin.Pacijent.KorisnickoIme);
                obavestenjaKontroler.DodajObavestenjePacijentu(o);

                //

            }

            PraznjenjePolja();

        }

        private bool ValidacijaPolja()
        {
            if (this.imeLeka.Text.Equals("") ||  this.jacinaLeka.Text.Equals("") || satnica.Text.Equals("") || dnevnaKol.Text.Equals(""))
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

            if (!pocTer.SelectedDate.HasValue || !krajTer.SelectedDate.HasValue || DateTime.Now.CompareTo(pocTer.SelectedDate) > 0 || pocetak.CompareTo(krajTer.SelectedDate) > 0)
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
                return ((item as Lek).NazivLeka.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource).Refresh();
        }

        private void TabelaLekova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekova.SelectedItems.Count > 0)
            {
                Lek item = (Lek)TabelaLekova.SelectedItems[0];
                imeLeka.Text = item.NazivLeka;
                sifraLeka = item.IDLeka;
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
