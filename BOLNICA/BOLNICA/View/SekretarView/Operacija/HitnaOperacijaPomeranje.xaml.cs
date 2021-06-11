using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Sekretar.Pregled;
using Bolnica.View.SekretarFolder.LicnaObavestenja;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.SekretarFolder.Operacija
{
    /// <summary>
    /// Interaction logic for HitnaOperacijaPomeranje.xaml
    /// </summary>
    public partial class HitnaOperacijaPomeranje : UserControl
    {
        HitnaOperacijaKontroler hitnaOperacijaKontroler = new HitnaOperacijaKontroler();
        public static ObservableCollection<KeyValuePair<TerminDTO, int>> TerminiZaPomeranje { get; set; }
        private static PacijentDTO pacijent;
        private static int TrajanjeOperacije;
        public HitnaOperacijaPomeranje(PacijentDTO pacijentIzabrani,SpecijalizacijeLekara oblast,int trajanjeOperacije)
        {
            InitializeComponent();
            pacijent = pacijentIzabrani;
            TrajanjeOperacije = trajanjeOperacije;
            this.DataContext = this;

            PopuniListuTerminimaZaPomeranje(oblast);
        }

        private void PopuniListuTerminimaZaPomeranje(SpecijalizacijeLekara oblast)
        {
            TerminiZaPomeranje = new ObservableCollection<KeyValuePair<TerminDTO, int>>();

            foreach (KeyValuePair<TerminDTO, int> t in hitnaOperacijaKontroler.HitnaOperacijaTerminiZaPomeranje(oblast, TrajanjeOperacije).OrderBy(key => key.Value))
            {
                TerminiZaPomeranje.Add(t);
            }
            terminiZaPomeranjeLista.ItemsSource = TerminiZaPomeranje;
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Termini_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Nalozi_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Odustani
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Potvrdi
            if(!OdabranTermin())
            {
                return;
            }
            KeyValuePair<TerminDTO, int> termin = (KeyValuePair<TerminDTO, int>)terminiZaPomeranjeLista.SelectedItem;
            termin.Key.Pacijent = pacijent;
            termin.Key.TrajanjeDouble = TrajanjeOperacije;
            if (!hitnaOperacijaKontroler.PomeriOperacijuIZakaziNovu(termin))
            {
                System.Windows.Forms.MessageBox.Show("Neuspešno pomeranje!", "Odaberite drugi termin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Nakon pomeranja
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private bool OdabranTermin()
        {
            return terminiZaPomeranjeLista.SelectedItem != null;
        }
        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
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
