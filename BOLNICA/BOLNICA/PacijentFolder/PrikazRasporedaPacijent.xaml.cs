using Bolnica.PacijentFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class PrikazRasporedaPacijent : UserControl
    {
        public static ObservableCollection<Termin> TerminiPacijenta { get; set; }
        public static Termin TerminZaPomeranje = null;
        public PrikazRasporedaPacijent()
        {
            InitializeComponent();
            TerminiPacijenta = new ObservableCollection<Termin>();
            foreach (Termin t in TerminiServis.DobaviSveTermine())
            { 
                if(t.Pacijent.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovani.KorisnickoIme) && DateTime.Compare(DateTime.Now.Date,t.Datum.Date)<=0)
                TerminiPacijenta.Add(t);
            }
            SviTerminiPacijenta.ItemsSource = TerminiPacijenta;
        }

        private void informacije_Click(object sender, RoutedEventArgs e)
        {
            if (SviTerminiPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                return;
            }
            DetaljiTermina prikaz = new DetaljiTermina((Termin)SviTerminiPacijenta.SelectedItem);
            prikaz.Show();
        }

        private void pomeri_Click(object sender, RoutedEventArgs e)
        {
            bool dostupanZaPomeranje=izvrsiValidacijuPrePomeranja();
            if (dostupanZaPomeranje)
            {
                TerminZaPomeranje = (Termin)SviTerminiPacijenta.SelectedItem;
       
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomeranjeSaPrioritetom((Termin)SviTerminiPacijenta.SelectedItem));
            }
            return;
        }

        private void otkazi_Click(object sender, RoutedEventArgs e)
        {
            bool dostupanZaBrisanje=izvrsiValidacijuPreOtkazivanja();
            if (dostupanZaBrisanje)
            {
                OtkazivanjeTerminaPacijent otkazivanje = new OtkazivanjeTerminaPacijent(((Termin)SviTerminiPacijenta.SelectedItem).IdTermina);
                otkazivanje.Show();
            }
            return;

        }
        private bool izvrsiValidacijuPrePomeranja()
        {
            if (SviTerminiPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                return false;
            }
            if (DateTime.Compare(((Termin)SviTerminiPacijenta.SelectedItem).Datum.Date, DateTime.Now.Date) == 0)
            {
                MessageBox.Show("Termin je za manje od 24h ne mozete ga pomeriti!");
                return false;
            }

            if (TerminiServis.ProveriMogucnostPomeranjaDatum(((Termin)SviTerminiPacijenta.SelectedItem).Datum))
            {
                if (!TerminiServis.ProveriMogucnostPomeranjaVreme(TerminiServis.PretraziPoId(((Termin)SviTerminiPacijenta.SelectedItem).IdTermina).PocetnoVreme))
                {
                    MessageBox.Show("Datum pregleda je za manje od 24h! Ne mozete pomeriti!", "Datum pregleda!");
                    return false;
                }
            }
            if (!((Termin)SviTerminiPacijenta.SelectedItem).Lekar.specijalizacija.Equals(SpecijalizacijeLekara.nema))
            {
                MessageBox.Show("Možete pomeriti termin samo kod lekara opšte prakse!");
                return false;
            }
            if (PacijentGlavniProzor.ulogovani.Blokiran)
            {
                MessageBox.Show("Vaš nalog je blokiran! Kontaktirajte sekretara.");
                return false;
            }

            return true;
        }
        private bool izvrsiValidacijuPreOtkazivanja()
        {
            if (SviTerminiPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
                return false;
            }
            if (!((Termin)SviTerminiPacijenta.SelectedItem).Lekar.specijalizacija.Equals(SpecijalizacijeLekara.nema))
            {
                MessageBox.Show("Možete otkazati termin samo kod lekara opšte prakse!");
                return false;
            }
            if (PacijentGlavniProzor.ulogovani.Blokiran)
            {
                MessageBox.Show("Vaš nalog je blokiran! Kontaktirajte sekretara.");
                return false;
            }
            return true;
        }
    }
}
