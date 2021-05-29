using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Model;
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
        public static ObservableCollection<TerminDTO> Termini { get; set; }
        public String korisnik = null;

        public PrikazTerminaLekara(String korIme)
        {
            InitializeComponent();

            korisnik = korIme;
            this.DataContext = this;

            Termini = new ObservableCollection<TerminDTO>();

            foreach (TerminDTO t in terminKontroler.PretraziPoLekaru(korIme))
            {
                if (t.Datum.AddDays(7).Date.CompareTo(DateTime.Now) >= 0)
                {
                    Termini.Add(t);
                }
            }

        }

        private void ZakaziTermin(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeTerminaLekar(korisnik));

        }

        private void IzmeniTermin(object sender, RoutedEventArgs e)
        {
            Termin izabranZaMenjanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaMenjanje != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaTerminaLekar(izabranZaMenjanje.IdTermina, korisnik));

            }
        }

        private void OtkaziTermin(object sender, RoutedEventArgs e)
        {

            TerminDTO izabranZaBrisanje = (TerminDTO)dataGridTermini.SelectedItem;

            if (izabranZaBrisanje != null)
            {
                preglediKontroler.UklanjanjePregleda(izabranZaBrisanje.IdTermina);
                if (terminKontroler.OtkaziTerminLekar(izabranZaBrisanje.IdTermina))
                {
                    Termini.Remove(izabranZaBrisanje);
                }
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }

        private void PrikazKartonaPacijenta(object sender, RoutedEventArgs e)
        {
            TerminDTO izabranTermin = (TerminDTO)dataGridTermini.SelectedItem;

            if (izabranTermin != null)
            {
                Pregled noviPregled = preglediKontroler.PristupPregledu(izabranTermin.IdTermina);

                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(noviPregled.IdPregleda, 0));
            }
        }
    }
}
