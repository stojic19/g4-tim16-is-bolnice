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
    /// Interaction logic for PremjestanjeOpreme.xaml
    /// </summary>
    public partial class PremjestanjeOpreme : Window
    {
        String idOpreme = null;
        String idProstoraIzKojegPrebacujem = null;

        public static ObservableCollection<Prostor> Prostori { get; set; }

        public PremjestanjeOpreme(string idOpreme, String idProstoraIzKojegPrebacujem)//korisnik unosi informacije
        {
            InitializeComponent();
            this.idOpreme = idOpreme;
            this.idProstoraIzKojegPrebacujem = idProstoraIzKojegPrebacujem;


            this.DataContext = this;

            Prostori = new ObservableCollection<Prostor>();

            foreach (Prostor p in ProstoriServis.SviProstori())
            {
                if (!p.IdProstora.Equals(idProstoraIzKojegPrebacujem))
                {
                    Prostori.Add(p);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Prostor prostorUKojiPremjestamo = (Prostor)dataGridProstori.SelectedItem;
            int kolicina = Int32.Parse(Kolicina.Text);
            Prostor prostorIzKojegPremjestamo = ProstoriServis.PretraziPoId(idProstoraIzKojegPrebacujem);
            Oprema opremaKojuPremjestamo = OpremaServis.PretraziPoId(idOpreme);

            if (prostorUKojiPremjestamo == null)
            {
                System.Windows.MessageBox.Show("Izaberite prostriju u koju želite da prebacite!");
            }

            if (this.Kolicina.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Unesite kolicinu!");
                return;
            }
            else
            {
                OpremaServis.ProvjeriKolicinuKojuPremjestamo(opremaKojuPremjestamo, kolicina);
            }

            // Oprema opremaKojuPremjestamo = RukovanjeProstorom.PretraziOpremuUProstoru(prostorIzKojegPremjestamo, opremaPomocna);
            ProstoriServis.OduzmiKolicinuOpreme(prostorIzKojegPremjestamo, opremaKojuPremjestamo, kolicina);
            ProstoriServis.PremjestiOpremuUDrugiProstor(prostorUKojiPremjestamo, opremaKojuPremjestamo, kolicina);

            ProstoriServis.SerijalizacijaProstora();
            this.Close();
        }
    }
}