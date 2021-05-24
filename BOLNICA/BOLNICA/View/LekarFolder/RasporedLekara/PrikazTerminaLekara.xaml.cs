using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Bolnica
{

    public partial class PrikazTerminaLekara : System.Windows.Controls.UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        public static ObservableCollection<Termin> Termini { get; set; }
        public String korisnik = null;

        public PrikazTerminaLekara(String korIme)
        {
            InitializeComponent();

            korisnik = korIme;
            this.DataContext = this;

            Termini = new ObservableCollection<Termin>();

            foreach (Termin t in terminKontroler.PretraziPoLekaru(korIme))
            {
                if (t.Datum.AddDays(7).Date.CompareTo(DateTime.Now) >= 0)
                {
                    Termini.Add(t);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) //zakazivanje
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeTerminaLekar(korisnik));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //izmena
        {
            Termin izabranZaMenjanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaMenjanje != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaTerminaLekar(izabranZaMenjanje.IdTermina, korisnik));

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //otkazivanje
        {

            Termin izabranZaBrisanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                preglediKontroler.UklanjanjePregleda(izabranZaBrisanje.IdTermina);
                terminKontroler.OtkaziTermin(izabranZaBrisanje.IdTermina);
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }

        private void PrikazKartonaPacijenta(object sender, RoutedEventArgs e)
        {
            Termin izabranTermin = (Termin)dataGridTermini.SelectedItem;

            if (izabranTermin != null)
            {
                Pregled noviPregled = preglediKontroler.PristupPregledu(terminKontroler.PretraziPoId(izabranTermin.IdTermina));

                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(noviPregled.IdPregleda, 0));
            }
        }
    }
}
