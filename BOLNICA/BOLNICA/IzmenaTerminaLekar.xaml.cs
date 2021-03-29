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
    public partial class IzmenaTerminaLekar : Window
    {
        String izabran = null;

        public IzmenaTerminaLekar(String id)
        {
            InitializeComponent();

            izabran = id;
            Termin t = RukovanjeTerminima.PretraziPoId(id);


            idLekara.Text = t.Lekar.KorisnickoIme;
            idPacijenta.Text = t.Pacijent.KorisnickoIme;
            if (t.VrstaTermina == VrsteTermina.operacija)
            {
                vrTermina.Text = "Operacija";
            }
            else
            {
                vrTermina.Text = "Pregled";
            }
            idProstorije.Text = t.Prostor.IdProstora;
            datum.SelectedDate = DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            pocVreme.Text = t.PocetnoVreme;
            trajanje.Text = t.Trajanje.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if(RukovanjeTerminima.pretraziLekare(idLekara.Text) == null)
            {
                    System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg lekara!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (RukovanjeProstorom.PretraziPoId(idProstorije.Text) == null)
            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojeći prostor!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }


            RukovanjeTerminima.IzmeniTermin(izabran, idLekara.Text, vrTermina.SelectedIndex, idProstorije.Text, formatirano, pocVreme.Text, trajanje.Text, hMin.SelectedIndex);
            this.Close();
        }
    }
}
