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
    /// Interaction logic for UklanjanjeObavestenja.xaml
    /// </summary>
    public partial class UklanjanjeObavestenja : Window
    {
        String izabran = null;
        public UklanjanjeObavestenja(String idTermina)
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

            RukovanjeObavestenjimaSekratar.UkolniObavestenje(izabran);
            this.Close();
        }
    }
}
