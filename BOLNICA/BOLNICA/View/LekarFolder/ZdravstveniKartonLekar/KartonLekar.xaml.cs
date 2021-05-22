using Bolnica.LekarFolder;
using Bolnica.LekarFolder.ZdravstveniKartonLekar;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Model;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    public partial class KartonLekar : UserControl
    {

        Pregled izabranPregled = null;
        public static ObservableCollection<Recept> Recepti { get; set; }
        public static ObservableCollection<Anamneza> Anamneze { get; set; }
        public static ObservableCollection<Uput> Uputi { get; set; }

        public KartonLekar(String IDIzabranog, int indeksTaba)
        {
            InitializeComponent();

            this.izabranPregled = PreglediServis.PretraziPoId(IDIzabranog);
            Tabovi.SelectedIndex = indeksTaba;

            inicijalizacijaPolja();

            this.DataContext = this;

            inicijalizacijaTabela();

        }

        private void inicijalizacijaTabela()
        {
            Pacijent pacijent = NaloziPacijenataServis.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);

            Recepti = new ObservableCollection<Recept>();
            foreach (Recept r in pacijent.ZdravstveniKarton.Recepti)
            {
                Recepti.Add(r);
            }

            Anamneze = new ObservableCollection<Anamneza>();
            foreach (Anamneza a in pacijent.ZdravstveniKarton.Anamneze)
            {
                Anamneze.Add(a);
            }

            Uputi = new ObservableCollection<Uput>();
            foreach (Uput u in pacijent.ZdravstveniKarton.Uputi)
            {
                Uputi.Add(u);
            }

        }

        private void inicijalizacijaPolja()
        {

            Pacijent p = izabranPregled.Termin.Pacijent;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            telefon.Text = p.KontaktTelefon;
            adresa.Text = p.AdresaStanovanja;
            datum.Text = p.DatumRodjenja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            pol.Text = p.DobaviPolTekst();
            status.Text = p.DobaviVrstuNalogaTekst();
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataServis.Sacuvaj();
            PreglediServis.SerijalizacijaPregleda();
            TerminRepozitorijum.SerijalizacijaSlobodnihTermina();
            TerminRepozitorijum.SerijalizacijaTermina();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(izabranPregled.Termin.Lekar.KorisnickoIme));

        }


        private void DodavanjeRecepta(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new DodavanjeRecepta(izabranPregled.IdPregleda));

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NaloziPacijenataServis.Sacuvaj();
            PreglediServis.SerijalizacijaPregleda();
        }

        private void DodavanjeAnamneze(object sender, RoutedEventArgs e)  //MOZDA PROMENITI U IZMENU
        {
            if (izabranPregled.Anamneza != null)
            {
                System.Windows.Forms.MessageBox.Show("Anamneza za ovaj pregledveć postoji!", "Anamneza postoji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new NovaAnamneza(izabranPregled.IdPregleda));

        }

        private void PrikazInformacijaAnamneza(object sender, RoutedEventArgs e)
        {

            Anamneza izabranaAnamneza = (Anamneza)TabelaAnamneza.SelectedItem;

            if (izabranaAnamneza != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeAnamaneza(izabranaAnamneza, izabranPregled.IdPregleda));
            }
        }

        private void PrikazInformacijaUput(object sender, RoutedEventArgs e)
        {
            Uput izabranUput = (Uput)dataGridUputi.SelectedItem;
            if (izabranUput == null) return;

            if (izabranUput.TipUputa == TipoviUputa.SPECIJALISTA)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeSpecijalisticki(izabranUput, izabranPregled.IdPregleda));
            }
            else if (izabranUput.TipUputa == TipoviUputa.STACIONARNO)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new InformacijeStacionarno(izabranUput, izabranPregled.IdPregleda));
            }
            else
            {

            }
        }

        private void DodavanjeUputa(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzdavanjeUputa(izabranPregled.IdPregleda));

        }
    }
}
