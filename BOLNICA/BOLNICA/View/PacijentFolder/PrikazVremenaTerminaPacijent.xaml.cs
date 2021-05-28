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
    public partial class PrikazVremenaTerminaPacijent : UserControl
    {
        VremenaViewModel vremenaViewModel;
        public PrikazVremenaTerminaPacijent(TerminDTO termin,ZakazivanjePregledaDTO podaci)
        {
            InitializeComponent();
            vremenaViewModel = new VremenaViewModel(termin, podaci);
            this.slobodniTerminiVremena.ItemsSource = vremenaViewModel.SlobodniTermini;
            this.DataContext = vremenaViewModel;
        }
    }
}
