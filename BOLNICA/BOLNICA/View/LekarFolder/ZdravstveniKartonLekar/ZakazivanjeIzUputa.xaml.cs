using Bolnica.DTO;
using Bolnica.Kontroler;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Bolnica.LekarFolder
{
    public partial class ZakazivanjeIzUputa : System.Windows.Controls.UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        TerminKontroler terminKontroler = new TerminKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();

        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        private String idLekarSpecijalista = null;
        private DateTime izabranDatum;
        private String izabranaVrstaTermina = null;
        PregledDTO izabranPregled = null;
        int izabranoTrajanje = 1;
        private DispatcherTimer dispatcherTimer;
        public static ObservableCollection<TerminDTO> slobodniTermini { get; set; } = new ObservableCollection<TerminDTO>();
        public ObservableCollection<int> BrojTermina { get; set; } = new ObservableCollection<int>();


        public ZakazivanjeIzUputa(String lekarSpecijalista, String idPregleda)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            idLekarSpecijalista = lekarSpecijalista;
            izabranPregled = preglediKontroler.DobaviPregled(idPregleda);
            inicijalizacijaPolja();
            refresujPocetnoVreme();
            this.DataContext = this;
            BrojTermina.Clear();
            PodesavanjeTajmera();
        }

        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            popunjenostPolja.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }

        private void inicijalizacijaPolja()
        {
            datum.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            pacijent.Text = p.Ime + " " + p.Prezime;
            lekar.Text = lekariKontroler.ImeiPrezime(idLekarSpecijalista);
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));

        }

        private void ZakaziTermin(object sender, RoutedEventArgs e)
        {

            if (!ValidacijaPodataka()) return;

            TerminDTO t = (TerminDTO)pocVreme.SelectedItem;

            t.Lekar.KorisnickoIme = idLekarSpecijalista;
            t.Pacijent.KorisnickoIme = izabranPregled.Termin.Pacijent.KorisnickoIme;
            t.TrajanjeDouble = izabranoTrajanje * 30;

            terminKontroler.ZakaziTerminLekar(t);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));
        }


        private Boolean ValidacijaPodataka()
        {

            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1 || brojTermina.SelectedIndex < 0)
            {
                popunjenostPolja.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
                return false;

            }
            return true;
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

        private void refresujPocetnoVreme()
        {
            slobodniTermini.Clear();
            if (izabranaVrstaTermina == null || brojTermina.SelectedIndex < 0) return;

            TerminDTO terminZaPoredjenje = new TerminDTO(izabranDatum, null, izabranaVrstaTermina);

            foreach (TerminDTO t in terminKontroler.DobaviSlobodneTermineLekara(terminZaPoredjenje, idLekarSpecijalista, izabranoTrajanje))
            {
                slobodniTermini.Add(t);
                Console.WriteLine(t.Vreme);
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

    }
}
