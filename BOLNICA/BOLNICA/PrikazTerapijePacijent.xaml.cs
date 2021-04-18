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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for PrikazTerapijePacijent.xaml
    /// </summary>
    public partial class PrikazTerapijePacijent : UserControl
    {
        public static ObservableCollection<Terapija> sveTerapijePacijenta { get; set; }
        public PrikazTerapijePacijent()
        {
            InitializeComponent();
            sveTerapijePacijenta = new ObservableCollection<Terapija>();

            foreach (Terapija t in RukovanjeZdravstvenimKartonima.dobaviSveTerapijePacijenta(PacijentGlavniProzor.ulogovani.KorisnickoIme))
            {
                sveTerapijePacijenta.Add(t);
            }

            LekoviLista.ItemsSource = sveTerapijePacijenta;
        }

        private void ukljuci_Click(object sender, RoutedEventArgs e)
        {

        }

        private void iskljuci_Click(object sender, RoutedEventArgs e)
        {

        }

        private void izvestaj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
