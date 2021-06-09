using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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
    public partial class UklanjanjeZahtjeva : Window
    {
        private string izabran = null;
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public UklanjanjeZahtjeva(String idZahtjeva)
        {
            InitializeComponent();
            izabran = idZahtjeva;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            zahtjeviKontroler.UkloniZahtjev(izabran);             
            this.Close();
        }
    }
}
