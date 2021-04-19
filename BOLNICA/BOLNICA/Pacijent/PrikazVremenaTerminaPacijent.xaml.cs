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
    /// Interaction logic for PrikazVremenaTerminaPacijent.xaml
    /// </summary>
    public partial class PrikazVremenaTerminaPacijent : Window
    {
        public static ObservableCollection<Termin> VremenaTermina { get; set; }
        public PrikazVremenaTerminaPacijent(Termin izabraniTermin)
        {
            InitializeComponent();
            VremenaTermina = new ObservableCollection<Termin>();

            foreach (Termin t in RukovanjeTerminima.nadjiVremeTermina(izabraniTermin))
            {
                VremenaTermina.Add(t);
            }

            slobodiTerminiVremenaLista.ItemsSource = VremenaTermina;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PotvrdiZakazivanjePacijent pz = new PotvrdiZakazivanjePacijent(((Termin)slobodiTerminiVremenaLista.SelectedItem));
            pz.Show();
            this.Close();
        }
    }
}
