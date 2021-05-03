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
    /// Interaction logic for PrikazDatumaZaPomeranjePrioritet.xaml
    /// </summary>
    public partial class PrikazDatumaZaPomeranjePrioritet : Window
    {
        public static ObservableCollection<Termin> SlobodniDatumiIzmena { get; set; }
        public PrikazDatumaZaPomeranjePrioritet()
        {
            InitializeComponent();
            SlobodniDatumiIzmena = new ObservableCollection<Termin>();
            foreach (Termin t in PomeranjeSaPrioritetom.datumiZaIzmenu)
                SlobodniDatumiIzmena.Add(t);
            slobodniDatumiPomeranjePrioritet.ItemsSource = SlobodniDatumiIzmena;
        }

        private void izaberiDatum_Click(object sender, RoutedEventArgs e)
        {
            if(slobodniDatumiPomeranjePrioritet.SelectedIndex==-1)
            {
                MessageBox.Show("Izaberite datum!");
                return;
            }
            PrikazVremenaZaPomeranjePacijent prikaz = new PrikazVremenaZaPomeranjePacijent((Termin)slobodniDatumiPomeranjePrioritet.SelectedItem);
            prikaz.Show();
            this.Close();
        }
    }
}
