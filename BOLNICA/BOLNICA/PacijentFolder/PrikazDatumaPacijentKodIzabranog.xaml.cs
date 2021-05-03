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
    /// Interaction logic for PrikazDatumaPacijentKodIzabranog.xaml
    /// </summary>
    public partial class PrikazDatumaPacijentKodIzabranog : Window
    {
        public static ObservableCollection<Termin> SlobodniDatumi { get; set; }
        public PrikazDatumaPacijentKodIzabranog()
        {
            InitializeComponent();
            SlobodniDatumi = new ObservableCollection<Termin>();

            foreach (Termin t in ZakazivanjeSaPrioritetomPacijent.datumi)
            {
                SlobodniDatumi.Add(t);
            }

            slobodniDatumiKodIzabranog.ItemsSource = SlobodniDatumi;
        }

        private void izaberiDatum_Click(object sender, RoutedEventArgs e)
        {
            if (slobodniDatumiKodIzabranog.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite datum!");
                return;
            }
            PrikazVremenaTerminaPacijent pr = new PrikazVremenaTerminaPacijent(((Termin)slobodniDatumiKodIzabranog.SelectedItem));
            pr.Show();
            this.Close();
        }
    }
}
