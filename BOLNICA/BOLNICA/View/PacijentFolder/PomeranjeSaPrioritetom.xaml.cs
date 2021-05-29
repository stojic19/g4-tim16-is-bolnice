using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.ViewModel.PacijentViewModel;
using Model;
using MoreLinq;
using PowerfulExtensions.Linq;
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
    public partial class PomeranjeSaPrioritetom : UserControl
    {
        PomeranjePregledaViewModel pomeranjePregledaViewModel;
        public PomeranjeSaPrioritetom(TerminDTO terminZaPomeranje)
        {
            InitializeComponent();
            pomeranjePregledaViewModel = new PomeranjePregledaViewModel(terminZaPomeranje);
            this.DataContext = pomeranjePregledaViewModel;

        }
    }
}
