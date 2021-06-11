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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.SekretarFolder.Operacija
{
    /// <summary>
    /// Interaction logic for HitnaOperacijePregled.xaml
    /// </summary>
    public partial class HitnaOperacijePregled : UserControl
    {
        HitnaOperacijaKontroler hitnaOperacijaKontroler = new HitnaOperacijaKontroler();
        public ObservableCollection<TerminDTO> TerminiHitnihOperacija { get; set; }
        public HitnaOperacijePregled()
        {
            InitializeComponent();
            //Prikaz hitnih operacija u narednom periodu
            this.DataContext = this;
            
            PopuniTabeluTermina();
        }

        private void PopuniTabeluTermina()
        {
            TerminiHitnihOperacija = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO t in hitnaOperacijaKontroler.DobaviSveOperacije())
            {
                TerminiHitnihOperacija.Add(t);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Zakazivanje
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijaZakazivanje();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Otkazivanje
            if (dataGridTerminiPregleda.SelectedIndex != -1)
            {
                TerminDTO t = (TerminDTO)dataGridTerminiPregleda.SelectedItem;

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijaOtkazivanje(t);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
                MessageBox.Show("Izaberite termin za otkazivanje!");
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
