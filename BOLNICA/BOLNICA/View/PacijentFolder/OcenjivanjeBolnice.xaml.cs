using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
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
    
    public partial class OcenjivanjeBolnice : UserControl
    {
        private String korisnickoIme;
        private AnketaKontroler anketaKontroler = new AnketaKontroler();
        private PitanjaKontroler pitanjaKontroler = new PitanjaKontroler();
        public OcenjivanjeBolnice(String korisnickoIme)
        {
            InitializeComponent();
            this.korisnickoIme = korisnickoIme;
        }

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazAnketa(korisnickoIme));

        }
    }
}
