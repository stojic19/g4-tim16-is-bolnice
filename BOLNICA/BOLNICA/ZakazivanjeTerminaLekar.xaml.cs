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


            String idPacijenta = this.idPacijenta.Text;

            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);
            

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


            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            String vremePocetka = pocVreme.Text;
            String hMin = this.hMin.Text;
            Double trajanje = 0;

            if (!String.IsNullOrEmpty(this.trajanje.Text))
            {
                trajanje = double.Parse(this.trajanje.Text);

                if (hMin == "h")
                {
                    trajanje = trajanje * 60;
                }
            }
           

            if (this.idLekara.Text.Equals("") || this.idPacijenta.Text.Equals("") || this.idProstorije.Text.Equals("") ||
                this.trajanje.Text.Equals("") || !datum.HasValue || pocVreme.SelectedIndex == -1 )
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (lekar == null)

            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg lekara!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (pacijent == null)
            {
                
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (prostor == null)
            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg prostor!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Termin t = new Termin(idTermina, vrstaTermina, vremePocetka, trajanje, formatirano, prostor, pacijent, lekar);
            RukovanjeTerminima.ZakaziTermin(t);

            this.Close();

        }

    }
}
