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
    /// Interaction logic for OtkazivanjeTerminaPacijent.xaml
    /// </summary>
    public partial class OtkazivanjeTerminaPacijent : Window
    {
        String izabran = null;
        public OtkazivanjeTerminaPacijent(String idTermina)
        {
            izabran = idTermina;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String[] split = DateTime.Now.ToString().Split(' ');




            String[] delovi = split[0].Split('/');



            DateTime konacni = new DateTime(Int32.Parse(delovi[2]), Int32.Parse(delovi[0]), Int32.Parse(delovi[1]), 0, 0, 0);

            Termin t = RukovanjeTerminima.PretraziPoId(izabran);
            DateTime pregled = t.Datum;//DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);





            if (DateTime.Compare(konacni, pregled) == 0)
            {
                MessageBox.Show("Termin je za manje od 24h ne mozete ga otkazati!");
                return;
            }

            RukovanjeTerminima.OtkaziPregledPacijent(izabran);
            RukovanjeTerminima.ProveraNalogaPacijenta(PacijentGlavniProzor.ulogovani);
            ObavestiPacijenta();
            
            this.Close();
        }

        private void ObavestiPacijenta()
        {
            if (PacijentGlavniProzor.ulogovani.Blokiran)
                MessageBox.Show("Ovo je poslednji pomeren termin! Vaš nalog je blokiran.");
        }
    }
}
