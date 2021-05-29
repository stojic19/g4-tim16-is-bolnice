using Bolnica.Model;
using Bolnica.Servis;
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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for RenoviranjeProstorije.xaml
    /// </summary>
    public partial class RenoviranjeProstorije : System.Windows.Controls.UserControl
    {
        ProstoriServis prostoriServis = new ProstoriServis();

        private Prostor izabranProstor;
        public RenoviranjeProstorije(Prostor izabran)
        {
            InitializeComponent();
            izabranProstor = izabran;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Renoviranje renoviranje = new Renoviranje(Guid.NewGuid().ToString(), new Prostor(), DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndtDate.Text));

            prostoriServis.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndtDate.SelectedDate);

           // izabranProstor.Renoviranje = renoviranje;
            RenoviranjeServis.DodajZaRenoviranje(renoviranje);
            RenoviranjeServis.ProveriRenoviranje();
            RenoviranjeServis.SerijalizacijaProstoraZaRenoviranje();
            ProstoriServis.SerijalizacijaProstora();

            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            System.Windows.Controls.UserControl usc = null;
            usc = new PrikazProstora();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            System.Windows.Controls.UserControl usc = null;
            usc = new PrikazProstora();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);

        }
    }
}
