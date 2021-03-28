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

    public partial class PrikazTerminaLekara : Window
    {

        public static ObservableCollection<Termin> Termini { get; set; }

        public PrikazTerminaLekara()
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

            ZakazivanjeTerminaLekar zakazivanje = new ZakazivanjeTerminaLekar();
            zakazivanje.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Termin izabranZaMenjanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmenaTerminaLekar izmena = new IzmenaTerminaLekar(izabranZaMenjanje.IdTermina);
                izmena.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Termin izabranZaBrisanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                OtkazivanjeTerminaLekar otkazivanje = new OtkazivanjeTerminaLekar(izabranZaBrisanje.IdTermina);
                otkazivanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            MainWindow glavniProzor = new MainWindow();
            glavniProzor.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
        }
    }
}
