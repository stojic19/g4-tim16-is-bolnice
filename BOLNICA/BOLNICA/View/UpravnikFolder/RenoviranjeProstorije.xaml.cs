using Bolnica.DTO;
using Bolnica.Kontroler;
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
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        RenoviranjeKontroler renoviranjeKontroler = new RenoviranjeKontroler();
        public static ObservableCollection<ProstorDTO> Prostori { get; set; }

        public RenoviranjeProstorije()
        {
            InitializeComponent();
            this.DataContext = this;

            Prostori = new ObservableCollection<ProstorDTO>();

            foreach (ProstorDTO p in prostoriKontroler.SviProstori())
            {
                Prostori.Add(p);
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (!prostoriKontroler.ProvjeriZakazaneTermine((DateTime)PickStartDate.SelectedDate, (DateTime)PickEndtDate.SelectedDate))
            {
                ProstorDTO izabranZaRenoviranje = (ProstorDTO)dataGridProstori.SelectedItem;
                RenoviranjeDTO renoviranje = new RenoviranjeDTO(Guid.NewGuid().ToString(), izabranZaRenoviranje, DateTime.Parse(PickStartDate.Text), DateTime.Parse(PickEndtDate.Text));
                renoviranjeKontroler.DodajZaRenoviranje(renoviranje);
                renoviranjeKontroler.ProveriRenoviranje();
       
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
