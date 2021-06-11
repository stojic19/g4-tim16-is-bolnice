using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder.Operacija;
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

namespace Bolnica.SekretarFolder
{
    /// <summary>
    /// Interaction logic for PrikazPregledaSekretar.xaml
    /// </summary>
    public partial class PrikazRasporedaLekaraSekretar : UserControl
    {
        OdsustvoKontroler odsustvoKontroler;
        RadniDanLekaraKontroler radniDanLekaraKontroler;

        public static ObservableCollection<RadniDanDTO> RadniDani { get; set; }

        public static ObservableCollection<OdsustvoDTO> Odsustva { get; set; }

        private string idIzabranogLekara;
        public PrikazRasporedaLekaraSekretar(String idLekara)
        {
            radniDanLekaraKontroler = new RadniDanLekaraKontroler(idLekara);
            odsustvoKontroler = new OdsustvoKontroler(idLekara);
            InitializeComponent();

            idIzabranogLekara = idLekara;
            
            this.DataContext = this;

            RadniDani = new ObservableCollection<RadniDanDTO>();
            Odsustva = new ObservableCollection<OdsustvoDTO>();

            foreach(RadniDanDTO radniDan in radniDanLekaraKontroler.DobaviRadneDane())
            {
                RadniDani.Add(radniDan);
            }
            foreach(OdsustvoDTO odsustvo in odsustvoKontroler.DobaviOdsustvo())
            {
                Odsustva.Add(odsustvo);
            }
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
        private void Operacije_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijePregled();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Dodaj radne dane
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeRadnihDanaSekretar(idIzabranogLekara);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //Promeni smenu
            if (dataGridRadniDani.SelectedIndex != -1)
            {
                RadniDanDTO radniDanZaPromenuSmene = ((RadniDanDTO)dataGridRadniDani.SelectedItem);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new PromenaSmeneSekretar(idIzabranogLekara, radniDanZaPromenuSmene);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite radni dan za promenu smene!");
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //Ukloni radni dan
            if (dataGridRadniDani.SelectedIndex != -1)
            {
                RadniDanDTO radniDanZaUklanjanje = ((RadniDanDTO)dataGridRadniDani.SelectedItem);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeRadnogDanaSekretar(idIzabranogLekara, radniDanZaUklanjanje);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite radni dan za uklanjanje!");
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //Dodaj slobodne dane
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new DodavanjeSlobodnihDanaSekretar(idIzabranogLekara);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            //Ukloni slobodne dane
            if (dataGridOdsustva.SelectedIndex != -1)
            {
                OdsustvoDTO odsustvoZaUklanjanje = ((OdsustvoDTO)dataGridOdsustva.SelectedItem);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeSlobodnogDanaSekretar(idIzabranogLekara, odsustvoZaUklanjanje);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite slobodne dane za uklanjanje!");
            }
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            //Ažuriranje trajanja odmora
            if (dataGridOdsustva.SelectedIndex != -1)
            {
                OdsustvoDTO odsustvoZaIzmenu = ((OdsustvoDTO)dataGridOdsustva.SelectedItem);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new PromenaTrajanjaOdmora(idIzabranogLekara, odsustvoZaIzmenu);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Izaberite slobodne dane za ažuriranje!");
            }    
        }

        private void Povratak_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazLekaraSekretar();
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

            usc = new View.SekretarFolder.LicnaObavestenja.LicnaObavestenjaSekretar(GlavniProzorSekretar.getInstance().getSekretar().KorisnickoIme);
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
