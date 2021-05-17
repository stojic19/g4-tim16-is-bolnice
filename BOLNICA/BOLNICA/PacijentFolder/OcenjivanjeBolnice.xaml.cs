using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
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
    /// Interaction logic for OcenjivanjeBolnice.xaml
    /// </summary>
    public partial class OcenjivanjeBolnice : UserControl
    {
        public OcenjivanjeBolnice()
        {
            InitializeComponent();
        }

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < AnketeServis.pitanjaOBolnici.Count; i++)
            {

                int indexCombo = i + 1;
                postaviOcenuZaPitanje(((ComboBox)this.FindName("pitanje" + indexCombo)).SelectedIndex, i);

            }
            AnketeServis.DodajAnketu(new Anketa(PacijentGlavniProzor.ulogovani,DateTime.Now,null,AnketeServis.pitanjaOBolnici,DodatniKomentar.Text));
            AnketeServis.SerijalizacijaAnketa();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazAnketa());

        }

        private void postaviOcenuZaPitanje(int indexCombo, int indexPitanje)
        {
            switch (indexCombo)
            {

                case 0:
                    AnketeServis.pitanjaOBolnici[indexPitanje].Ocena = OcenaPitanja.jedan;
                    break;
                case 1:
                    AnketeServis.pitanjaOBolnici[indexPitanje].Ocena = OcenaPitanja.dva;
                    break;                                                  
                case 2:                                                    
                    AnketeServis.pitanjaOBolnici[indexPitanje].Ocena = OcenaPitanja.tri;
                    break;                                                
                case 3:                                                    
                    AnketeServis.pitanjaOBolnici[indexPitanje].Ocena = OcenaPitanja.cetiri;
                    break;                                                  
                case 4:                                                    
                    AnketeServis.pitanjaOBolnici[indexPitanje].Ocena = OcenaPitanja.pet;
                    break;
            }
        }
    }
}
