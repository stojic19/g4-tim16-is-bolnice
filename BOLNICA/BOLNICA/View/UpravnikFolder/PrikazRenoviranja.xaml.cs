using Bolnica.Model;
using Bolnica.Servis;
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

namespace Bolnica.UpravnikFolder
{
    /// <summary>
    /// Interaction logic for PrikazRenoviranja.xaml
    /// </summary>
    public partial class PrikazRenoviranja : UserControl
    {
        public static ObservableCollection<Renoviranje> Renoviranje { get; set; }
        ProstoriServis prostoriServis = new ProstoriServis();
        RenoviranjeServis renoviranjeServis = new RenoviranjeServis();

        public PrikazRenoviranja()
        {
            InitializeComponent();

            prostoriServis.ProvjeriDaLiJeProstorRenoviran();

            this.DataContext = this;

            Renoviranje = new ObservableCollection<Renoviranje>();

            foreach (Renoviranje r in renoviranjeServis.SvaRenoviranja())
            {
                Renoviranje.Add(r);
            }
        }

        private void ukloni_Click(object sender, RoutedEventArgs e)
        {

            Renoviranje izabranZaBrisanje = (Renoviranje)dataGridRenoviranje.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                UklanjanjeRenoviranja uklanjanje = new UklanjanjeRenoviranja(izabranZaBrisanje);
                uklanjanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite renoviranje koje želite da otkažete!");
            }

        }
    }
}
