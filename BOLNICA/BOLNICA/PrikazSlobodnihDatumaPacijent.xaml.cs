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
    /// Interaction logic for PrikazSlobodnihDatumaPacijent.xaml
    /// </summary>
    public partial class PrikazSlobodnihDatumaPacijent : Window
    {
        public static ObservableCollection<Termin> SlobodniDatumi { get; set; }
        public PrikazSlobodnihDatumaPacijent()
        {
            InitializeComponent();
            SlobodniDatumi = new ObservableCollection<Termin>();

            foreach (Termin t in ZakazivanjeSaPrioritetomPacijent.datumi)
            {
                SlobodniDatumi.Add(t);
            }

            slobodniDatumiLista.ItemsSource = SlobodniDatumi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //PrikazVremenaTerminaPacijent pr = new PrikazVremenaTerminaPacijent(((Termin)slobodniDatumiLista.SelectedItem));
           // pr.Show();
            this.Close();
        }
    }
}
