using Bolnica.Kontroler;
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
namespace Bolnica
{
    public partial class ZakazivanjeSaPrioritetomPacijent : UserControl
    {
        private ZakazivanjeViewModel zakazivanjeViewModel;
        public ZakazivanjeSaPrioritetomPacijent(String korisnickoIme)
        {
            InitializeComponent();
            zakazivanjeViewModel = new ZakazivanjeViewModel(korisnickoIme);
            this.DataContext = zakazivanjeViewModel;
        }

    }
}
