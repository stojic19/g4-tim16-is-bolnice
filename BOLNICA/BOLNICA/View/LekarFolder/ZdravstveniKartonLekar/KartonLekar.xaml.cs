using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.LekarFolder.ZdravstveniKartonLekar;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    public partial class KartonLekar : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        PreglediKontroler preglediKontroler = new PreglediKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        PregledDTO izabranPregled = null;
        public static ObservableCollection<ReceptDTO> Recepti { get; set; }
        public static ObservableCollection<AnamnezaDTO> Anamneze { get; set; }
        public static ObservableCollection<UputDTO> Uputi { get; set; }

        public KartonLekar(String idIzabranogPregleda, int indeksTaba)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.izabranPregled = preglediKontroler.DobaviPregled(idIzabranogPregleda);
            Tabovi.SelectedIndex = indeksTaba;

            inicijalizacijaPolja();

            this.DataContext = this;

            inicijalizacijaTabela();
            InicijalizacijaPretraga();

        }

        private void inicijalizacijaTabela()
        {
            String idPacijenta = izabranPregled.Termin.Pacijent.KorisnickoIme;
            Recepti = new ObservableCollection<ReceptDTO>();
            foreach (ReceptDTO r in zdravstvenKartoniKontroler.DobaviReceptePacijenta(idPacijenta))
            {
                Recepti.Add(r);
            }

            Anamneze = new ObservableCollection<AnamnezaDTO>();
            foreach (AnamnezaDTO a in zdravstvenKartoniKontroler.DobaviAnamnezePacijenta(idPacijenta))
            {
                Anamneze.Add(a);
            }

            Uputi = new ObservableCollection<UputDTO>();
            foreach (UputDTO u in zdravstvenKartoniKontroler.DobaviUputePacijenta(idPacijenta))
            {
                Uputi.Add(u);
            }

        }

        private void inicijalizacijaPolja()
        {

            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranPregled.Termin.IdPacijenta);

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            telefon.Text = p.KontaktTelefon;
            adresa.Text = p.AdresaStanovanja;
            datum.Text = p.DatumRodjenja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            pol.Text = p.PolString;
            status.Text = p.VrstaNaloga.ToString();
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(izabranPregled.Termin.Lekar.KorisnickoIme));
        }


        private void DodavanjeRecepta(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new DodavanjeRecepta(izabranPregled.IdPregleda));
        }
        private void DodavanjeAnamneze(object sender, RoutedEventArgs e) 
        {
            if (preglediKontroler.ProveraPostojanjaAnamneze(izabranPregled.IdPregleda))
            {
                System.Windows.Forms.MessageBox.Show("Anamneza za ovaj pregledveć postoji!", "Anamneza postoji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new NovaAnamneza(izabranPregled.IdPregleda));
        }

        private void DodavanjeUputa(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzdavanjeUputa(izabranPregled.IdPregleda));
        }

        private void IzvestajRecepata(object sender, RoutedEventArgs e)
        {

        }

        private void PrikazInformacijaAnamneza(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AnamnezaDTO izabranaAnamneza = (AnamnezaDTO)TabelaAnamneza.SelectedItem;

            if (izabranaAnamneza != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeAnamaneza(izabranaAnamneza, izabranPregled.IdPregleda));
            }
        }

        private void IzvestajAnamneza(object sender, RoutedEventArgs e)
        {

        }

        private void InformacijeUput(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            UputDTO izabranUput = (UputDTO)dataGridUputi.SelectedItem;
            if (izabranUput == null) return;

            if (izabranUput.TipUputa.Equals("Specijalističko-ambulantni pregled"))
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeSpecijalisticki(izabranUput, izabranPregled.IdPregleda));
            }
            else if (izabranUput.TipUputa.Equals("Stacionarno lečenje"))
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeStacionarno(izabranUput, izabranPregled.IdPregleda));
            }
            else { }
        }

        private void InicijalizacijaPretraga()
        {
            this.dataGridRecepti.ItemsSource = Recepti;
            CollectionView viewRecepti = (CollectionView)CollectionViewSource.GetDefaultView(dataGridRecepti.ItemsSource);
            viewRecepti.Filter = FiltriranjeRecepata;


            this.dataGridUputi.ItemsSource = Uputi;
            CollectionView viewUputi = (CollectionView)CollectionViewSource.GetDefaultView(dataGridUputi.ItemsSource);
            viewUputi.Filter = FiltriranjeUputa;


            this.TabelaAnamneza.ItemsSource = Anamneze;
            CollectionView viewAnamneze = (CollectionView)CollectionViewSource.GetDefaultView(TabelaAnamneza.ItemsSource);
            viewAnamneze.Filter = FiltriranjeAnamneza;
        }

        private bool FiltriranjeRecepata(object item)
        {
            if (String.IsNullOrEmpty(pretragaRecepata.Text))
                return true;
            else
                return ((item as ReceptDTO).Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(pretragaRecepata.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private bool FiltriranjeUputa(object item)
        {
            if (String.IsNullOrEmpty(PretragaUputa.Text))
                return true;
            else
                return ((item as UputDTO).DatumIzdavanja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(PretragaUputa.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private bool FiltriranjeAnamneza(object item)
        {
            if (String.IsNullOrEmpty(PretragaAnamneza.Text))
                return true;
            else
                return ((item as AnamnezaDTO).Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).IndexOf(PretragaAnamneza.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void PretragaAnamneza_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaAnamneza.ItemsSource).Refresh();
        }

        private void pretragaRecepata_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridRecepti.ItemsSource).Refresh();
        }

        private void PretragaUputa_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridUputi.ItemsSource).Refresh();
        }
    }
}
