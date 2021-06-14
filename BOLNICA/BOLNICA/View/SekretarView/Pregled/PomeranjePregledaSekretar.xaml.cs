using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
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
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.Sekretar.Pregled
{
    public partial class PomeranjePregledaSekretar : UserControl
    {
        ZakazaniTerminiKontroler terminKontroler = new ZakazaniTerminiKontroler();
        private static TerminDTO termin;
        private SlobodniTerminiKontroler slobodniTerminiKontroler = new SlobodniTerminiKontroler();
        public PomeranjePregledaSekretar(TerminDTO t)
        {
            InitializeComponent();
            datumPocetak.DisplayDateStart = DateTime.Today;
            datumKraj.DisplayDateStart = DateTime.Today;
            termin = t;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!PodaciPravilnoUneti())
            {
                return;
            }

            List<TerminDTO> datumi = new List<TerminDTO>();

            DateTime? datum = this.datumPocetak.SelectedDate;
            DateTime? datum1 = this.datumKraj.SelectedDate;
            DateTime pom = (DateTime)datum;
            DateTime pom1 = (DateTime)datum1;

            List<TerminDTO> pomocna = new List<TerminDTO>();

            bool nasao = false;

            datumi.Clear();

            pomocna = slobodniTerminiKontroler.PretraziPoLekaruUIntervalu(NadjiDatumUIntervalu((DateTime)datumPocetak.SelectedDate, (DateTime)datumKraj.SelectedDate), termin.Lekar.KorisnickoIme);
            foreach (TerminDTO t in pomocna)
            {
                nasao = false;
                foreach (TerminDTO t1 in datumi)
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
                        UserControl usc = null;
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                        usc = new PomeranjePregledaTerminiSekretar(termin, datumi);
                        GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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

        private bool PodaciPravilnoUneti()
        {
            if (!datumPocetak.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite početni datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!datumKraj.SelectedDate.HasValue)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite krajnji datum!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public List<Termin> NadjiDatumUIntervalu(DateTime datumOd, DateTime datumDo)
        {
             return slobodniTerminiKontroler.NadjiTermineUIntervaluSekretar(datumOd, datumDo);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        private void Operacija_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Stacionarno_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new StacionarnoLecenjeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TransferPacijenataSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Naplata_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NaplataUslugeSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void LicnaObavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new LicnaObavestenjaSekretar(GlavniProzorSekretar.getInstance().getSekretar().KorisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void MojNalog_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new MojNalogSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
