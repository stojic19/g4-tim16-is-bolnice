using Bolnica.Kontroler;
using Bolnica.PacijentFolder;
using Bolnica.Repozitorijum;
using Bolnica.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class PrikazRasporedaPacijent : UserControl
    {
        private RasporedTerminaViewModel rasporedTerminaViewModel;
        public PrikazRasporedaPacijent(String korisnickoIme)
        {
            InitializeComponent();
            rasporedTerminaViewModel = new RasporedTerminaViewModel(korisnickoIme);
            sviTermini.ItemsSource = rasporedTerminaViewModel.ZakazaniTerminiPacijenta;
            this.DataContext = rasporedTerminaViewModel;
        }

    }
}
