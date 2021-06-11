using Bolnica.DTO;
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
    public partial class PrikazDatumaZaPomeranjePrioritet : UserControl
    {
        DatumiZaPomeranjeViewModel datumiZaPomeranjeViewModel;
        public PrikazDatumaZaPomeranjePrioritet(TerminDTO izabraniTermin, ZakazivanjePregledaDTO podaci)
        {
            InitializeComponent();
            datumiZaPomeranjeViewModel = new DatumiZaPomeranjeViewModel(izabraniTermin, podaci);
            slobodniDatumiPomeranjePrioritet.ItemsSource = datumiZaPomeranjeViewModel.SlobodniDatumi;
            this.DataContext = datumiZaPomeranjeViewModel;
        }

    }
}
