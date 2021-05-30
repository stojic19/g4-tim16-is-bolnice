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

    public partial class PrikazProstora : UserControl
    {

        public static ObservableCollection<Prostor> Prostori { get; set; }

        public PrikazProstora()
        {
            InitializeComponent();

            this.DataContext = this;

            Prostori = new ObservableCollection<Prostor>();

            foreach (Prostor p in ProstoriServis.SviProstori())
            {
                Prostori.Add(p);
            }

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            DodavanjeProstora dodavanje = new DodavanjeProstora();
            dodavanje.Show();

        }

        private void Izmjeni_Click(object sender, RoutedEventArgs e)
        {

            Prostor izabranZaMenjanje = (Prostor)dataGridProstori.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmenaProstora izmena = new IzmenaProstora(izabranZaMenjanje.IdProstora);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite prostor koji želite da izmenite!");
            }
        }

        private void Ukloni_Click(object sender, RoutedEventArgs e)
        {


            Prostor izabranZaBrisanje = (Prostor)dataGridProstori.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                UklanjanjeProstora uklanjanje = new UklanjanjeProstora(izabranZaBrisanje.IdProstora);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite prostor koji želite da otkažete!");
            }
        }

        private void RasporedOpreme_Click(object sender, RoutedEventArgs e)
        {


            Prostor izabran = (Prostor)dataGridProstori.SelectedItem;

            if (izabran != null)
            {

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new RasporedOpreme(izabran.IdProstora);
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite prostor u kojem zelite da vidite raspored opreme!");
            }
        }

        private void Renoviraj_Click(object sender, RoutedEventArgs e)
        {

            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new RenoviranjeProstorije();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);

        }

        private void JedanUDva_Click(object sender, RoutedEventArgs e)
        {
            Prostor izabran = (Prostor)dataGridProstori.SelectedItem;

            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new NapraviDvijeProstorije(izabran);
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }

        private void DvaUJedan_Click(object sender, RoutedEventArgs e)
        {
            List<Prostor> prostoriZaRenoviranje = new List<Prostor>();
            //(Prostor)dataGridProstori.SelectedItems;

            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new NapraviJednuProstoriju(new Prostor(), new Prostor());
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
