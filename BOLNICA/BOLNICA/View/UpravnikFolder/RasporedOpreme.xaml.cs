using Bolnica.DTO;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for RasporedOpreme.xaml
    /// </summary>
    public partial class RasporedOpreme : UserControl
    {


        public static ObservableCollection<OpremaDTO> Oprema { get; set; }
        public static string IdProstorije { get; set; }
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();

        public RasporedOpreme(String idProstorije)
        {
            InitializeComponent();
            this.DataContext = this;
            Oprema = new ObservableCollection<OpremaDTO>();
            foreach(OpremaDTO o in prostoriKontroler.PretraziProstorPoId(idProstorije).Oprema){
                Oprema.Add(o);
            }
            
            dataGridRasporedOpreme.ItemsSource = Oprema;
            IdProstorije = idProstorije;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)

        {

            DodajOpremuProstoru dodavanje = new DodajOpremuProstoru(IdProstorije);
            dodavanje.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Oprema izabranZaPrebacivanje = (Oprema)dataGridRasporedOpreme.SelectedItem;

            if (izabranZaPrebacivanje != null)
            {
                PremjestanjeOpreme premjestanje = new PremjestanjeOpreme(izabranZaPrebacivanje.IdOpreme, IdProstorije);
                premjestanje.Show();
            }
            else
            {
                MessageBox.Show("Izaberite opremu koji želite da prebacite!");
            }


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)

        {

            UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();
            UserControl usc = null;
            usc = new PrikazProstora();
            UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
        }
    }
}