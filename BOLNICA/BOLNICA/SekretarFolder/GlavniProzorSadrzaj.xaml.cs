using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder.Operacija;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.SekretarFolder
{
    /// <summary>
    /// Interaction logic for GlavniProzorSadrzaj.xaml
    /// </summary>
    public partial class GlavniProzorSadrzaj : UserControl
    {
        public GlavniProzorSadrzaj()
        {
            InitializeComponent();
        }
        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Ucitaj();

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeObavestenjimaSekratar.Ucitaj();

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Termini_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Operacija_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Stacionarno_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Naplata_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();*/
            Login login = new Login();
            login.Show();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
