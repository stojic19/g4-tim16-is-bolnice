using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

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

            InicijalizacijaPretrage();

        }

        private void ZakaziTermin(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeTerminaLekar(korisnik));

        }

        private void InicijalizacijaPretrage()
        {
            this.dataGridTermini.ItemsSource = Termini;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(dataGridTermini.ItemsSource);
            view2.Filter = FiltriranjeTermina;
        }

        private bool FiltriranjeTermina(object item)
        {
            if (String.IsNullOrEmpty(pretragaDatuma.Text))
                return true;
            else
                return ((item as TerminDTO).Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(pretragaDatuma.Text, StringComparison.OrdinalIgnoreCase) >= 0);
           
        }

        private void IzmeniTermin(object sender, RoutedEventArgs e)
        {
            TerminDTO izabranZaMenjanje = (TerminDTO)dataGridTermini.SelectedItem;

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
                String idNovogPregleda = preglediKontroler.PristupPregledu(izabranTermin.IdTermina);

                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(idNovogPregleda, 0));
            }
        }

        private void pretragaDatuma_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridTermini.ItemsSource).Refresh();
        }
    }
}
