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
        public static ObservableCollection<Prostor> Prostori { get; set; }
       
        public RenoviranjeProstorije()
        {
            InitializeComponent();
            this.DataContext = this;

            Prostori = new ObservableCollection<Prostor>();

            foreach (Prostor p in ProstoriServis.SviProstori())
            {
                Prostori.Add(p);
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (!prostoriServis.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndtDate.SelectedDate))
            {
                Prostor izabranZaRenoviranje = (Prostor)dataGridProstori.SelectedItem;
                Renoviranje renoviranje = new Renoviranje(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndtDate.Text));
                RenoviranjeServis.DodajZaRenoviranje(renoviranje);
                RenoviranjeServis.ProveriRenoviranje();
                RenoviranjeServis.SerijalizacijaProstoraZaRenoviranje();
                ProstoriServis.SerijalizacijaProstora();

                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
                System.Windows.Controls.UserControl usc = null;
                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }
           
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
