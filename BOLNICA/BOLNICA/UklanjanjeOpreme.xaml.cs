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
        public UklanjanjeOpreme(String idOpreme)
        {
            izabran = idOpreme;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            RukovanjeOpremom.UkloniOpremu(izabran);
            this.Close();
        }
    }
}

