using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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
    /// Interaction logic for DodavanjeLijeka.xaml
    /// </summary>
    public partial class DodavanjeLijeka : Window
    {
        public DodavanjeLijeka()
        {
            InitializeComponent();

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            String idLijeka = Guid.NewGuid().ToString();
            String nazivLeka = this.nazivLijeka.Text;
            String jacina = this.jacina.Text;
            int kolicina = int.Parse(this.kolicinaLijeka.Text);
            String proizvodjac = this.proizvodjac.Text;


            Lek lijek = new Lek(idLijeka, nazivLeka, jacina, kolicina, proizvodjac, new List<Sastojak>(), false);


            RukovanjeNeodobrenimLijekovima.DodajLijek(lijek);
            String idZahtjeva = Guid.NewGuid().ToString();

            
            Zahtjev zahtjev = new Zahtjev(idZahtjeva, lijek, null, DateTime.Today);
            RukovanjeZahtjevima.DodajZahtjev(zahtjev);
            RukovanjeZahtjevima.SerijalizacijaZahtjeva();

            this.Close();

        }
    }
}
