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

namespace Bolnica.PacijentFolder
{
    /// <summary>
    /// Interaction logic for PrikazKartona.xaml
    /// </summary>
    public partial class PrikazKartona : UserControl
    {
        public PrikazKartona()
        {
            InitializeComponent();
            DataContext = PacijentGlavniProzor.ulogovani;
            PodesiPrikaz();
        }

        private void PodesiPrikaz()
        {
            celoIme.Content = PacijentGlavniProzor.ulogovani.Prezime + " (" + "Đorđe" + ") " + PacijentGlavniProzor.ulogovani.Ime;
            brojKartona.Content = "12323";
            bracniStatus.Content = "neudata";
            zaposlenje.Content = "student";
        }

        private void PrikazAlergija_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazAlergenaPacijenta());
        }

        private void PrikazIstorijePregleda_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IstorijaPregleda());
        }
    }
}
