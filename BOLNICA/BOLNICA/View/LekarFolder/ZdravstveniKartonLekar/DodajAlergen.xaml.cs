using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View.LekarFolder.ZdravstveniKartonLekar
{
    public partial class DodajAlergen : UserControl
    {
        public static ObservableCollection<LekDTO> Lekovi { get; set; } = new ObservableCollection<LekDTO>();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        ZdravstvenKartoniKontroler zdravstveniKartoniKontroler = new ZdravstvenKartoniKontroler();

        String idPregleda = null;
        public DodajAlergen(String idPregleda)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.idPregleda = idPregleda;
            inicijalizacijaTabeleLekova();
            podesavanjePretrageLekova();
        }

        private void inicijalizacijaTabeleLekova()
        {
            Lekovi.Clear();
            PregledDTO pregled = preglediKontroler.DobaviPregled(idPregleda);

            foreach (LekDTO l in zdravstveniKartoniKontroler.DobaviLekoveBezAlergena(pregled.Termin.Pacijent.KorisnickoIme))
            {
                Lekovi.Add(l);
            }
        }

        private void podesavanjePretrageLekova()
        {
            this.dataGridLekovi.ItemsSource = Lekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource);
            view.Filter = FiltriranjeLekova;
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(idPregleda, 2));
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(idPregleda, 2));
        }


        private void vremeReakcije_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void vremeReakcije_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void poljeZaPreragu_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource).Refresh();
        }

        private bool FiltriranjeLekova(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPreragu.Text))
                return true;
            else
                return ((item as LekDTO).NazivLeka.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void dataGridLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LekDTO izabranLek = (LekDTO)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                nazivLeka.Text = izabranLek.NazivLeka;
                jacinaLeka.Text = izabranLek.Jacina;
                poljeZaPreragu.Text = String.Empty;
            }
        }
    }
}
