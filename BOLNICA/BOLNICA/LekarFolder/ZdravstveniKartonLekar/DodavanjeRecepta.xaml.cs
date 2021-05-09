using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Properties;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    public partial class DodavanjeRecepta : UserControl
    {
        Pregled izabranPregled = null;
        String sifraLeka = null;
        public static ObservableCollection<Lek> Lekovi { get; set; } = new ObservableCollection<Lek>();

        public DodavanjeRecepta(String idIzabranogPregleda)
        {
            InitializeComponent();
            this.izabranPregled = RukovanjePregledima.PretraziPoId(idIzabranogPregleda);
            inicijalizacijaPolja();
            inicijalizacijaTabeleLekova();
            podesavanjePretrageLekova();


        }

        private void inicijalizacijaPolja()
        {
            Pacijent p = izabranPregled.Termin.Pacijent;
            Lekar l = izabranPregled.Termin.Lekar;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            DateTime datum = DateTime.Now;
            DanasnjiDatum.Text = (datum.ToString("dd/MM/yyyy"));

        }

        private void inicijalizacijaTabeleLekova()
        {
            Lekovi.Clear();

            foreach(Lek l in RukovanjeZdravstvenimKartonima.LekoviBezAlergena(izabranPregled.Termin.Pacijent.KorisnickoIme))
            {
                Lekovi.Add(l);
            }
        }


        private void IzdajRecept(object sender, RoutedEventArgs e)
        {


            if (!Validacija()) return;

            Lek prepisanLek = RukovanjeOdobrenimLekovima.PretraziPoID(sifraLeka);
            Recept novRecept = new Recept(Guid.NewGuid().ToString(), izabranPregled.Termin.Lekar.KorisnickoIme, izabranPregled.Termin.Pacijent.KorisnickoIme, DateTime.Now, prepisanLek);

            RukovanjeZdravstvenimKartonima.DodajRecept(novRecept);

            RukovanjePregledima.DodavanjeRecepta(izabranPregled, novRecept);

            PovratakNaKarton();
        }

        
        private Boolean Validacija()
        {
            if (this.nazivLeka.Text.Equals("") || this.jacinaLeka.Text.Equals(""))
            {
                labelaValidacije.Visibility = Visibility.Visible;
                return false;

            }

            return true;

        }

        private void IzvestajNovogRecepta(object sender, RoutedEventArgs e) { }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            PovratakNaKarton();

        }
        
        private void dataGridLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lek izabranLek = (Lek)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                labelaValidacije.Visibility = Visibility.Hidden;
                nazivLeka.Text = izabranLek.NazivLeka;
                jacinaLeka.Text = izabranLek.Jacina;
                sifraLeka = izabranLek.IDLeka;
            }

        }

        private void podesavanjePretrageLekova()
        {
            this.dataGridLekovi.ItemsSource = Lekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource);
            view.Filter = FiltriranjeLekova;
        }

        private void PromenaTekstaPretrage(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource).Refresh();
        }

        private bool FiltriranjeLekova(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPreragu.Text))
                return true;
            else
                return ((item as Lek).NazivLeka.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void PovratakNaKarton()
        {
            RukovanjePregledima.SerijalizacijaPregleda();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 3));

        }

    }
}
