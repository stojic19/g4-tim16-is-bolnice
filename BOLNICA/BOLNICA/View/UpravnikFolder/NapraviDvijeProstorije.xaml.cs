using Bolnica.UpravnikFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

    public partial class NapraviDvijeProstorije : UserControl
    {
        private Prostor izabranaProstorija;

        public NapraviDvijeProstorije(Prostor izabran)
        {
            InitializeComponent();
            izabranaProstorija = izabran;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
