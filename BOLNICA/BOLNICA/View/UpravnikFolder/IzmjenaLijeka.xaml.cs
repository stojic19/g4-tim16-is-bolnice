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
    public partial class IzmjenaLijeka : Window
    {
        String stari = null;
        ZahtjeviKontroler zahtjeviKontroler = new ZahtjeviKontroler();
        public IzmjenaLijeka(String id)
        {
            InitializeComponent();

            stari = id;
            LekDTO lijek = zahtjeviKontroler.pretraziLekPoId(id);

            NazivLijeka.Text = lijek.NazivLeka;
            Jacina.Text = lijek.Jacina;
            Kolicina.Text = lijek.Kolicina.ToString();
            Proizvodjac.Text = lijek.Proizvodjac;

        }
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {

            LekDTO lijek = new LekDTO(stari, NazivLijeka.Text, Jacina.Text, int.Parse(Kolicina.Text), new List<SastojakDTO>(), Proizvodjac.Text);

            zahtjeviKontroler.IzmeniLek(lijek);

            this.Close();
        }
    }
}
