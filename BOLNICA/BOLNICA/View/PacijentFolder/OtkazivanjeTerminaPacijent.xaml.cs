using Bolnica.Kontroler;
using Bolnica.Repozitorijum;
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
        TerminKontroler terminKontroler = new TerminKontroler();
        Termin izabranZaOtkazivanje = null;
        public OtkazivanjeTerminaPacijent(String idTermina)
        {
            InitializeComponent();
            izabranZaOtkazivanje = terminKontroler.PretraziPoId(idTermina);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DateTime.Compare(DateTime.Now.Date, izabranZaOtkazivanje.Datum.Date) == 0)
            {
                MessageBox.Show("Termin je za manje od 24h ne mozete ga otkazati!");
                return;
            }

            terminKontroler.OtkaziPregledPacijent(izabranZaOtkazivanje);
            ProveraNalogaPacijenta();
            this.Close();
        }

        private void ProveraNalogaPacijenta()
        {
            if (PacijentGlavniProzor.ulogovani.Blokiran)
                MessageBox.Show("Ovo je poslednji pomeren termin! Vaš nalog je blokiran.");
        }
    }
}
