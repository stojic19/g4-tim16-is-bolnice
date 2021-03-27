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

        public  static ObservableCollection<Termin> Termini { get; set; }

        public  PrikazTerminaLekara()
        {
            InitializeComponent();

            this.DataContext = this;

            Termini = new ObservableCollection<Termin>();

            //Termini.Add(new Termin("231", VrsteTermina.operacija, DateTime.Now, DateTime.Now, new Prostor("231"), new Pacijent("312"), new Lekar("dsadsa")));

            foreach (Termin t in RukovanjeTerminima.DobaviSveTermine())
             {
                Termini.Add(t);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MainWindow glavniProzor = new MainWindow();
            glavniProzor.Show();
            this.Close();
        }
    }
}
