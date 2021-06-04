using Bolnica.DTO;
using Bolnica.Kontroler;
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
    public partial class LicniProfil : UserControl
    {
        private String korisnickoIme;
        private NaloziPacijenataKontroler naloziPacijenataKontroler=new NaloziPacijenataKontroler();
        public LicniProfil(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            PacijentDTO pacijent = naloziPacijenataKontroler.PretraziPoKorisnickomImenu(korisnickoIme);
            InitializeComponent();
            this.DataContext = pacijent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzmeniLicnePodatke(korisnickoIme));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzmeniLozinku(korisnickoIme));
        }
    }
}
