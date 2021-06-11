using Bolnica.Kontroler;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
using Bolnica.ViewModel.SekretarViewModel;
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

    public partial class PrikazNalogaSekretar : UserControl
    {
        PacijentViewModel pacijentViewModel;

        public PrikazNalogaSekretar()
        {
            InitializeComponent();
            pacijentViewModel = new PacijentViewModel();
            dataGridNaloziPacijenata.ItemsSource = pacijentViewModel.Pacijenti;
            this.DataContext = pacijentViewModel;
        }
    }
}
