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
            UkloniDupleDatume(RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumeUIntervalu(), PrikazRasporedaPacijent.TerminZaPomeranje.Lekar.KorisnickoIme));

            if (datumiZaIzmenu.Count == 0)
                NadjiDatumeSaPrioritetom(prioritet.SelectedIndex);
            else
            { 
                PrikazDatumaZaPomeranjeLekar pd = new PrikazDatumaZaPomeranjeLekar();
                PromeniPrikaz(pd);
            }
        }

        public void PromeniPrikaz(UserControl userControl)
        { 
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(userControl);
        }

        private void NadjiDatumeSaPrioritetom(int prioritet)
        {
            if (prioritet == 0)
                NadjiDatumeKodIzabranogLekara();
            else if (prioritet == 1)
                NadjiDatumeKodSvihLekara();
        }

        public static List<Termin> NadjiDatumeUIntervalu()
        {
            DateTime pocetniDatum = PrikazRasporedaPacijent.TerminZaPomeranje.Datum.AddDays(-2);
            DateTime krajnjiDatum = PrikazRasporedaPacijent.TerminZaPomeranje.Datum.AddDays(2);
            return RukovanjeTerminima.NadjiTermineUIntervalu(pocetniDatum,krajnjiDatum);
        }
        private void NadjiDatumeKodIzabranogLekara()
        {
            UkloniDupleDatume(RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumeUIntervalu(), PrikazRasporedaPacijent.TerminZaPomeranje.Lekar.KorisnickoIme));
            PromeniPrikaz(new PrikazDatumaZaPomeranjeLekar());
        }

        private void NadjiDatumeKodSvihLekara()
        {
            UkloniDupleDatume(NadjiDatumeUIntervalu());
            PromeniPrikaz(new PrikazDatumaZaPomeranjePrioritet());
        }

        private void UkloniDupleDatume(List<Termin> dupliTermini)
        {
            foreach (Termin t in dupliTermini.DistinctBy(t => t.Datum))
                datumiZaIzmenu.Add(t);
        }

   

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        public List<Lekar> lekariOpstePrakse { get; set; }

        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();
            foreach (Lekar l in RukovanjeTerminima.sviLekari)
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
