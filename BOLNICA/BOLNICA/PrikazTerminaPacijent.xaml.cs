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
    /// Interaction logic for PrikazTerminaPacijent.xaml
    /// </summary>
    public partial class PrikazTerminaPacijent : Window
    {
        public static ObservableCollection<Termin> Termini { get; set; }

        public PrikazTerminaPacijent()
        {
            InitializeComponent();

            this.DataContext = this;

            Termini = new ObservableCollection<Termin>();

            foreach (Termin t in RukovanjeTerminima.DobaviSveTermine())
            {
                Termini.Add(t);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ZakazivanjeTerminaPacijent zakazivanje = new ZakazivanjeTerminaPacijent();
            zakazivanje.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RukovanjeTerminima rukovanje = new RukovanjeTerminima();
            if (dataGridTerminiPacijenta.SelectedIndex != -1)
                rukovanje.OtkaziPregled(((Termin)dataGridTerminiPacijenta.SelectedItem).IdTermina);
            else
                MessageBox.Show("Izaberite termin za otkazivanje!");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

       
    }
}
