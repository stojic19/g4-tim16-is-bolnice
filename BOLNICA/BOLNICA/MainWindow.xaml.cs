using Bolnica.Model;
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

namespace Bolnica
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*RukovanjeTerminima.PrivremenaInicijalizacijaLekara();
            RukovanjeZdravstvenimKartonima.InicijalizacijaLekova();
            RukovanjeTerminima.DeserijalizacijaTermina();
            RukovanjeTerminima.DeserijalizacijaSlobodnihTermina();
            RukovanjeProstorom.DeserijalizacijaProstora();
            RukovanjeNalozimaPacijenata.Ucitaj();*/
            //RukovanjeZdravstvenimKartonima.DeserijalizacijaRecepata();
            Login l = new Login();
            l.Show();
            this.Close();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor prikaz = new UpravnikGlavniProzor();
            prikaz.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GlavniProzorSekretar prikaz = new GlavniProzorSekretar();
            prikaz.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PrikazTerminaLekara prikaz = new PrikazTerminaLekara();
            prikaz.Show();
            this.Close();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //PacijentGlavniProzor prikaz = new PacijentGlavniProzor();
           // RukovanjeObavestenjimaSekratar.Ucitaj();
             // RukovanjeTerminima.InicijalizacijaSTermina();
          //  prikaz.Show();
            //this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            RukovanjeProstorom.SerijalizacijaProstora();
            RukovanjeNalozimaPacijenata.Sacuvaj();*/
        }
    }
}
