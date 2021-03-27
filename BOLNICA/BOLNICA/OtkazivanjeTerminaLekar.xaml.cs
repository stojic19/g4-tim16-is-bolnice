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

    public partial class OtkazivanjeTerminaLekar : Window
    {
        Termin izabran = null;
        public OtkazivanjeTerminaLekar(Termin t)
        {
            InitializeComponent();
            izabran = t;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            RukovanjeTerminima.OtkaziTermin(izabran.IdTermina);
            this.Close();
        }
    }
}
