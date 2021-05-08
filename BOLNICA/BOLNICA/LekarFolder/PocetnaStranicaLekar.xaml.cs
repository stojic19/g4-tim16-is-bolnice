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

namespace Bolnica.LekarFolder
{
    public partial class PocetnaStranicaLekar : UserControl
    {
        private String KorisnickoImeLekara = null;
        public PocetnaStranicaLekar(string koriscnickoImeLekara)
        {
            InitializeComponent();
            KorisnickoImeLekara = koriscnickoImeLekara;
        }

        

        private void PrikazRasporeda(object sender, RoutedEventArgs e)
        {

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(KorisnickoImeLekara));
           
        }

        private void PrikazOdsustva(object sender, RoutedEventArgs e)
        {

        }

        private void EvidencijaUtrosenog(object sender, RoutedEventArgs e)
        {

        }

        private void PrikazLekova(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoImeLekara));
        }
    }
}
