using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.ViewModel.PacijentViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class PrikazVremenaZaPomeranjePacijent : UserControl
    {

        VremenaPomeranjaViewModel vremenaPomeranjaViewModel;
        public PrikazVremenaZaPomeranjePacijent(List<TerminDTO> terminiZaIzmenu, ZakazivanjePregledaDTO podaci)
        {
            InitializeComponent();
            vremenaPomeranjaViewModel = new VremenaPomeranjaViewModel(terminiZaIzmenu, podaci);
            vremenaZaPomeranje.ItemsSource = vremenaPomeranjaViewModel.SlobodniTermini;
            this.DataContext = vremenaPomeranjaViewModel;
        }
    }
}
