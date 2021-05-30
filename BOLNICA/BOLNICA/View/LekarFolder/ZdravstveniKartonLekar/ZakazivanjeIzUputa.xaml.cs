using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.LekarFolder
{
    public partial class ZakazivanjeIzUputa : System.Windows.Controls.UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        TerminKontroler terminKontroler = new TerminKontroler();
        SlobodniTerminiKontroler slobodniTerminiKontroler = new SlobodniTerminiKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();

        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        private String idLekarSpecijalista = null;
        private DateTime izabranDatum;
        private String izabranaVrstaTermina = null;
        Pregled izabranPregled = null;
        private String izabranaProstorija = null;
        public static ObservableCollection<TerminDTO> slobodniTermini { get; set; } = new ObservableCollection<TerminDTO>();
        public static ObservableCollection<Prostor> Prostorije { get; set; } = new ObservableCollection<Prostor>();

        public ZakazivanjeIzUputa(String lekarSpecijalista, String idPregleda)
        {
            InitializeComponent();
            idLekarSpecijalista = lekarSpecijalista;
            izabranPregled = preglediKontroler.PretraziPoId(idPregleda);
            inicijalizacijaPolja();
            refresujPocetnoVreme();
            this.DataContext = this;
        }

        private void inicijalizacijaPolja()
        {
            datum.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));
            Pacijent p = naloziPacijenataKontroler.PretraziPoIdNeDTO(izabranPregled.Termin.Pacijent.KorisnickoIme);
            pacijent.Text = p.imePrezime();
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
            t.TrajanjeDouble = OdrediTrajanje();

            if (terminKontroler.ZakaziTerminLekar(t) && izabranPregled.Termin.Lekar.KorisnickoIme.Equals(idLekarSpecijalista))
            {
                PrikazTerminaLekara.Termini.Add(t);
            }

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));

        }

        private Double OdrediTrajanje()
        {
            if (izabranaVrstaTermina.Equals("Operacija"))
            {
                return 120;
            }
            else
            {
                return 30;
            }

            return 0;

        }

        private Boolean ValidacijaPodataka()
        {

            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }

        private void vrTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vrTermina.SelectedIndex == 0)
            {
                izabranaVrstaTermina = "Pregled";
            }
            else if (vrTermina.SelectedIndex == 1)
            {
                izabranaVrstaTermina = "Operacija";
            }


            refresujProstorije();
            refresujPocetnoVreme();
        }

        private void refresujProstorije()
        {
            Prostorije.Clear();

            foreach (Prostor p in ProstoriServis.SviProstori())
            {
                if (izabranaVrstaTermina.Equals("Pregled") && p.VrstaProstora == VrsteProstora.ordinacija)
                {
                    Prostorije.Add(p);
                }
                else if (izabranaVrstaTermina.Equals("Operacija") && p.VrstaProstora == VrsteProstora.sala)
                {
                    Prostorije.Add(p);
                }
            }
        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? datum = this.datum.SelectedDate;

            if (datum.HasValue)
            {
                izabranDatum = datum.Value;
                refresujPocetnoVreme();
            }
        }

        private void refresujPocetnoVreme()
        {
            slobodniTermini.Clear();
            if (izabranaVrstaTermina == null) return;

            TerminDTO terminZaPoredjenje = new TerminDTO(izabranDatum, izabranaProstorija, izabranaVrstaTermina);

            foreach (TerminDTO t in terminKontroler.DobaviSlobodneTermineLekara(terminZaPoredjenje, idLekarSpecijalista))
            {
                slobodniTermini.Add(t);
                Console.WriteLine(t.Vreme);
            }
        }

        private void prostorije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prostor izabran = (Prostor)prostorije.SelectedItem;
            izabranaProstorija = null;
            if (izabran != null)
            {
                izabranaProstorija = izabran.IdProstora;
                Console.WriteLine(izabranaProstorija);
                refresujPocetnoVreme();

            }

        }
    }
}
