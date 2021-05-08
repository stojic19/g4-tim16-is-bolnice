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
    /// Interaction logic for HitnaOperacijaZakazivanje.xaml
    /// </summary>
    public partial class HitnaOperacijaZakazivanje : UserControl
    {
        public static ObservableCollection<Pacijent> SviPacijenti { get; set; }
        public HitnaOperacijaZakazivanje()
        {
            InitializeComponent();

            this.DataContext = this;
            SviPacijenti = new ObservableCollection<Pacijent>();

            foreach (Pacijent p in RukovanjeNalozimaPacijenata.SviNalozi())
            {
                SviPacijenti.Add(p);
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
            Pacijent pacijent = null;
            if (dataGridPacijenti.SelectedIndex != -1)
            {
                pacijent = (Pacijent)dataGridPacijenti.SelectedItem;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite pacijenta!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int trajanje = Convert.ToInt32(tbTrajanje.Text);
            SpecijalizacijeLekara oblast;
            switch(cbOblast.SelectedIndex)
            {
                case 0:
                    oblast = SpecijalizacijeLekara.neurohirurg;
                    break;
                case 1:
                    oblast = SpecijalizacijeLekara.kardiohirurg;
                    break;
                case 2:
                    oblast = SpecijalizacijeLekara.dermatolog;
                    break;
                default:
                    oblast = SpecijalizacijeLekara.internista;
                    break;
            }
            List<Termin> slobodniTermini = RukovanjeOperacijama.HitnaOperacijaSlobodniTermini(oblast, trajanje);
            if(slobodniTermini.Count==0)
            {
                //termini za pomeranje;
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijaPomeranje(pacijent, oblast, trajanje);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                //zakazivanje prvog slobodnog
                Termin t = slobodniTermini[0];
                t.Pacijent = pacijent;
                RukovanjeOperacijama.ZakazivanjeHitneOperacije(t, trajanje);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijePregled();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }
        private void tbTrajanje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Controls.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new HitnaOperacijaGuestNalog();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
