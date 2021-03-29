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

    public partial class ZakazivanjeTerminaLekar : Window
    {

        public ZakazivanjeTerminaLekar()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            String idTermina = RukovanjeTerminima.generisiIDTermina();

            String idLekara = this.idLekara.Text;

            Lekar lekar = RukovanjeTerminima.pretraziLekare(idLekara);
            if (lekar == null)

            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg lekara!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String idPacijenta = this.idPacijenta.Text;

            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);

            if (pacijent == null)
            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            String idProstorije = this.idProstorije.Text;

            VrsteTermina vrstaTermina;
            VrsteProstora vrstaProstorije;

            if (vrTermina.Text.Equals("Operacija"))
            {
                vrstaTermina = VrsteTermina.operacija;
                vrstaProstorije = VrsteProstora.sala;
            }
            else
            {
                vrstaTermina = VrsteTermina.pregled;
                vrstaProstorije = VrsteProstora.ordinacija;
            }

            Prostor prostor = RukovanjeProstorom.PretraziPoId(idProstorije);

            if (prostor == null)
            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            String vremePocetka = pocVreme.Text;

            Double trajanje = double.Parse(this.trajanje.Text);

            String hMin = this.hMin.Text;

            if (hMin == "h")
            {
                trajanje = trajanje * 60;
            }

            Termin t = new Termin(idTermina, vrstaTermina, vremePocetka, trajanje, formatirano, prostor, pacijent, lekar);
            RukovanjeTerminima.ZakaziTermin(t);

            this.Close();

        }

    }
}
