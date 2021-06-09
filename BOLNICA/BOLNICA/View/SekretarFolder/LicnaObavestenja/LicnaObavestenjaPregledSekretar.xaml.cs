
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.ViewModel.SekretarViewModel;
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

namespace Bolnica.View.SekretarFolder.LicnaObavestenja
{
    /// <summary>
    /// Interaction logic for LicnaObavestenjaSekretar.xaml
    /// </summary>
    public partial class LicnaObavestenjaPregledSekretar : UserControl
    {
        LicnaObavestenjaPregledViewModel licnaObavestenjaViewModel;
        public LicnaObavestenjaPregledSekretar(string idObavestenja)
        {
            InitializeComponent();
            licnaObavestenjaViewModel = new LicnaObavestenjaPregledViewModel(idObavestenja);
            this.DataContext = licnaObavestenjaViewModel;
        }
    }
}
