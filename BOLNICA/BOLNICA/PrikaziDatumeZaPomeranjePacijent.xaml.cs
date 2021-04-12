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
    /// Interaction logic for PrikaziDatumeZaPomeranjePacijent.xaml
    /// </summary>
    public partial class PrikaziDatumeZaPomeranjePacijent : Window
    {
        public static ObservableCollection<Termin> SlobodniDatumiZaPomeranje { get; set; }
        public static string stariTermin = null;
        public PrikaziDatumeZaPomeranjePacijent(Termin izabraniTermin)
        {
            InitializeComponent();
            stariTermin = izabraniTermin.IdTermina;
            SlobodniDatumiZaPomeranje = new ObservableCollection<Termin>();
            List<Termin> pom = new List<Termin>();
            foreach (Termin t in RukovanjeTerminima.NadjiDatumeZaPomeranje(izabraniTermin))
            {
                bool nasao = false;
                foreach (Termin tr in pom)
                {
                    if (tr.Datum.Equals(t.Datum))
                    {
                        nasao = true;
                        break;
                    }

                }
                if (!nasao)
                    pom.Add(t);

            }


            foreach (Termin t in pom)
            {
                SlobodniDatumiZaPomeranje.Add(t);
            }

            slobodniDatumiZaPomeranje.ItemsSource = SlobodniDatumiZaPomeranje;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PrikazVremenaZaPomeranjePacijent pr = new PrikazVremenaZaPomeranjePacijent((Termin)slobodniDatumiZaPomeranje.SelectedItem);
            pr.Show();
            this.Close();
        }
    }
}
