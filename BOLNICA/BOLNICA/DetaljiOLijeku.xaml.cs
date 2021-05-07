using Bolnica.Model;
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
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for DetaljiOLijeku.xaml
    /// </summary>
    public partial class DetaljiOLijeku : UserControl
    {
        public DetaljiOLijeku(String id)
        {
            InitializeComponent();

            Lek izabran = RukovanjeLijekovima.pretraziPoId(id);
            textBoxId.Text = izabran.IDLeka;
            textBoxNaziv.Text = izabran.NazivLeka;
            textBoxProizvodjac.Text = izabran.Proizvodjac;
            textBoxSastojci.Text = izabran.Sastojci;
            checkBox.IsChecked = izabran.JeVerifikovan;

        }

        private void Ok_Click(object sender, RoutedEventArgs e)

        {




            RukovanjeLijekovima.SerijalizacijaLijekova();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new PrikazLijekova();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
