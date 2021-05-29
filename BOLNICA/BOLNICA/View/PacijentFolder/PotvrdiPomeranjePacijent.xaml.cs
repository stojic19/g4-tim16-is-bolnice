using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Repozitorijum;
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
    public partial class PotvrdiPomeranjePacijent : UserControl
    {
        PotvrdiPomeranjeViewModel potvrdiPomeranjeViewModel;
        public PotvrdiPomeranjePacijent(List<TerminDTO> terminiZaIzmenu, ZakazivanjePregledaDTO podaci)
        {
            InitializeComponent();
            potvrdiPomeranjeViewModel = new PotvrdiPomeranjeViewModel(terminiZaIzmenu, podaci);
            this.DataContext = potvrdiPomeranjeViewModel;
        }
    }
}
