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
    /// Interaction logic for PrikazDatumaZaPomeranjeLekar.xaml
    /// </summary>
    public partial class PrikazDatumaZaPomeranjeLekar : Window
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

            slobodniDatumiPomLista.ItemsSource = SlobodniDatumiPomeranjeLekar;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (slobodniDatumiPomLista.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite datum!");
                return;
            }

            PrikazVremenaZaPomeranjePacijent pr = new PrikazVremenaZaPomeranjePacijent((Termin)slobodniDatumiPomLista.SelectedItem);
            pr.Show();
            this.Close();
        }
    }
}
