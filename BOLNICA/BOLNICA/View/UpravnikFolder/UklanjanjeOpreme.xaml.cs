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


namespace Bolnica
/// <summary>
/// Interaction logic for UklanjanjeOpreme.xaml
/// </summary>
{
    public partial class UklanjanjeOpreme : Window
    {
        String izabran = null;
        OpremaKontroler opremaKontroler = new OpremaKontroler();

        public UklanjanjeOpreme(String idOpreme)
        {
            InitializeComponent();
            izabran = idOpreme;
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            opremaKontroler.UkloniOpremu(izabran);
            this.Close();
        }
    }
}

