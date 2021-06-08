using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    public partial class IzmenaTerminaLekar : UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        String izabranTermin = null;
        DateTime izabranDatum;
        String izabranaVrstaTermina = null;
        int izabranoTrajanje = 1;
        public static ObservableCollection<TerminDTO> slobodniTermini { get; set; } = new ObservableCollection<TerminDTO>();
        public ObservableCollection<String> VrsteTermina { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<int> BrojTermina { get; set; } = new ObservableCollection<int>();

        public IzmenaTerminaLekar(String id)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            izabranTermin = id;
            TerminDTO t = terminKontroler.DobaviZakazanTerminDTO(izabranTermin);
            datum.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));

            imePacijenta.Text = t.Pacijent.Ime;
            prezimePacijenta.Text = t.Pacijent.Prezime;
            jmbgPacijenta.Text = t.Pacijent.Jmbg;
            vrTermina.Text = t.TipTermina;
            datum.SelectedDate = t.Datum;
            izabranDatum = t.Datum;
            izabranaVrstaTermina = t.TipTermina;

            this.DataContext = this;
            VrsteTermina.Clear();
            VrsteTermina.Add("Pregled");
            if (lekariKontroler.DobaviSpecijalizaciju(LekarGlavniProzor.DobaviKorisnickoIme()) != SpecijalizacijeLekara.nema)
            {
                VrsteTermina.Add("Operacija");
            }
            refresujPocetnoVreme();

        }

        private void PotvrdaIzmene(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaDatuma() || !ValidacijaUnosaPolja()) return;

            TerminDTO stari = terminKontroler.DobaviZakazanTerminDTO(izabranTermin);
            TerminDTO novi = (TerminDTO)pocVreme.SelectedItem;
            novi.TrajanjeDouble = izabranoTrajanje * 30;
            terminKontroler.IzmeniTerminLekar(stari, novi);

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara());
        }


        private Boolean ValidacijaUnosaPolja()
        {
            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1 || brojTermina.SelectedIndex < 0)
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }

        private Boolean ValidacijaDatuma()
        {
            DateTime danas = DateTime.Now;

            if (danas.CompareTo(datum.SelectedDate) > 0)
            {

                System.Windows.Forms.MessageBox.Show("Izabran datum je prošao!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            }
            else if (vrTermina.SelectedIndex == 1)
            {
                maks = 11;
                izabranaVrstaTermina = "Operacija";
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

            }
        }

        private void brojTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brojTermina.SelectedIndex < 0) return;

            izabranoTrajanje = (int)brojTermina.SelectedItem;
            refresujPocetnoVreme();
        }

        private void refresujPocetnoVreme()
        {
            TerminDTO izabranT = terminKontroler.DobaviZakazanTerminDTO(izabranTermin);

            slobodniTermini.Clear();

            if (izabranaVrstaTermina == null || brojTermina.SelectedIndex < 0) return;

            TerminDTO terminZaPoredjenje = new TerminDTO(izabranDatum, null, izabranaVrstaTermina); //PROMENI PROSTORIJE!!!!!!!!!

            foreach (TerminDTO t in terminKontroler.DobaviSlobodneTermineLekara(terminZaPoredjenje, LekarGlavniProzor.DobaviKorisnickoIme(), izabranoTrajanje))
            {
                slobodniTermini.Add(t);
                Console.WriteLine(t.Vreme);
            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara());
        }
    }
}
