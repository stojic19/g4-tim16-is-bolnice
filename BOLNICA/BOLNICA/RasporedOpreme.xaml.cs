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
    /// Interaction logic for RasporedOpreme.xaml
    /// </summary>
    public partial class RasporedOpreme : UserControl
    {
        public static ObservableCollection<Prostor> Prostori { get; set; }
        public RasporedOpreme()
        {
            InitializeComponent();

            this.DataContext = this;

            Prostori = new ObservableCollection<Prostor>();

            foreach (Prostor p in RukovanjeProstorom.SviProstori())
            {
                Prostori.Add(p);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           /* Prostor izabranZaMenjanje = (Prostor)dataGridProstori.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmenaProstora izmena = new IzmenaProstora(izabranZaMenjanje.IdProstora);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Izaberite prostor koji želite da izmenite!");
            }*/
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrikazOpreme po = new PrikazOpreme();
            po.show();
            this.Close();
        }
    }
}
