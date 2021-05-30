using Bolnica.Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.UpravnikFolder
{
    /// <summary>
    /// Interaction logic for PremjestanjeStatickeOpreme.xaml
    /// </summary>
    public partial class PremjestanjeStatickeOpreme : System.Windows.Controls.UserControl
    {
        public static ObservableCollection<Prostor> Prostori { get; set; }
        public static ObservableCollection<Oprema> Oprema { get; set; }
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        OpremaKontroler opremaKontroler = new OpremaKontroler();

        public PremjestanjeStatickeOpreme()
        {
            InitializeComponent();
            this.DataContext = this;

            Oprema = new ObservableCollection<Oprema>();
            Prostori = new ObservableCollection<Prostor>();

            foreach (Oprema o in opremaKontroler.SvaOprema())
            {
                if (o.VrstaOpreme == VrsteOpreme.staticka)
                {
                    Oprema.Add(o);
                }
            }

            foreach (Prostor p in prostoriKontroler.SviProstori())
            {
                Prostori.Add(p);
            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Prostor prostor = (Prostor)dataGridProstori.SelectedItem;
            Oprema oprema = (Oprema)dataGridOprema.SelectedItem;
            int kolicina = Int32.Parse(this.kolicina.Text);

            if (DateTime.Today >= DateTime.Parse(DatumPremjestanja.Text))
            {
                opremaKontroler.PremjestiKolicinuOpreme(prostor, oprema, kolicina);
              
            }

            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            System.Windows.Controls.UserControl usc = null;
            usc = new PrikazOpreme();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            System.Windows.Controls.UserControl usc = null;
            usc = new PrikazOpreme();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
