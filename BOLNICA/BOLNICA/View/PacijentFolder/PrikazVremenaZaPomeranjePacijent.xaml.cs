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
    public partial class PrikazVremenaZaPomeranjePacijent : UserControl
    {
        public static ObservableCollection<Termin> VremenaTerminaPomeranje { get; set; }
        TerminKontroler terminKontroler = new TerminKontroler();
        public PrikazVremenaZaPomeranjePacijent(Termin izabraniTermin)
        {
            InitializeComponent();
            VremenaTerminaPomeranje = new ObservableCollection<Termin>();
            foreach (Termin t in terminKontroler.NadjiVremeTermina(izabraniTermin))
                VremenaTerminaPomeranje.Add(t);
            vremenaZaPomeranje.ItemsSource = VremenaTerminaPomeranje;
        }

        private void izaberiTermin_Click(object sender, RoutedEventArgs e)
        {
            if (vremenaZaPomeranje.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                return;
            }
            PromeniPrikaz(new PotvrdiPomeranjePacijent(((Termin)vremenaZaPomeranje.SelectedItem)));
        }

        public void PromeniPrikaz(UserControl userControl)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(userControl);
        }
    }
}
