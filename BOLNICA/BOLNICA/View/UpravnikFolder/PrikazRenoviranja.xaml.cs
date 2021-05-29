using Bolnica.Model;
using Bolnica.Servis;
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

namespace Bolnica.UpravnikFolder
{
    /// <summary>
    /// Interaction logic for PrikazRenoviranja.xaml
    /// </summary>
    public partial class PrikazRenoviranja : UserControl
    {
        public static ObservableCollection<Renoviranje> Renoviranje { get; set; }

        public PrikazRenoviranja()
        {
            InitializeComponent();

            this.DataContext = this;

            Renoviranje = new ObservableCollection<Renoviranje>();

            foreach (Renoviranje r in RenoviranjeServis.SvaRenoviranja())
            {
                Renoviranje.Add(r);
            }
        }

        private void JednaProstorija_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DvijeProstorije_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
