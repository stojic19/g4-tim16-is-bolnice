using Bolnica.Model;
using Bolnica.Sekretar.Pregled;
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
        public static ObservableCollection<KeyValuePair<Termin, int>> TerminiZaPomeranje { get; set; }
        private static Pacijent p;
        private static int Trajanje;
        public HitnaOperacijaPomeranje(Pacijent pacijent,SpecijalizacijeLekara oblast,int trajanje)
        {
            InitializeComponent();
            p = pacijent;
            Trajanje = trajanje;
            this.DataContext = this;
            TerminiZaPomeranje = new ObservableCollection<KeyValuePair<Termin, int>>();

            foreach (KeyValuePair<Termin, int> t in RukovanjeOperacijama.HitnaOperacijaTerminiZaPomeranje(oblast,trajanje).OrderBy(key => key.Value))
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

            KeyValuePair<Termin, int> termin = (KeyValuePair<Termin, int>)terminiZaPomeranjeLista.SelectedItem;
            if (!RukovanjeOperacijama.PomeriOperacijuIZakaziNovu(termin.Key,termin.Value,p,Trajanje))
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
    }
}
