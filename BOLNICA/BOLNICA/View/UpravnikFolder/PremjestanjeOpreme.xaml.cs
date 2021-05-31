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
        ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        OpremaKontroler opremaKontroler = new OpremaKontroler();

        public static ObservableCollection<ProstorDTO> Prostori { get; set; }

        public PremjestanjeOpreme(string idOpreme, String idProstoraIzKojegPrebacujem)//korisnik unosi informacije
        {
            InitializeComponent();
            this.idOpreme = idOpreme;
            this.idProstoraIzKojegPrebacujem = idProstoraIzKojegPrebacujem;


            this.DataContext = this;

            Prostori = new ObservableCollection<ProstorDTO>();

            foreach (ProstorDTO p in prostoriKontroler.SviProstori())
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
            ProstorDTO prostorUKojiPremjestamo = (ProstorDTO)dataGridProstori.SelectedItem;
            int kolicina = Int32.Parse(Kolicina.Text);
            ProstorDTO prostorIzKojegPremjestamo = prostoriKontroler.PretraziProstorPoId(idProstoraIzKojegPrebacujem);
            OpremaDTO opremaKojuPremjestamo = opremaKontroler.PretraziPoId(idOpreme);

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
                opremaKontroler.ProvjeriKolicinuKojuPremjestamo(opremaKojuPremjestamo, kolicina);
            }

            // Oprema opremaKojuPremjestamo = RukovanjeProstorom.PretraziOpremuUProstoru(prostorIzKojegPremjestamo, opremaPomocna);
            prostoriKontroler.OduzmiKolicinuOpreme(prostorIzKojegPremjestamo, opremaKojuPremjestamo, kolicina);
            prostoriKontroler.PremjestiOpremu(prostorUKojiPremjestamo, opremaKojuPremjestamo, kolicina);

  
            this.Close();
        }
    }
}