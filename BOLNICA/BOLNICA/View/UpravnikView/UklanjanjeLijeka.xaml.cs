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
/// Interaction logic for UklanjanjeLijeka.xaml
/// </summary>
{
    public partial class UklanjanjeLijeka : Window
    {
        String izabran = null;
        LekoviKontroler lekoviKontroler = new LekoviKontroler();

        public UklanjanjeLijeka(String idLijeka)
        {
            InitializeComponent();
            izabran = idLijeka;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            lekoviKontroler.UkloniLijek(izabran);
            this.Close();
        }
    }
}

