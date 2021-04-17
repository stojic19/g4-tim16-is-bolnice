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

    public partial class PrikazOpreme : Window
    {

        public static ObservableCollection<Oprema> Oprema { get; set; }

        public PrikazOpreme()
        {
            InitializeComponent();

            this.DataContext = this;

            Oprema = new ObservableCollection<Oprema>();

            foreach (Oprema o in RukovanjeOpremom.SvaOprema())
            {
                Oprema.Add(o);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DodavanjeOpreme dodavanje = new DodavanjeOpreme();
            dodavanje.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Oprema izabranZaMenjanje = (Oprema)dataGridOprema.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmenaOpreme izmena = new IzmenaOpreme(izabranZaMenjanje.IdOpreme);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koju želite da izmenite!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            Oprema izabranZaBrisanje = (Oprema)dataGridOprema.SelectedItem;

            if (izabranZaBrisanje != null)
            {

               UklanjanjeOpreme uklanjanje = new UklanjanjeOpreme(izabranZaBrisanje.IdOpreme);
               uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koju želite da uklonite!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {


            Oprema izabran = (Oprema)dataGridOprema.SelectedItem;

            if (izabran!= null)
            {

                RasporedOpreme raspored = new RasporedOpreme(izabran.IdOpreme);
                raspored.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu ciji raspored zelite da vidite!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeOpremom.SerijalizacijaOpreme();
        }

        private void dataGridOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

