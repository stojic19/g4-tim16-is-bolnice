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
    /// Interaction logic for PotvrdiZakazivanjePacijent.xaml
    /// </summary>
    /// 
    public partial class PotvrdiZakazivanjePacijent : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        TerminKontroler terminKontroler = new TerminKontroler();

        public String idTermina = null;

        public PotvrdiZakazivanjePacijent(Termin izabrani)
        {
            InitializeComponent();
            Termin termin = terminKontroler.PretraziSlobodnePoId(izabrani.IdTermina);

            TextLekar.Text = termin.Lekar.KorisnickoIme;
            TextDatum.Text = termin.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            TextVreme.Text = termin.PocetnoVreme;
            idTermina = termin.IdTermina;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Termin t = terminKontroler.DobaviSlobodanTerminPoId(idTermina);
            t.Pacijent = naloziPacijenataKontroler.PretraziPoId(PacijentGlavniProzor.ulogovani.KorisnickoIme);
            terminKontroler.ZakaziPregled(t);

            UserControl usc = null;
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();

            usc = new PrikazRasporedaPacijent();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();

            usc = new ZakazivanjeSaPrioritetomPacijent();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(usc);
        }
    }
}
