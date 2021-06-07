using Bolnica.Kontroler;
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

namespace Bolnica.LekarFolder
{
    public partial class PocetnaStranicaLekar : UserControl
    {
        private String KorisnickoImeLekara = null;
        LekariKontroler lekariKontroler = new LekariKontroler();
        public PocetnaStranicaLekar(string koriscnickoImeLekara)
        {
            InitializeComponent();
            KorisnickoImeLekara = koriscnickoImeLekara;
            imePrezime.Content = lekariKontroler.ImeiPrezime(koriscnickoImeLekara) + "!";
        }

        

        private void PrikazRasporeda(object sender, RoutedEventArgs e)
        {

            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PrikazTerminaLekara(KorisnickoImeLekara));
            LekarGlavniProzor.postaviPrethodnu(this);
        }

        private void PrikazOdsustva(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.postaviPrethodnu(this);
        }

        private void EvidencijaUtrosenog(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.postaviPrethodnu(this);
        }

        private void PrikazLekova(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoImeLekara));
            LekarGlavniProzor.postaviPrethodnu(this);
        }
    }
}
