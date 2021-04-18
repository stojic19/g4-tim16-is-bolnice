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
    /// <summary>
    /// Interaction logic for PrikazObavestenjaPacijent.xaml
    /// </summary>
    public partial class PrikazObavestenjaPacijent : UserControl
    {
        public static ObservableCollection<Obavestenje> obavestenjaPacijenta { get; set; }
        public PrikazObavestenjaPacijent()
        {
            InitializeComponent();
            obavestenjaPacijenta = new ObservableCollection<Obavestenje>();

            List<Obavestenje> datumi = RukovanjeObavestenjimaSekratar.SvaObavestenja().OrderByDescending(user => user.Datum).ToList();

            foreach (Obavestenje obavestenje in datumi)
            {
                obavestenjaPacijenta.Add(obavestenje);
            }

            obavestenjaPacijentaLista.ItemsSource = obavestenjaPacijenta;
        }

    }
}
