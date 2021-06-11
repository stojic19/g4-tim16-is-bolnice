using Bolnica.DTO;
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

namespace Bolnica.PacijentFolder
{
    public partial class DetaljiTermina : Window
    {
        public DetaljiTermina(TerminDTO izabraniTermin)
        {
            InitializeComponent();
            this.DataContext = izabraniTermin;
        }

        private void uRedu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
