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
    /// <summary>
    /// Interaction logic for ZakazivanjeSaPrioritetomPacijent.xaml
    /// </summary>
    public partial class ZakazivanjeSaPrioritetomPacijent : UserControl
    {
         public static List<Termin> datumi = new List<Termin>();
        public ZakazivanjeSaPrioritetomPacijent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            String idLekara = this.lekar1.Text;
            Lekar lekar = RukovanjeTerminima.pretraziLekare(idLekara);


            DateTime? datum = this.datumod.SelectedDate;
            DateTime? datum1 = this.datumdo.SelectedDate;

            if (lekar1.Text.Equals("") || !datum.HasValue || !datum1.HasValue || PrioritetCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
           // Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++"+datumod);
            //Console.WriteLine("---------------------------"+datumdo);

            DateTime pom = (DateTime)datum;
            DateTime pom1 = (DateTime)datum1;


            

            List<Termin> pomocna = new List<Termin>();

            bool nasao = false;

            datumi.Clear();


            pomocna = RukovanjeTerminima.PretraziPoLekaruIIntervalu(pom, pom1, idLekara);
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
                    DateTime tr1 = pom.AddDays(-7);
                    DateTime tr2 = pom.AddDays(7);

                    pomocna = RukovanjeTerminima.PretraziPoLekaruIIntervalu(tr1, tr2, idLekara);

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
                    pomocna = RukovanjeTerminima.ProveriDatum(pom, pom1);
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


      
    }
}
