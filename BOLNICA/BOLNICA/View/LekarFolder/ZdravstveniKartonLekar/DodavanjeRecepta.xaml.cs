using Bolnica.DTO;
using Bolnica.Kontroler;
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
        ZdravstvenKartoniKontroler zdravstveniKartoniKontroler = new ZdravstvenKartoniKontroler();
        PreglediKontroler preglediKontroler = new PreglediKontroler();
        LekoviKontroler lekoviKontroler = new LekoviKontroler();
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        PregledDTO izabranPregled = null;
        String sifraLeka = null;
        public static ObservableCollection<LekDTO> Lekovi { get; set; } = new ObservableCollection<LekDTO>();

        public DodavanjeRecepta(String idIzabranogPregleda)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.izabranPregled = preglediKontroler.DobaviPregled(idIzabranogPregleda);
            inicijalizacijaPolja();
            inicijalizacijaTabeleLekova();
            podesavanjePretrageLekova();
        }

        private void inicijalizacijaPolja()
        {
            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);
            LekarDTO l = lekariKontroler.PretraziPoId(izabranPregled.Termin.Lekar.KorisnickoIme);

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

            foreach (LekDTO l in zdravstveniKartoniKontroler.DobaviLekoveBezAlergena(izabranPregled.Termin.Pacijent.KorisnickoIme))
            {
                Lekovi.Add(l);
            }
        }

        private void IzdajRecept(object sender, RoutedEventArgs e)
        {
            if (!Validacija()) return;

            LekDTO prepisanLek = lekoviKontroler.PretraziPoID(sifraLeka);
            ReceptDTO novRecept = new ReceptDTO(Guid.NewGuid().ToString(), DateTime.Now, prepisanLek);

            zdravstveniKartoniKontroler.DodajRecept(izabranPregled.Termin.Pacijent.KorisnickoIme, novRecept);
            preglediKontroler.DodajRecept(izabranPregled.IdPregleda, novRecept);
            KartonLekar.Recepti.Add(novRecept);

            PovratakNaKarton();
        }


        private Boolean Validacija()
        {
            if (this.nazivLeka.Text.Equals("") || this.jacinaLeka.Text.Equals(""))
            {
                labelaValidacije.Content = "Niste odabrali lek!";
                labelaValidacije.Visibility = Visibility.Visible;
                return false;

            }

            if (zdravstveniKartoniKontroler.ProveraAlergicnosti(izabranPregled.Termin.Pacijent.KorisnickoIme, sifraLeka))
            {
                labelaValidacije.Content = "Pacijent je alergičan na " + this.nazivLeka.Text + "!";
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
            LekDTO izabranLek = (LekDTO)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                labelaValidacije.Visibility = Visibility.Hidden;
                nazivLeka.Text = izabranLek.NazivLeka;
                jacinaLeka.Text = izabranLek.Jacina;
                sifraLeka = izabranLek.IdLeka;
                poljeZaPreragu.Text = String.Empty;
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
                return ((item as LekDTO).NazivLeka.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void PovratakNaKarton()
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 3));
        }

    }
}
