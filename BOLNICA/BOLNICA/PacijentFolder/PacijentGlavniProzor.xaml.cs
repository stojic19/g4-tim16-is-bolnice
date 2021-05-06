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
    /// 
    
    public partial class PacijentGlavniProzor : Window
    {
        private static Grid GlavniSadrzaj;
        public static Pacijent ulogovani = null;
        public PacijentGlavniProzor(String id)
        {
            InitializeComponent();
            RukovanjeObavestenjimaSekratar.Ucitaj();
            ulogovani = RukovanjeNalozimaPacijenata.PretraziPoId(id);
            GlavniSadrzaj = this.MainPanel;
        }
        public static Grid GetGlavniSadrzaj()
        {
            return GlavniSadrzaj;
        }

        private void strelica_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            Login login = new Login();
            login.Show();
            this.Close();
        }

        public void PromeniPrikaz(UserControl userControl)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(userControl);
        }

        private void obavestenja_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazObavestenjaPacijent());
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new ZakazivanjeSaPrioritetomPacijent());
        }

        private void Raspored_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazRasporedaPacijent());
        }

        private void Terapija_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazTerapijePacijent());
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
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }
      

    }
}
