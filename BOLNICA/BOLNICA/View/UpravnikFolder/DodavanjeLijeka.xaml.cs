using Bolnica.DTO;
using Bolnica.Kontroler;
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
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
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

            LekDTO lijek = new LekDTO(Guid.NewGuid().ToString(), this.nazivLijeka.Text, this.jacina.Text, int.Parse(this.kolicinaLijeka.Text), new List<SastojakDTO>(), this.proizvodjac.Text);
            ZahtjevDTO zahtjev = new ZahtjevDTO(Guid.NewGuid().ToString(), lijek, DateTime.Now);

            zahtjeviKontroler.DodajZahtjev(zahtjev);

            this.Close();

        }
    }
}
