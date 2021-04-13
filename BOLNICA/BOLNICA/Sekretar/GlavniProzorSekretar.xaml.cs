using Bolnica.Sekretar.Pregled;
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
    public partial class GlavniProzorSekretar : Window
    {
        public GlavniProzorSekretar()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Ucitaj();
            PrikazNalogaSekretar prikaz = new PrikazNalogaSekretar();
            prikaz.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RukovanjeObavestenjimaSekratar.Ucitaj();
            ObavestenjaSekretar prikaz = new ObavestenjaSekretar();
            prikaz.Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TerminiPregledaSekretar tps = new TerminiPregledaSekretar();
            tps.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }
    }
}
