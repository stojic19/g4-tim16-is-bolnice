using Bolnica.Model;
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
   
    public partial class NovaAnamneza : Window
    {

        String izabran = null;
        public static ObservableCollection<Terapija> Terapije { get; set; }
        public NovaAnamneza(String idPacijenta)
        {
            InitializeComponent();

            RukovanjeZdravstvenimKartonima.NovoPrivremeno();
            izabran = idPacijenta;

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            ZdravstveniKarton zk = p.ZdravstveniKarton;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;

            imeLekara.Text = RukovanjeTerminima.pretraziLekare("JelenaHrnjak").Ime;
            prezimeLekara.Text = RukovanjeTerminima.pretraziLekare("JelenaHrnjak").Prezime;

            idAnamneze.Text = RukovanjeZdravstvenimKartonima.generisiIDAnamneze(izabran);

            DateTime datum = DateTime.Now;

            datumPregleda.Text = (datum.ToString("dd/MM/yyyy"));

            this.TabelaLekova.ItemsSource = RukovanjeZdravstvenimKartonima.inicijalniLekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource);
            view.Filter = UserFilter;


            this.DataContext = this;

            Terapije = new ObservableCollection<Terapija>();

           foreach(Terapija t in RukovanjeZdravstvenimKartonima.Privremeno)
            {
                Terapije.Add(t);
            }



        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) //Sacuvaj
        {
            String idAnamneze = this.idAnamneze.Text;

            String idLekara = "JelenaHrnjak";

            String imeiprezime = RukovanjeTerminima.ImeiPrezime(idLekara);

            String idPacijenta = izabran;

            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);

            String sifraLeka = this.sifraLeka.Text;

            Lek l = RukovanjeZdravstvenimKartonima.pretraziLekPoID(sifraLeka);


            if (this.tekst.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            Anamneza a = new Anamneza(idAnamneze,idLekara, imeiprezime, idPacijenta, datumPregleda.Text, this.tekst.Text, RukovanjeZdravstvenimKartonima.Privremeno);
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjeZdravstvenimKartonima.DodajAnamnezu(a);
            RukovanjeZdravstvenimKartonima.NovoPrivremeno();
            KartonLekar kl = new KartonLekar(izabran, 1);
            kl.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Izvestaj
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Otkazi
        {
            KartonLekar kl = new KartonLekar(izabran, 1);
            kl.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) // Nazad
        {
            KartonLekar kl = new KartonLekar(izabran, 1);
            kl.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Obrisi
        {

            Terapija izabranZaBrisanje = (Terapija)TabelaTerapija.SelectedItem;
            
            if (izabranZaBrisanje != null)
            {
                RukovanjeZdravstvenimKartonima.obrisiPrivremeno(izabranZaBrisanje);
                Terapije.Remove(izabranZaBrisanje);


            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite terapiju koju želite da otkažete!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //Dodaj
        {
            

            String idTerapije = RukovanjeZdravstvenimKartonima.generisiIDTerapije(izabran, idAnamneze.Text);
            DateTime? pocDatum = this.pocTer.SelectedDate;
            String pocFormatirano = null;
            
            if (pocDatum.HasValue)
            {
                pocFormatirano = pocDatum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            DateTime? krajDatum = this.krajTer.SelectedDate;
            String krajFormatirano = null;

            if (krajDatum.HasValue)
            {
                krajFormatirano = krajDatum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            Lek l = RukovanjeZdravstvenimKartonima.pretraziLekPoID(this.sifraLeka.Text);


            if (this.imeLeka.Text.Equals("") || this.sifraLeka.Text.Equals("") || this.jacinaLeka.Text.Equals("") || this.satnica.Text.Equals("") ||
                this.dnevnaKol.Text.Equals("") || !pocDatum.HasValue || !krajDatum.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Terapija t = new Terapija(idTerapije, idAnamneze.Text ,pocFormatirano, krajFormatirano, this.dnevnaKol.Text, this.satnica.Text, l);

            RukovanjeZdravstvenimKartonima.dodajPrivremeno(t);
            Terapije.Add(t);

            this.poljeZaPreragu.Text = string.Empty;
            this.sifraLeka.Text = String.Empty;
            this.jacinaLeka.Text = String.Empty;
            this.imeLeka.Text = String.Empty;
            this.dnevnaKol.Text = String.Empty;
            this.satnica.Text = String.Empty;
            this.pocTer.SelectedDate = null;
            this.krajTer.SelectedDate = null;

        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPreragu.Text))
                return true;
            else
                return ((item as Lek).NazivLeka.IndexOf(poljeZaPreragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource).Refresh();
        }

        private void TabelaLekova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekova.SelectedItems.Count > 0)
            {
                Lek item = (Lek)TabelaLekova.SelectedItems[0];
                imeLeka.Text = item.NazivLeka;
                sifraLeka.Text = item.IDLeka;
                jacinaLeka.Text = item.Jacina;
            }
        }
    }
}
