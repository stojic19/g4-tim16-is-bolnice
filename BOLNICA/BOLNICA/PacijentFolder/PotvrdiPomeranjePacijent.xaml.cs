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
    /// <summary>
    /// Interaction logic for PotvrdiPomeranjePacijent.xaml
    /// </summary>
    public partial class PotvrdiPomeranjePacijent : Window
    {
        private Termin noviTermin = null;
        public PotvrdiPomeranjePacijent(Termin izabrani)
        {
            InitializeComponent();
            noviTermin = RukovanjeTerminima.PretraziSlobodnePoId(izabrani.IdTermina);

            TextLekar.Text = noviTermin.Lekar.KorisnickoIme;
            TextDatum.Text = noviTermin.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            TextVreme.Text = noviTermin.PocetnoVreme;
           
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeTerminima.PomeriPregledPacijent(noviTermin.IdTermina);
            RukovanjeTerminima.ZameniTermine(noviTermin);
            RukovanjeTerminima.OsveziPrikazPoslePomeranja(noviTermin);
            this.Close();
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
