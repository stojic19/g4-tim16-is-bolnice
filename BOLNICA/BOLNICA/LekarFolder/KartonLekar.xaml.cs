using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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

namespace Bolnica
{
    public partial class KartonLekar : Window
    {

        Pregled izabranPregled = null;
        public static ObservableCollection<Recept> Recepti { get; set; }
        public static ObservableCollection<Anamneza> Anamneze { get; set; }
        public static ObservableCollection<Uput> Uputi { get; set; }

        public KartonLekar(String IDIzabranog, int indeksTaba)
        {
            InitializeComponent();

            this.izabranPregled = RukovanjePregledima.PretraziPoId(IDIzabranog);
            Tabovi.SelectedIndex = indeksTaba;

            inicijalizacijaPolja();

            this.DataContext = this;

            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(izabranPregled.Termin.Pacijent.KorisnickoIme);

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
            foreach(Uput u in pacijent.ZdravstveniKarton.Uputi)
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
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
            PrikazTerminaLekara termini = new PrikazTerminaLekara(izabranPregled.Termin.Lekar.KorisnickoIme);

            termini.Show();
            this.Close();

        }


        private void DodavanjeRecepta(object sender, RoutedEventArgs e)
        {
            DodavanjeRecepta recept = new DodavanjeRecepta(izabranPregled.IdPregleda);

            recept.Show();

            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
        }

        private void DodavanjeAnamneze(object sender, RoutedEventArgs e)  //MOZDA PROMENITI U IZMENU
        {
            if (izabranPregled.Anamneza != null)
            {
                //DialogResult dialogResult = (DialogResult)System.Windows.MessageBox.Show("Već postoji anamneza za ovaj pregled. Zameniti je sa novom?", "Izmena anamneze", (MessageBoxButton)MessageBoxButtons.YesNo);
                //if (dialogResult != DialogResult.No)
                //{
                //    RukovanjePregledima.UklanjanjeAnamneze(izabranPregled);
                //    RukovanjeZdravstvenimKartonima.UklanjanjeAnamneze(izabranPregled.Termin.Pacijent.ZdravstveniKarton, izabranPregled.Anamneza);

                //    NovaAnamneza dodajAnamnezu = new NovaAnamneza(izabranPregled.IdPregleda);

                //    dodajAnamnezu.Show();
                //    this.Close();
                //}

                System.Windows.Forms.MessageBox.Show("Anamneza za ovaj pregledveć postoji!", "Anamneza postoji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            NovaAnamneza dodajAnamnezu = new NovaAnamneza(izabranPregled.IdPregleda);

            dodajAnamnezu.Show();
            this.Close();



        }

        private void PrikazInformacijaAnamneza(object sender, RoutedEventArgs e)
        {

            Anamneza izabranaAnamneza = (Anamneza)TabelaAnamneza.SelectedItem;

            if (izabranaAnamneza != null)
            {
                InformacijeAnamaneza informacije = new InformacijeAnamaneza(izabranaAnamneza, izabranPregled.IdPregleda);
                informacije.Show();
                this.Close();
            }
        }

        private void DodavanjeUputa(object sender, RoutedEventArgs e)
        {
            IzdavanjeUputa izdavanjeUputa = new IzdavanjeUputa(izabranPregled.IdPregleda);
            izdavanjeUputa.Show();
            this.Close();
        }
    }
}
