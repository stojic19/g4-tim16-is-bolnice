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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class DetaljiOLijeku : UserControl
    {
        public static ObservableCollection<Sastojak> Sastojci { get; set; } 
        String IDLeka = null;
        public DetaljiOLijeku(String id)
        {
            InitializeComponent();

            IDLeka = id;
            Lek izabran = RukovanjeZahtjevima.pretraziLekPoId(id);
            textBoxNaziv.Text = izabran.NazivLeka;
            textBoxProizvodjac.Text = izabran.Proizvodjac;
            checkBox.IsChecked = izabran.Verifikacija;

            this.DataContext = this;
            Sastojci = new ObservableCollection<Sastojak>();

            foreach (Sastojak s in izabran.Sastojci)
            {
                Sastojci.Add(s);
            }

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {

            RukovanjeNeodobrenimLijekovima.SerijalizacijaLijekova();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(new PrikazLijekova());
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)

        {

            DodavanjeSastojka dodavanje = new DodavanjeSastojka(IDLeka);
            dodavanje.Show();

        }

        private void dataGridSastojci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
