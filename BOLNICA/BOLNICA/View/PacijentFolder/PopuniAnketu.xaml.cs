using Bolnica.DTO;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.PacijentFolder
{
    public partial class PopuniAnketu : UserControl
    {
        PopuniAnketuViewModel popuniAnketuViewModel;
        public PopuniAnketu(PregledDTO izabranZaAnketu)
        {
            InitializeComponent();
            popuniAnketuViewModel = new PopuniAnketuViewModel(izabranZaAnketu);
            this.DataContext = popuniAnketuViewModel;
        }
    }
}
