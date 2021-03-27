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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    
    public partial class ZakazivanjeTerminaLekar : Window
    {

        public static int brojTermina = 0;
        
        public ZakazivanjeTerminaLekar()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int GenerisanjeIdTermina()
        {

            return brojTermina++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            String idTermina = "L" + GenerisanjeIdTermina().ToString();

            String idLekara = this.idLekara.Text;
            Lekar lekar = new Lekar(idLekara);
            String idPacijenta = this.idPacijenta.Text;
            Pacijent pacijent = new Pacijent(idPacijenta);
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

            Prostor prostor = new Prostor(idProstorije, vrstaProstorije);

            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            String vremePocetka = pocVreme.Text;

            Double trajanje = double.Parse(this.trajanje.Text);

            String hMin = this.hMin.Text;

            if(hMin == "h")
            {
                trajanje = trajanje * 60;
            }

            Termin t = new Termin(idTermina, vrstaTermina, vremePocetka, trajanje, formatirano, prostor, pacijent, lekar);
            RukovanjeTerminima.ZakaziTermin(t);

            this.Close();

        }

    }
}
