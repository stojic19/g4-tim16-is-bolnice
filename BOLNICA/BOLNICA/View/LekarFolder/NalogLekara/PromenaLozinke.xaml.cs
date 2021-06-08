using Bolnica.LekarFolder;
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

namespace Bolnica.View.LekarFolder.NalogLekara
{
    public partial class PromenaLozinke : UserControl
    {
        public PromenaLozinke( )
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new NalogLekara());
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new NalogLekara());
        }
    }
}
