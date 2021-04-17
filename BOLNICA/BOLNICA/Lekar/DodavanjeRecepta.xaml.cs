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
    public partial class DodavanjeRecepta : Window
    {
        String izabran = null;
        public static ObservableCollection<Recept> Recepti { get; set; }
        public DodavanjeRecepta(String idPacijenta)
        {
            InitializeComponent();
            izabran = idPacijenta;

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            ZdravstveniKarton zk = p.ZdravstveniKarton;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;

            Lekar l = RukovanjeTerminima.pretraziLekare("JelenaHrnjak");
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;

            idRecepta.Text = RukovanjeZdravstvenimKartonima.generisiIDRecepta(izabran);

            
            this.TabelaLekova.ItemsSource = RukovanjeZdravstvenimKartonima.inicijalniLekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekova.ItemsSource);
            view.Filter = UserFilter;

            
            this.DataContext = this;

            Recepti = new ObservableCollection<Recept>();

            foreach (Recept r in zk.Recepti)
            {
                Recepti.Add(r);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        KartonLekar kartonLekar = new KartonLekar(izabran);
        kartonLekar.Show();
        this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Sacuvaj
        {

            String idRecepta = this.idRecepta.Text;

            String idLekara = "JelenaHrnjak";

            String imeiprezime = RukovanjeTerminima.ImeiPrezime(idLekara);

            String idPacijenta = izabran;

            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);

            String sifraLeka = this.sifraLeka.Text;

            Lek l=RukovanjeZdravstvenimKartonima.pretraziLekPoID(sifraLeka);
            

            if (this.imeLeka.Text.Equals("") || this.sifraLeka.Text.Equals("") || this.jacinaLeka.Text.Equals("") )
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            
            Recept r = new Recept(idRecepta, idLekara, imeiprezime, idPacijenta, l);
            RukovanjeZdravstvenimKartonima.DodajRecept(r);
            RukovanjeZdravstvenimKartonima.SerijalizacijaRecepata();
            KartonLekar kl = new KartonLekar(izabran);
            kl.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Izvestaj
        {
            KartonLekar kl = new KartonLekar(izabran);
            kl.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Odustani
        {
            KartonLekar kl = new KartonLekar(izabran);
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
