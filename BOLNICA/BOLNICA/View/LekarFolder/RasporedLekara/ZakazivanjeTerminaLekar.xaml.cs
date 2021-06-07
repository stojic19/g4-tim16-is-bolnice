using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;

namespace Bolnica
{

    public partial class ZakazivanjeTerminaLekar : System.Windows.Controls.UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        TerminKontroler terminKontroler = new TerminKontroler();

        String korisnik = null;
        DateTime izabranDatum;
        String izabranLekar = null;
        String izabranPacijent = null;
        String izabranaVrstaTermina = null;

        public static ObservableCollection<TerminDTO> slobodniTermini { get; set; } = new ObservableCollection<TerminDTO>();
        public ZakazivanjeTerminaLekar(String lekar)
        {
            InitializeComponent();
            korisnik = lekar;
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            datum.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today));

            this.TabelaPacijenata.ItemsSource = naloziPacijenataKontroler.DobaviSveNaloge();
            CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaPacijenata.ItemsSource);
            view1.Filter = UserFilterPacijent;

            this.TabelaLekara.ItemsSource = lekariKontroler.DobaviSveLekare();
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;


            this.DataContext = this;

        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(korisnik));
        }

        private void Potvrda(object sender, RoutedEventArgs e)
        {

            if (!ProveraPopunjenostiPolja()) return;

            TerminDTO t = (TerminDTO)pocVreme.SelectedItem;

            t.Lekar = (LekarDTO)TabelaLekara.SelectedItems[0];
            t.Pacijent = (PacijentDTO)TabelaPacijenata.SelectedItems[0];

            t.TrajanjeDouble = OdrediTrajanje();

            if (terminKontroler.ZakaziTerminLekar(t) && t.Lekar.KorisnickoIme.Equals(korisnik))
            {
                PrikazTerminaLekara.Termini.Add(t);
            }

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(korisnik));

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
        }

        private Boolean ProveraPopunjenostiPolja()
        {
            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1 || idPacijenta.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }


        private bool UserFilterPacijent(object item)
        {
            if (String.IsNullOrEmpty(pretragaPacijenata.Text))
                return true;
            else
                return ((item as PacijentDTO).Prezime.IndexOf(pretragaPacijenata.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool UserFilterLekar(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekara.Text))
                return true;
            else
                return ((item as LekarDTO).Prezime.IndexOf(pretragaLekara.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void pretragaPacijenata_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaPacijenata.ItemsSource).Refresh();
        }

        private void pretragaLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource).Refresh();
        }

        private void TabelaPacijenata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaPacijenata.SelectedItems.Count > 0)
            {
                PacijentDTO item = (PacijentDTO)TabelaPacijenata.SelectedItems[0];
                idPacijenta.Text = item.Ime + " " + item.Prezime;
                izabranPacijent = item.KorisnickoIme;
            }

        }

        private void TabelaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekara.SelectedItems.Count > 0)
            {
                LekarDTO item = (LekarDTO)TabelaLekara.SelectedItems[0];
                idLekara.Text = item.Ime + " " + item.Prezime;
                izabranLekar = item.KorisnickoIme;

                refresujPocetnoVreme();
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

        private void refresujPocetnoVreme()
        {
            slobodniTermini.Clear();

            if (izabranaVrstaTermina == null) return;

            TerminDTO terminZaPoredjenje = new TerminDTO(izabranDatum, null, izabranaVrstaTermina); //PROMENI PROSTORIJE!!!!!!!!!

            foreach (TerminDTO t in terminKontroler.DobaviSlobodneTermineLekara(terminZaPoredjenje, izabranLekar))
            {
                slobodniTermini.Add(t);
                Console.WriteLine(t.Vreme);
            }

        }


    }
}
