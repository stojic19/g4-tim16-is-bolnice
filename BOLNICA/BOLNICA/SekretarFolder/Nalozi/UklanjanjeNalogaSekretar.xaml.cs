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
    public partial class UklanjanjeNalogaSekretar : Window
    {
        String izabran = null;
        public UklanjanjeNalogaSekretar(String idTermina)
        {
            izabran = idTermina;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            RukovanjeNalozimaPacijenata.UkolniNalog(izabran);
            this.Close();
        }
    }
}
