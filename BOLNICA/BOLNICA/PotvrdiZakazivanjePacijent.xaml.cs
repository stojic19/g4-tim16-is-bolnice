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
    /// Interaction logic for PotvrdiZakazivanjePacijent.xaml
    /// </summary>
    /// 
    public partial class PotvrdiZakazivanjePacijent : Window
    {
        public String idTermina = null;
        public PotvrdiZakazivanjePacijent(Termin izabrani)
        {
            InitializeComponent();
            Termin termin = RukovanjeTerminima.PretraziSlobodnePoId(izabrani.IdTermina);

            TextLekar.Text = termin.Lekar.KorisnickoIme;
            TextDatum.Text = termin.Datum;
            TextVreme.Text = termin.PocetnoVreme;
            idTermina = termin.IdTermina;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Termin t = RukovanjeTerminima.PretraziSlobodnePoId(idTermina);
          //  t.Pacijent = RukovanjeNalozimaPacijenata.PretraziPoId("leksann");
            RukovanjeTerminima.ZakaziPregled(t);
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            RukovanjeTerminima.SerijalizacijaTermina();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
