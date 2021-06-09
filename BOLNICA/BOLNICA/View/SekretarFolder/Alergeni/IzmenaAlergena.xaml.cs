using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
using Bolnica.ViewModel.SekretarViewModel;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for IzmenaAlergena.xaml
    /// </summary>
    public partial class IzmenaAlergena : UserControl
    {
        IzmenaAlergenaViewModel izmenaAlergenaViewModel;

        public IzmenaAlergena(String idPacijenta,String idAlergena)
        {
            InitializeComponent();
            izmenaAlergenaViewModel = new IzmenaAlergenaViewModel(idPacijenta, idAlergena);
            this.DataContext = izmenaAlergenaViewModel;
        }
    }
}
