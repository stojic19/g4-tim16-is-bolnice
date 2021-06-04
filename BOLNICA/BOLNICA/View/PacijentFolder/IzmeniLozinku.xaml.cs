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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View.PacijentFolder
{
    public partial class IzmeniLozinku : UserControl
    {
        private String korisnickoIme;
        public IzmeniLozinku(String korisnickoIme)
        {
            InitializeComponent();
            this.korisnickoIme = korisnickoIme;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new LicniProfil(korisnickoIme));

        }
    }
}
