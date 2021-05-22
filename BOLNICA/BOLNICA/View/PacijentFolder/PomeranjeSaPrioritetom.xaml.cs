using Bolnica.Kontroler;
using Model;
using MoreLinq;
using PowerfulExtensions.Linq;
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
    public partial class PomeranjeSaPrioritetom : UserControl
    {
        TerminKontroler terminKontroler = new TerminKontroler();
        public static List<Termin> datumiZaIzmenu = new List<Termin>();
        public String idTermina = null;
        public PomeranjeSaPrioritetom(Termin termin)
        {
            InitializeComponent();
            bindcombo();
            PodesavanjePrikaza(termin);
        }

        private void PodesavanjePrikaza(Termin termin)
        {
            lekarCombo.SelectedIndex = konstruisiCombo(termin.Lekar.KorisnickoIme);
            datum.Text = termin.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            vreme.Text = termin.PocetnoVreme;
            idTermina = termin.IdTermina;
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (prioritet.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
            datumiZaIzmenu.Clear();
            List<Termin> terminiUIntervalu = NadjiDatumeUIntervalu();
            List<Termin> terminiKodIzabranog = terminKontroler.PretraziPoLekaruUIntervalu(terminiUIntervalu, PrikazRasporedaPacijent.TerminZaPomeranje.Lekar.KorisnickoIme);

            if (terminiKodIzabranog.Count == 0)
            {
                NadjiTerminePoPrioritetu(terminiUIntervalu, prioritet.SelectedIndex);
            }
            else
            {
                UbaciDostupneDatume(terminiKodIzabranog);
                PromeniPrikaz(new PrikazDatumaZaPomeranjeLekar());
            }
        }
        public void NadjiTerminePoPrioritetu(List<Termin> terminiUIntervalu, int prioritet)
        {
            if (prioritet == 1 && terminiUIntervalu.Count != 0)
            {
                UbaciDostupneDatume(terminiUIntervalu);
            }
            else
            {
                MessageBox.Show("Nema slobodnih termina!");
                return;
            }
            PromeniPrikaz(new PrikazDatumaZaPomeranjePrioritet());
        }

        public void PromeniPrikaz(UserControl userControl)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(userControl);
        }

        public List<Termin> NadjiDatumeUIntervalu()
        {
            DateTime pocetak = PrikazRasporedaPacijent.TerminZaPomeranje.Datum.AddDays(-2);
            DateTime kraj = PrikazRasporedaPacijent.TerminZaPomeranje.Datum.AddDays(2);
            return terminKontroler.NadjiTermineUIntervalu(pocetak, kraj);
        }

        private void UbaciDostupneDatume(List<Termin> datumiZaPomeranje)
        {
            foreach (Termin t in datumiZaPomeranje)
                datumiZaIzmenu.Add(t);

        }


        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            PromeniPrikaz(new PrikazRasporedaPacijent());
        }






        public List<Lekar> lekariOpstePrakse { get; set; }

        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();
            foreach (Lekar l in TerminiServis.sviLekari)
            {
                if (l.specijalizacija.Equals(SpecijalizacijeLekara.nema))
                    pomocna.Add(l);
            }
            lekariOpstePrakse = pomocna;
            lekarCombo.ItemsSource = lekariOpstePrakse;
        }

        public int konstruisiCombo(String id)
        {
            for (int i = 0; i < lekariOpstePrakse.Count; i++)
            {
                if (lekariOpstePrakse[i].KorisnickoIme.Equals(id))
                    return i;
            }
            return 0;

        }
    }
}
