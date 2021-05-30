using Bolnica.ViewModel.PacijentViewModel;
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
    public partial class PrikazKartona : UserControl
    {
        KartonViewModel kartonViewModel;
        public PrikazKartona(String korisnickoIme)
        {
            InitializeComponent();
            kartonViewModel = new KartonViewModel(korisnickoIme);
            this.DataContext = kartonViewModel;
        }
    }
}
