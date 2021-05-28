using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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

namespace Bolnica.PacijentFolder
{
    /// <summary>
    /// Interaction logic for PrikazAnketa.xaml
    /// </summary>
    public partial class PrikazAnketa : UserControl
    {
        AnketaKontroler anketeKontroler = new AnketaKontroler();
        private PreglediKontroler preglediKontroler = new PreglediKontroler();
        public static ObservableCollection<Pregled> StariPregledi { get; set; }
        public PrikazAnketa()
        {
            InitializeComponent();
            StariPregledi = new ObservableCollection<Pregled>();
            foreach (Pregled pregled in preglediKontroler.SortPoDatumuPregleda())
            {
                if (pregled.Termin.Pacijent.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovani.KorisnickoIme) && pregled.Odrzan && !pregled.OcenjenPregled && DateTime.Compare(DateTime.Now.Date,pregled.Termin.Datum)>=0)
                    StariPregledi.Add(pregled);
            }

            AnketePacijenta.ItemsSource = StariPregledi;
        }

        private void PopuniAnketu_Click(object sender, RoutedEventArgs e)
        {
            if (AnketePacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite Anketu!");
                return;
            }
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PopuniAnketu(((Pregled)AnketePacijenta.SelectedItem)));
        }

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
            if (!anketeKontroler.DostupnaAnketaOBolnici(PacijentGlavniProzor.ulogovani))
            {
                MessageBox.Show("Već ste ocenili bolnicu!");
                return;
            }
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new OcenjivanjeBolnice());
        }
    }
}
