using Bolnica.Model;
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
        private Uput UputSaPodacima = null;
        private DateTime izabranDatum;
        private String izabranaVrstaTermina = null;
        String IDPregleda = null;
        public static ObservableCollection<Termin> slobodniTermini { get; set; } = new ObservableCollection<Termin>();


        public ZakazivanjeIzUputa(Uput uputSaPodacima, String idPregleda)
        {
            InitializeComponent();
            UputSaPodacima = uputSaPodacima;
            IDPregleda = idPregleda;
            inicijalizacijaPolja();
            refresujPocetnoVreme();
            this.DataContext = this;
        }

        private void inicijalizacijaPolja()
        {
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(UputSaPodacima.IDPacijenta);
            pacijent.Text = p.imePrezime();
            lekar.Text = RukovanjeTerminima.ImeiPrezime(UputSaPodacima.IDLekaraSpecijaliste);
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(IDPregleda, 4));

        }

        private void ZakaziTermin(object sender, RoutedEventArgs e)
        {

            if (!ValidacijaPodataka()) return;

            Termin t = (Termin)pocVreme.SelectedItem;

            t.Lekar = RukovanjeTerminima.pretraziLekare(UputSaPodacima.IDLekaraSpecijaliste);
            t.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(UputSaPodacima.IDPacijenta);

            if (izabranaVrstaTermina.Equals("Operacija"))
            {
                t.Trajanje = 120;
            }
            else
            {
                t.Trajanje = 30;
            }

            RukovanjeTerminima.ZakaziTermin(t, UputSaPodacima.IDLekaraKojiUpucuje);
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(IDPregleda, 4));

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

        private void refresujPocetnoVreme()
        {
            slobodniTermini.Clear();
            foreach (Termin t in RukovanjeTerminima.slobodniTermini)
            {
                if (t.Datum.CompareTo(izabranDatum) == 0 && t.Lekar.KorisnickoIme.Equals(UputSaPodacima.IDLekaraSpecijaliste) &&
                    t.getVrstaTerminaString().Equals(izabranaVrstaTermina))
                {
                    slobodniTermini.Add(t);

                }

            }
        }
    }
}
