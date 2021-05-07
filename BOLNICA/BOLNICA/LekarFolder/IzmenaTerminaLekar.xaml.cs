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

namespace Bolnica
{
    public partial class IzmenaTerminaLekar : Window
    {
        String izabran = null;
        String korisnik = null;
        DateTime izabranDatum;
        String izabranaVrstaTermina = null;

        public static ObservableCollection<Termin> slobodniTermini { get; set; } = new ObservableCollection<Termin>();

        public IzmenaTerminaLekar(String id, String lekar)
        {
            InitializeComponent();
            korisnik = lekar;
            izabran = id;
            Termin t = RukovanjeTerminima.PretraziPoId(id);

            imePacijenta.Text = t.Pacijent.Ime;
            prezimePacijenta.Text = t.Pacijent.Prezime;
            jmbgPacijenta.Text = t.Pacijent.Jmbg;

            if (t.VrstaTermina == VrsteTermina.operacija)
            {
                vrTermina.Text = "Operacija";
            }
            else
            {
                vrTermina.Text = "Pregled";
            }

            datum.SelectedDate = t.Datum;// DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            izabranDatum = t.Datum;
            izabranaVrstaTermina = t.getVrstaTerminaString();

            this.DataContext = this;


            refresujPocetnoVreme();



        }

        private void Button_Click(object sender, RoutedEventArgs e) //odustani
        {
            PrikazTerminaLekara ptl = new PrikazTerminaLekara(korisnik);
            ptl.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //potvrdi
        {

            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DateTime danas = DateTime.Now;

            if (danas.CompareTo(datum.SelectedDate) > 0)
            {

                System.Windows.Forms.MessageBox.Show("Izabran datum je prošao!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            Termin stari = RukovanjeTerminima.PretraziPoId(izabran);
            Termin novi = (Termin)pocVreme.SelectedItem;

            Double trajanje = 0;

            if (izabranaVrstaTermina.Equals("Operacija"))
            {
                trajanje = 120;
            }
            else
            {
                trajanje = 30;
            }

            novi.Trajanje = trajanje;
            stari.Trajanje = 0;
            novi.Pacijent = stari.Pacijent;
            stari.Pacijent = null;


            RukovanjeTerminima.IzmeniTermin(stari, novi, korisnik); //IzmenaTermina
            PrikazTerminaLekara ptl = new PrikazTerminaLekara(korisnik);
            ptl.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
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
                izabranDatum = datum.Value;//.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                refresujPocetnoVreme();

            }
        }

        private void refresujPocetnoVreme()
        {
            Termin izabranT = RukovanjeTerminima.PretraziPoId(izabran);
            slobodniTermini.Clear();
            foreach (Termin t in RukovanjeTerminima.slobodniTermini)
            {
                if (t.Datum.CompareTo(izabranDatum)==0 && t.getVrstaTerminaString().Equals(izabranaVrstaTermina) && t.Lekar.KorisnickoIme.Equals(izabranT.Lekar.KorisnickoIme))
                {
                    //Console.WriteLine(izabranaVrstaTermina + t.getVrstaTerminaString());
                    slobodniTermini.Add(t);

                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //back
        {
            PrikazTerminaLekara ptl = new PrikazTerminaLekara(korisnik);
            ptl.Show();
            this.Close();

        }
    }
}
