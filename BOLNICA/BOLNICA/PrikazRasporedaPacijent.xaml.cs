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
    /// Interaction logic for PrikazRasporedaPacijent.xaml
    /// </summary>
    public partial class PrikazRasporedaPacijent : UserControl
    {
        public static ObservableCollection<Termin> Termini { get; set; }
        public static Termin TerminZaPomeranje = null;
        public PrikazRasporedaPacijent()
        {
            InitializeComponent();
            Termini = new ObservableCollection<Termin>();

            foreach (Termin t in RukovanjeTerminima.DobaviSveTermine())
            {
                Termini.Add(t);
            }

            dataGridTerminiPacijenta.ItemsSource = Termini;
        }

        private void informacije_Click(object sender, RoutedEventArgs e)
        {

        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            TerminZaPomeranje = (Termin)dataGridTerminiPacijenta.SelectedItem;
            PomeranjeTerminaPacijent p = new PomeranjeTerminaPacijent((Termin)dataGridTerminiPacijenta.SelectedItem);
            p.Show();
        }

        private void otkazi_Click(object sender, RoutedEventArgs e)
        {
            Termin izabranZaBrisanje = (Termin)dataGridTerminiPacijenta.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                OtkazivanjeTerminaPacijent otkazivanje = new OtkazivanjeTerminaPacijent(izabranZaBrisanje.IdTermina);
                otkazivanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }
    }
}
