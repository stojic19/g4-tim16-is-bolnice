using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Properties;
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
    public partial class DodavanjeRecepta : Window
    {
        Pregled izabranPregled = null;
        public DodavanjeRecepta(String IDIzabranog)
        {
            InitializeComponent();
            this.izabranPregled = RukovanjePregledima.PretraziPoId(IDIzabranog);
            inicijalizacijaPolja();

            this.TabelaLekova.ItemsSource = RukovanjeZdravstvenimKartonima.inicijalniLekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource);
            view.Filter = UserFilter;


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

        private void Povratak(object sender, RoutedEventArgs e) 
        {
            KartonLekar kartonLekar = new KartonLekar(izabranPregled.IdPregleda, 3);
            kartonLekar.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
        }

        private void IzdajRecept(object sender, RoutedEventArgs e)
        {

            String imeiprezime = RukovanjeTerminima.ImeiPrezime(izabranPregled.Termin.Lekar.KorisnickoIme);
            Lek prepisanLek = RukovanjeZdravstvenimKartonima.pretraziLekPoID(this.sifraLeka.Text);


            if (this.imeLeka.Text.Equals("") || this.sifraLeka.Text.Equals("") || this.jacinaLeka.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            Recept novRecept = new Recept(Guid.NewGuid().ToString(), izabranPregled.Termin.Lekar.KorisnickoIme, imeiprezime, izabranPregled.Termin.Pacijent.KorisnickoIme, DateTime.Now, prepisanLek);
            
            RukovanjeZdravstvenimKartonima.DodajRecept(novRecept);
            RukovanjePregledima.DodavanjeRecepta(izabranPregled, novRecept);
            RukovanjePregledima.SerijalizacijaPregleda();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            KartonLekar kl = new KartonLekar(izabranPregled.IdPregleda, 3);
            kl.Show();
            this.Close();
        }

        private void IzvestajNovogRecepta(object sender, RoutedEventArgs e) {}

        private void Odustajanje(object sender, RoutedEventArgs e) 
        {
            KartonLekar kl = new KartonLekar(izabranPregled.IdPregleda, 3);
            kl.Show();
            this.Close();

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
