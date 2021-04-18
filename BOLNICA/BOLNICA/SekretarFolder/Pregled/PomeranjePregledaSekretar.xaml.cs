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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica.Sekretar.Pregled
{
    /// <summary>
    /// Interaction logic for PomeranjePregledaSekretar.xaml
    /// </summary>
    public partial class PomeranjePregledaSekretar : Window
    {
        private static Termin termin;
        public PomeranjePregledaSekretar(Termin t)
        {
            InitializeComponent();
            termin = t;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Verifikacije
            if (!datumPocetak.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite početni datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!datumKraj.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite krajnji datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Termin> datumi = new List<Termin>();

            DateTime? datum = this.datumPocetak.SelectedDate;
            DateTime? datum1 = this.datumKraj.SelectedDate;
            DateTime pom = (DateTime)datum;
            DateTime pom1 = (DateTime)datum1;

            List<Termin> pomocna = new List<Termin>();

            bool nasao = false;

            datumi.Clear();

            pomocna = RukovanjeTerminima.PretraziPoLekaruIIntervalu(pom, pom1, termin.Lekar.KorisnickoIme);
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
                        System.Windows.Forms.MessageBox.Show("Nema slobodnih termina za unete podatke!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        PomeranjePregledaTerminiSekretar ppts = new PomeranjePregledaTerminiSekretar(termin, datumi);
                        ppts.Show();
                        this.Close();
                    }
            /*  Verzija sa ogranicenjem +- 3 dana
            List<Termin> termini = RukovanjeTerminima.NadjiDatumeZaPomeranje(termin);
            if(termini.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Nema slobodnih termina za pomeranje!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                PomeranjePregledaTerminiSekretar ppts = new PomeranjePregledaTerminiSekretar(termin, termini);
                ppts.Show();
                this.Close();
            }
            */
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
