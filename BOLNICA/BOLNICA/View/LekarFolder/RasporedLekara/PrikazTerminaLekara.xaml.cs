using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace Bolnica
{

    public partial class PrikazTerminaLekara : System.Windows.Controls.UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        public static ObservableCollection<TerminDTO> Termini { get; set; }
        private DispatcherTimer dispatcherTimer;

        public PrikazTerminaLekara()
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.DataContext = this;

            Termini = new ObservableCollection<TerminDTO>();

            foreach (TerminDTO t in terminKontroler.PretraziPoLekaru(LekarGlavniProzor.DobaviKorisnickoIme()))
            {
                if (t.Datum.AddDays(5).Date.CompareTo(DateTime.Now) >= 0)
                {
                    Termini.Add(t);
                }
            }


            InicijalizacijaPretrage();
            PodesavanjeTajmera();

        }

        private void PodesavanjeTajmera()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            obavestenje.Visibility = Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }

        private void ZakaziTermin(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new ZakazivanjeTerminaLekar());

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
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaTerminaLekar(izabranZaMenjanje.IdTermina));

            }
        }

        private void OtkaziTermin(object sender, RoutedEventArgs e)
        {

            TerminDTO izabranZaBrisanje = (TerminDTO)dataGridTermini.SelectedItem;

            if (izabranZaBrisanje != null)
            {
                if (System.Windows.MessageBox.Show("Da li ste sigurni da želite da otkažete termin?", "Otkazivanje termina", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return;
                }

                preglediKontroler.UklanjanjePregleda(izabranZaBrisanje.IdTermina);
                if (terminKontroler.OtkaziTerminLekar(izabranZaBrisanje.IdTermina))
                {
                    Termini.Remove(izabranZaBrisanje);
                    podesiObavestenje("Termin uspešno otkazan!");
                }
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }

        public void podesiObavestenje(String poruka)
        {
            obavestenje.Content = poruka;
            obavestenje.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
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

        private void dataGridTermini_Sorting(object sender, System.Windows.Controls.DataGridSortingEventArgs e)
        {

        }
    }
}
