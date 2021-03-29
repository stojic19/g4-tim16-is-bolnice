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
    public partial class IzmenaTerminaPacijent : Window
    {

        public String str = null;
        public IzmenaTerminaPacijent(Termin termin)
        {
            InitializeComponent();
            str = termin.IdTermina;
            lekar.Text = termin.Lekar.KorisnickoIme;
            pacijent.Text = termin.Pacijent.KorisnickoIme;
            datum.SelectedDate = DateTime.ParseExact(termin.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            vreme.Text = termin.PocetnoVreme;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;

            if (datum.HasValue)
            {
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (RukovanjeTerminima.pretraziLekare(lekar.Text) == null)
            {
                System.Windows.Forms.MessageBox.Show("Uneli ste nepostojećeg lekara!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RukovanjeTerminima.IzmeniPregled(str, lekar.Text, formatirano, vreme.Text);

            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
