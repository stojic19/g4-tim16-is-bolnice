using Bolnica.LekarFolder;
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
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    public partial class IzmenaTerminaLekar : UserControl
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
            Termin t = TerminRepozitorijum.PretraziPoId(id);

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

            datum.SelectedDate = t.Datum;

            izabranDatum = t.Datum;
            izabranaVrstaTermina = t.getVrstaTerminaString();

            this.DataContext = this;


            refresujPocetnoVreme();


        }

        private void Povratak(object sender, RoutedEventArgs e) 
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(korisnik));
        }

        private void PotvrdaIzmene(object sender, RoutedEventArgs e) 
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


            Termin stari = TerminRepozitorijum.PretraziPoId(izabran);
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


            TerminRepozitorijum.IzmeniTermin(stari, novi, korisnik); 
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(korisnik));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NaloziPacijenataServis.Sacuvaj();
            PreglediServis.SerijalizacijaPregleda();
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
            Termin izabranT = TerminRepozitorijum.PretraziPoId(izabran);
            slobodniTermini.Clear();
            foreach (Termin t in TerminRepozitorijum.slobodniTermini)
            {
                if (t.Datum.CompareTo(izabranDatum)==0 && t.getVrstaTerminaString().Equals(izabranaVrstaTermina) && t.Lekar.KorisnickoIme.Equals(izabranT.Lekar.KorisnickoIme))
                {
                    slobodniTermini.Add(t);

                }

            }
        }

    }
}
