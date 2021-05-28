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
        public static ObservableCollection<Termin> slobodniTermini { get; set; } = new ObservableCollection<Termin>();
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
            Pacijent p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
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

            Termin t = (Termin)pocVreme.SelectedItem;

            t.Lekar = lekariKontroler.PretraziPoId(idLekarSpecijalista);
            t.Pacijent = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);

            if (izabranaVrstaTermina.Equals("Operacija"))
            {
                t.Trajanje = 120;
            }
            else
            {
                t.Trajanje = 30;
            }

            terminKontroler.ZakaziTermin(t, izabranPregled.Termin.Lekar.KorisnickoIme);
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 4));

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
            foreach (Termin t in terminKontroler.DobaviSveSlobodneTermine())
            {
                if (t.Datum.CompareTo(izabranDatum) == 0 && t.Lekar.KorisnickoIme.Equals(idLekarSpecijalista) &&
                    t.getVrstaTerminaString().Equals(izabranaVrstaTermina))
                {
                    if (izabranaProstorija == null)
                    {
                        slobodniTermini.Add(t);
                    }
                    else if (t.Prostor.IdProstora.Equals(izabranaProstorija))
                    {
                        slobodniTermini.Add(t);
                    }


                }

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
