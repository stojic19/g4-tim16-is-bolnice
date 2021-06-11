using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder.Operacija;
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

namespace Bolnica.SekretarFolder
{
    /// <summary>
    /// Interaction logic for PrikazPregledaSekretar.xaml
    /// </summary>
    public partial class LegendaSimbola : UserControl
    {
        public LegendaSimbola()
        {
            InitializeComponent();
        }

        private void Povratak_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new Pomoc();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
