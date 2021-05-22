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
    public partial class PrikazDatumaZaPomeranjeLekar : UserControl
    {
        public static ObservableCollection<Termin> SlobodniDatumiPomeranjeLekar { get; set; }
        public PrikazDatumaZaPomeranjeLekar()
        {
            InitializeComponent();
            SlobodniDatumiPomeranjeLekar = new ObservableCollection<Termin>();

            foreach (Termin t in PomeranjeSaPrioritetom.datumiZaIzmenu)
            {
                SlobodniDatumiPomeranjeLekar.Add(t);
            }

            slobodniDatumiZaPomeranje.ItemsSource = SlobodniDatumiPomeranjeLekar;
        }
        private void izaberiDatum_Click(object sender, RoutedEventArgs e)
        {
            if (slobodniDatumiZaPomeranje.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite datum!");
                return;
            }
            PromeniPrikaz(new PrikazVremenaZaPomeranjePacijent((Termin)slobodniDatumiZaPomeranje.SelectedItem));
        }
        public void PromeniPrikaz(UserControl userControl)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(userControl);
        }
    }
}
