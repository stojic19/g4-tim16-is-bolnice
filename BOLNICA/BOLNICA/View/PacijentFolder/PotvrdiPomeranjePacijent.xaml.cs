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
    public partial class PotvrdiPomeranjePacijent : UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        private Termin noviTermin = null;
        public PotvrdiPomeranjePacijent(Termin izabrani)
        {
            InitializeComponent();
            noviTermin = terminKontroler.DobaviSlobodanTerminPoId(izabrani.IdTermina);

            TextLekar.Text = noviTermin.Lekar.KorisnickoIme;
            TextDatum.Text = noviTermin.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            TextVreme.Text = noviTermin.PocetnoVreme;
           
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
           // terminKontroler.PomeriPregledPacijent(noviTermin);
            ProveriNalogPacijenta();
            PromeniPrikaz(new PrikazRasporedaPacijent());
        }

        private void ProveriNalogPacijenta()
        {
            if (PacijentGlavniProzor.ulogovani.Blokiran)
                MessageBox.Show("Ovo je poslednji pomeren termin! Vaš nalog je blokiran.");
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazRasporedaPacijent());
        }

        public void PromeniPrikaz(UserControl userControl)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(userControl);
        }
    }
}
