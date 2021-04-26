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

    public partial class ZakazivanjeTerminaLekar : Window
    {
        String korisnik = null;
        DateTime izabranDatum ;
        String izabranLekar = null;
        String izabranPacijent = null;
        String izabranaVrstaTermina = null;

        public static ObservableCollection<Termin> slobodniTermini { get; set; } = new ObservableCollection<Termin>();
        public ZakazivanjeTerminaLekar(String lekar)
        {
            InitializeComponent();
            korisnik = lekar;

            this.TabelaPacijenata.ItemsSource = RukovanjeNalozimaPacijenata.sviNaloziPacijenata;
            CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaPacijenata.ItemsSource);
            view1.Filter = UserFilterPacijent;

            this.TabelaLekara.ItemsSource = RukovanjeTerminima.sviLekari;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource);
            view2.Filter = UserFilterLekar;


            this.DataContext = this;

        }


        private void Button_Click(object sender, RoutedEventArgs e) //odustani
        {
            PrikazTerminaLekara ptl = new PrikazTerminaLekara(korisnik);
            ptl.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //potvrdi
        {

            Lekar lekar = RukovanjeTerminima.pretraziLekare(izabranLekar);
            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(izabranPacijent);


            if (!datum.SelectedDate.HasValue || pocVreme.SelectedIndex == -1 || idPacijenta.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Termin t = (Termin)pocVreme.SelectedItem;

            t.Lekar = lekar;
            t.Pacijent = pacijent;
            Double trajanje = 0;

            if (izabranaVrstaTermina.Equals("Operacija"))
            {
                trajanje = 120;
            }
            else
            {
                trajanje = 30;
            }

            t.Trajanje = trajanje;

            RukovanjeTerminima.ZakaziTermin(t, korisnik);

            PrikazTerminaLekara ptl = new PrikazTerminaLekara(korisnik);
            ptl.Show();
            this.Close();

        }


        private bool UserFilterPacijent(object item)
        {
            if (String.IsNullOrEmpty(pretragaPacijenata.Text))
                return true;
            else
                return ((item as Pacijent).Prezime.IndexOf(pretragaPacijenata.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool UserFilterLekar(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekara.Text))
                return true;
            else
                return ((item as Lekar).Prezime.IndexOf(pretragaLekara.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }

        private void pretragaPacijenata_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaPacijenata.ItemsSource).Refresh();
        }

        private void pretragaLekara_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TabelaLekara.ItemsSource).Refresh();
        }

        private void TabelaPacijenata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaPacijenata.SelectedItems.Count > 0)
            {
                Pacijent item = (Pacijent)TabelaPacijenata.SelectedItems[0];
                idPacijenta.Text = item.Ime + " " + item.Prezime;
                izabranPacijent = item.KorisnickoIme;
            }


        }

        private void TabelaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabelaLekara.SelectedItems.Count > 0)
            {
                Lekar item = (Lekar)TabelaLekara.SelectedItems[0];
                idLekara.Text = item.Ime + " " + item.Prezime;
                izabranLekar = item.KorisnickoIme;
                refresujPocetnoVreme();
            }




        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? datum = this.datum.SelectedDate;

            if (datum.HasValue)
            {
                izabranDatum = datum.Value; //ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                refresujPocetnoVreme();

            }

        }

        private void vrTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vrTermina.SelectedIndex == 0)
            {

                izabranaVrstaTermina = "Pregled";
            }
            else if (vrTermina.SelectedIndex == 1)
            {
                izabranaVrstaTermina = "Operacija";
            }


            refresujPocetnoVreme();
        }

        private void refresujPocetnoVreme()
        {


            slobodniTermini.Clear();
            foreach (Termin t in RukovanjeTerminima.slobodniTermini)
            {
                if (t.Datum.CompareTo(izabranDatum) == 0 && t.Lekar.KorisnickoIme.Equals(izabranLekar) && t.getVrstaTerminaString().Equals(izabranaVrstaTermina))
                {
                    Console.WriteLine(izabranaVrstaTermina + t.getVrstaTerminaString());
                    slobodniTermini.Add(t);

                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //back
        {
            PrikazTerminaLekara ptl = new PrikazTerminaLekara(korisnik);
            ptl.Show();
            this.Close();

        }
    }
}
