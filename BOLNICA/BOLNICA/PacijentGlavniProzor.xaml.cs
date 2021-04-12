using Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PacijentGlavniProzor.xaml
    /// </summary>
    public partial class PacijentGlavniProzor : Window
    {
        public PacijentGlavniProzor()
        {
            InitializeComponent();
        }

        private void strelica_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void obavestenja_Click(object sender, RoutedEventArgs e)
        {

            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazObavestenjaPacijent();
            MainPanel.Children.Add(usc);

        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new ZakazivanjeSaPrioritetomPacijent();
            MainPanel.Children.Add(usc);

        }

        private void Raspored_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazRasporedaPacijent();
            MainPanel.Children.Add(usc);

        }

        private void Terapija_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Karton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ankete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
        }
      

    }
}
