using Bolnica.DTO;
using Bolnica.Kontroler;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica.LekarFolder.ZdravstveniKartonLekar
{
    public partial class InformacijeStacionarno : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();

        PregledDTO izabranPregled = null;
        UputDTO izabranUput = null;
        public InformacijeStacionarno(UputDTO informacijeUput, string idIzabranogPregleda)
        {
            InitializeComponent();
            InitializeComponent();
            izabranUput = informacijeUput;
            izabranPregled = preglediKontroler.DobaviPregled(idIzabranogPregleda);

            inicijalizacijaPolja();

        }

        private void inicijalizacijaPolja()
        {

            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);

            imePacijenta.Text = p.Ime;
            prezimePacijenta.Text = p.Prezime;
            jmbgPacijenta.Text = p.Jmbg;
            datumIzdavanjaStacionarnog.Text = izabranUput.DatumIzdavanja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            nalaz.Text = izabranUput.NalazMisljenje;
            pocetakStacionarnog.Text = izabranUput.PocetakStacionarnog.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture);
            krajStacionarnog.Text = izabranUput.KrajStacionarnog.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            soba.Text = izabranUput.Prostor.NazivProstora;
            krajStacionarnogPromena.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, izabranUput.KrajStacionarnog.Date));
        }

        private void ProduzavanjeLecenja(object sender, RoutedEventArgs e)
        {
            krajLecenja.Visibility = Visibility.Hidden;
            Produzavanje.Visibility = Visibility.Hidden;
            Potvrda.Visibility = Visibility.Visible;
            promenaKrajaLecenja.Visibility = Visibility.Visible;
            nalaz.IsReadOnly = false;
            nalaz.Text = String.Empty;
        }

        private void krajStacionarnogPromena_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(prostoriKontroler.DaLiSeSobaRenovira(izabranUput.Prostor.IdProstora, (DateTime)krajStacionarnogPromena.SelectedDate))
            {
                Upozorenje.Content = "Soba će se renovirati u odabranom periodu!";
                Upozorenje.Visibility = Visibility.Visible;

            }
        }

        private void PovrdiProduzavanje(object sender, RoutedEventArgs e)
        {
            if (!ProveraPopunjenostiPolja()) return;

            izabranUput.KrajStacionarnog = (DateTime)krajStacionarnogPromena.SelectedDate;
            izabranUput.NalazMisljenje = nalaz.Text;

            zdravstvenKartoniKontroler.IzmeniUput(izabranPregled.Termin.IdPacijenta, izabranUput);
            preglediKontroler.DodajUput(izabranPregled.IdPregleda, izabranUput);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
        }

        private Boolean ProveraPopunjenostiPolja()
        {
            if (this.nalaz.Text.Equals("") ||  !krajStacionarnogPromena.SelectedDate.HasValue)
            {
                Upozorenje.Content = "Niste popunili sva polja!";
                Upozorenje.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private void krajStacionarnogPromena_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Upozorenje.Visibility = Visibility.Hidden;
        }
    }
}
