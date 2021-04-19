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
    /// <summary>
    /// Interaction logic for PrikazVremenaZaPomeranjePacijent.xaml
    /// </summary>
    public partial class PrikazVremenaZaPomeranjePacijent : Window
    {
        public static ObservableCollection<Termin> VremenaTerminaPomeranje { get; set; }

        public PrikazVremenaZaPomeranjePacijent(Termin izabraniTermin)
        {
            InitializeComponent();

            VremenaTerminaPomeranje = new ObservableCollection<Termin>();

            foreach (Termin t in RukovanjeTerminima.nadjiVremeTermina(izabraniTermin))
            {
                VremenaTerminaPomeranje.Add(t);
            }

            vremenaZaPomeranjeLista.ItemsSource = VremenaTerminaPomeranje;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vremenaZaPomeranjeLista.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                return;
            }
            PotvrdiPomeranjePacijent pz = new PotvrdiPomeranjePacijent(((Termin)vremenaZaPomeranjeLista.SelectedItem));
            pz.Show();
            this.Close();
        }
    }
}
