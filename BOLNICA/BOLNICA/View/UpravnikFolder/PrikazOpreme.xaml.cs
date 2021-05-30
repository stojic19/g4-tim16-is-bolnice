using Bolnica.Kontroler;
using Bolnica.UpravnikFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

    public partial class PrikazOpreme : UserControl
    {
        OpremaKontroler opremaKontroler = new OpremaKontroler();
        public static ObservableCollection<Oprema> Oprema { get; set; }

        public PrikazOpreme()
        {
            InitializeComponent();

            this.DataContext = this;

            Oprema = new ObservableCollection<Oprema>();

            foreach (Oprema o in opremaKontroler.SvaOprema())
            {
                Oprema.Add(o);
            }
        }

        private void Dodavanje_Click(object sender, RoutedEventArgs e)
        {

            DodavanjeOpreme dodavanje = new DodavanjeOpreme();
            dodavanje.Show();

        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {

            Oprema izabranZaMenjanje = (Oprema)dataGridOprema.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmenaOpreme izmena = new IzmenaOpreme(izabranZaMenjanje.IdOpreme);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koju želite da izmenite!");
            }
        }

        private void Uklanjanje_Click(object sender, RoutedEventArgs e)
        {


            Oprema izabranZaBrisanje = (Oprema)dataGridOprema.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                UklanjanjeOpreme uklanjanje = new UklanjanjeOpreme(izabranZaBrisanje.IdOpreme);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koju želite da uklonite!");
            }
        }


        private void Premjestanje_Click(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            System.Windows.Controls.UserControl usc = null;
            usc = new PremjestanjeStatickeOpreme();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }


        private void SearchBox_KeyUp(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Oprema> filtriranje = new ObservableCollection<Oprema>();

            foreach (Oprema o in Oprema)
            {
                if (o.IdOpreme.StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase) ||
                    o.NazivOpreme.StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase) ||
                    o.VrstaOpreme.ToString().StartsWith(SearchBox.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    filtriranje.Add(o);
                }
            }

            dataGridOprema.ItemsSource = filtriranje;
        }
    }
}
