using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Repozitorijum;
using Bolnica.ViewModel;
using Bolnica.ViewModel.PacijentViewModel;
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
    public partial class OtkazivanjeTerminaPacijent : Window
    {
        private PotvrdiOtkazivanjeViewModel potvrdiOtkazivanjeViewModel;
        private String korisnickoIme;
        public OtkazivanjeTerminaPacijent(TerminDTO izabraniTermin)
        {
            InitializeComponent();
            korisnickoIme = izabraniTermin.IdPacijenta;
            potvrdiOtkazivanjeViewModel = new PotvrdiOtkazivanjeViewModel(izabraniTermin);
            this.DataContext = potvrdiOtkazivanjeViewModel;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazRasporedaPacijent(korisnickoIme));
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
