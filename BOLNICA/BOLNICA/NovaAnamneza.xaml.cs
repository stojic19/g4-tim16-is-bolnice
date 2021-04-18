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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica.Lekar
{
   
    public partial class NovaAnamneza : Window
    {

        String izabran = null;
        public static ObservableCollection<Anamneza> Anamneze { get; set; }
        public NovaAnamneza(String idPacijenta)
        {
            InitializeComponent();
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

            Anamneze = new ObservableCollection<Anamneza>();

            foreach (Anamneza a in zk.Anamneze)
            {
                Anamneze.Add(a);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) //Sacuvaj
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Izvestaj
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Otkazi
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e) // Nazad
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Obrisi
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //Dodaj
        {

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
