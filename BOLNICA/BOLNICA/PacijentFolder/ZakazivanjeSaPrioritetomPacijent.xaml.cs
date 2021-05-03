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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class ZakazivanjeSaPrioritetomPacijent : UserControl
    {
         public static List<Termin> datumi = new List<Termin>();
        public ZakazivanjeSaPrioritetomPacijent()
        {
            InitializeComponent();
            bindcombo();
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
           
            Lekar lekar = RukovanjeTerminima.pretraziLekare(((Lekar)lekarCombo.SelectedItem).KorisnickoIme);

            if (lekarCombo.SelectedIndex==-1 || !this.datumod.SelectedDate.HasValue || !this.datumdo.SelectedDate.HasValue || PrioritetCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            if (PacijentGlavniProzor.ulogovani.Blokiran)
            {
                MessageBox.Show("Vaš nalog je blokiran! Kontaktirajte sekretara.");
                return;
            }

            if (DateTime.Compare(((DateTime)datumod.SelectedDate).Date, DateTime.Now.Date) <= 0){
                MessageBox.Show("Ne možete izabrati datum u prošlosti!");
                return;
            }

            if (DateTime.Compare(((DateTime)datumdo.SelectedDate).Date,((DateTime)datumod.SelectedDate).Date) <= 0)
            {
                MessageBox.Show("Početni datum mora biti raniji od krajnjeg!");
                return;
            }


            List<Termin> pomocna = new List<Termin>();

            bool nasao = false;

            datumi.Clear();


            pomocna = RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumod.SelectedDate, (DateTime)datumdo.SelectedDate), lekar.KorisnickoIme);
            foreach (Termin t in pomocna)
            {
                nasao = false;
                foreach (Termin t1 in datumi)
                {
                    if (t1.Datum.Equals(t.Datum))
                    {
                        nasao = true;
                        break;
                    }
                }
                if (!nasao)
                {
                    datumi.Add(t);
                }

            }

            if (datumi.Count == 0)
            {
                if (PrioritetCombo.SelectedIndex == 0)
                {
                    DateTime tr1 = ((DateTime)datumod.SelectedDate).AddDays(-7);
                    DateTime tr2 = ((DateTime)datumdo.SelectedDate).AddDays(7);

                    pomocna = RukovanjeTerminima.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumod.SelectedDate, (DateTime)datumdo.SelectedDate), lekar.KorisnickoIme);

                    foreach (Termin t in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in datumi)
                        {
                            if (t1.Datum.Equals(t.Datum))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumi.Add(t);
                        }

                    }

                    if (datumi.Count == 0)
                    {
                        MessageBox.Show("Nema slobodnih datuma!");
                        return;
                    }
                    PrikazDatumaPacijentKodIzabranog pd = new PrikazDatumaPacijentKodIzabranog();
                    pd.Show();

                }
                else if (PrioritetCombo.SelectedIndex == 1)
                {
                    pomocna = RukovanjeTerminima.NadjiTermineUIntervalu((DateTime)datumod.SelectedDate, (DateTime)datumdo.SelectedDate);
                    foreach (Termin t in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in datumi)
                        {
                            if (t1.Datum.Equals(t.Datum) && t1.Lekar.KorisnickoIme.Equals(t.Lekar.KorisnickoIme))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            datumi.Add(t);
                        }

                    }

                    if (datumi.Count == 0)
                    {
                        MessageBox.Show("Nema slobodnih datuma!");
                        return;
                    }
                    
                    PrikazSlobodnihDatumaPacijent pd = new PrikazSlobodnihDatumaPacijent();
                    pd.Show();

                   

                }

            }
            else
            {


                PrikazDatumaPacijentKodIzabranog pd = new PrikazDatumaPacijentKodIzabranog();
                pd.Show();

            }

            
            
        }

        public List<Termin> NadjiDatumUIntervalu(DateTime datumOd,DateTime datumDo)
        {
            return RukovanjeTerminima.NadjiTermineUIntervalu(datumOd,datumDo);
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

    }
}
