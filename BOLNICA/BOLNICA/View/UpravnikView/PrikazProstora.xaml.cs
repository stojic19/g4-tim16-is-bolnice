using Bolnica.DTO;
using Bolnica.Kontroler;
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

        public static ObservableCollection<ProstorDTO> Prostori { get; set; }
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();

        public PrikazProstora()
        {
            InitializeComponent();

            prostoriKontroler.ProvjeriDaLiJeProstorRenoviran();

            this.DataContext = this;

            Prostori = new ObservableCollection<ProstorDTO>();

            foreach (ProstorDTO p in prostoriKontroler.SviProstori())
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

            ProstorDTO izabranZaMenjanje = (ProstorDTO)dataGridProstori.SelectedItem;

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
            ProstorDTO izabranZaBrisanje = (ProstorDTO)dataGridProstori.SelectedItem;

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
            ProstorDTO izabran = (ProstorDTO)dataGridProstori.SelectedItem;

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
            ProstorDTO izabran = (ProstorDTO)dataGridProstori.SelectedItem;
            if (dataGridProstori.SelectedItems.Count == 1)
            {
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new NapraviDvijeProstorije(izabran);
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }
            MessageBox.Show("Morate izabrati jedan prostor!");
        }

        private void DvaUJedan_Click(object sender, RoutedEventArgs e)
        {
            List<ProstorDTO> prostoriZaRenoviranje = new List<ProstorDTO>();
            if (dataGridProstori.SelectedItems.Count == 2)
            {
                foreach (ProstorDTO p in dataGridProstori.SelectedItems)
                {
                    prostoriZaRenoviranje.Add(p);
                }

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                UserControl usc = null;
                usc = new NapraviJednuProstoriju(prostoriZaRenoviranje);
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }

            MessageBox.Show("Morate izabrati dva prostora! (Drzite CTRL kako biste izabrali drugi prostor)");
        }

        private void SearchBox_KeyUp(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ProstorDTO> filtriranje = new ObservableCollection<ProstorDTO>();

            foreach (ProstorDTO p in Prostori)
            {
                if (p.NazivProstora.StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase) ||
                    p.VrstaProstora.ToString().StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase) ||
                    p.Sprat.ToString().StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    filtriranje.Add(p);
                }
            }

            dataGridProstori.ItemsSource = filtriranje;
        }
    }
}
