using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.ViewModel.PacijentViewModel;
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

namespace Bolnica.PacijentFolder
{
    public partial class PrikazAnketa : UserControl
    {
        SveAnketeViewModel sveAnketeViewModel;
        public PrikazAnketa(String korisnickoIme)
        {
            InitializeComponent();
            sveAnketeViewModel = new SveAnketeViewModel(korisnickoIme);
            AnketePacijenta.ItemsSource = sveAnketeViewModel.ObavljeniPregledi;
            this.DataContext = sveAnketeViewModel;
        }
    }
}
