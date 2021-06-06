using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.LekarFolder.ZdravstveniKartonLekar;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
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

            this.izabranPregled = preglediKontroler.DobaviPregled(idIzabranogPregleda);
            Tabovi.SelectedIndex = indeksTaba;

            inicijalizacijaPolja();

            this.DataContext = this;

            inicijalizacijaTabela();

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

        private void PrikazInformacijaAnamneza(object sender, RoutedEventArgs e)
        {

            AnamnezaDTO izabranaAnamneza = (AnamnezaDTO)TabelaAnamneza.SelectedItem;

            if (izabranaAnamneza != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeAnamaneza(izabranaAnamneza, izabranPregled.IdPregleda));
            }
        }

        private void PrikazInformacijaUput(object sender, RoutedEventArgs e)
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
            else {}
        }

        private void DodavanjeUputa(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzdavanjeUputa(izabranPregled.IdPregleda));

        }

        private void IzvestajRecepata(object sender, RoutedEventArgs e)
        {

        }
    }
}
