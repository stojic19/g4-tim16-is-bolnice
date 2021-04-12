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
    /// Interaction logic for PomeranjeTerminaPacijent.xaml
    /// </summary>
    public partial class PomeranjeTerminaPacijent : Window
    {
        public PomeranjeTerminaPacijent()
        {
            InitializeComponent();
        }

        public String idTermina = null;
        public PomeranjeTerminaPacijent(Termin izabraniTermin)
        {
            InitializeComponent();

            Termin termin = RukovanjeTerminima.PretraziPoId(izabraniTermin.IdTermina);
            //DateTime datum = DateTime.ParseExact(TextDatum.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);




            TextLekar.Text = termin.Lekar.KorisnickoIme;
            TextDatum.Text = termin.Datum;
            TextVreme.Text = termin.PocetnoVreme;
            idTermina = termin.IdTermina;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string datum = TextDatum.Text;
            bool dostupanDatum = RukovanjeTerminima.ProveriMogucnostPomeranjaDatum(datum);


            if (dostupanDatum)
            {
                bool dostupnoVreme = RukovanjeTerminima.ProveriMogucnostPomeranjaVreme(RukovanjeTerminima.PretraziPoId(idTermina).PocetnoVreme);
               // Console.WriteLine("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOL" + dostupnoVreme);
                if (!dostupnoVreme)
                {
                    MessageBox.Show("Datum pregleda je za manje od 24h! Ne mozete pomeriti!", "Datum pregleda!");
                    return;
                }
            }
            PrikaziDatumeZaPomeranjePacijent pr = new PrikaziDatumeZaPomeranjePacijent(RukovanjeTerminima.PretraziPoId(idTermina));
            pr.Show();
            this.Close();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
