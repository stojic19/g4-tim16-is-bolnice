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
    /// Interaction logic for HitnaOperacijaZakazivanje.xaml
    /// </summary>
    public partial class HitnaOperacijaZakazivanje : UserControl
    {
        HitnaOperacijaKontroler hitnaOperacijaKontroler = new HitnaOperacijaKontroler();
        public static ObservableCollection<PacijentDTO> SviPacijenti { get; set; }
        public HitnaOperacijaZakazivanje()
        {
            InitializeComponent();

            this.DataContext = this;
            PopuniTabeluPacijenata();
        }

        private void PopuniTabeluPacijenata()
        {
            SviPacijenti = new ObservableCollection<PacijentDTO>();

            foreach (PacijentDTO p in hitnaOperacijaKontroler.DobaviSveNaloge())
            {
                SviPacijenti.Add(p);
            }
            this.dataGridPacijenti.ItemsSource = SviPacijenti;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridPacijenti.ItemsSource);
            view.Filter = FiltriranjePacijenata;
        }
        private bool FiltriranjePacijenata(object item)
        {
            if (String.IsNullOrEmpty(poljeZaPretragu.Text))
                return true;
            else
                return ((item as PacijentDTO).Prezime.IndexOf(poljeZaPretragu.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void poljeZaPreraguPacijenata_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridPacijenti.ItemsSource).Refresh();
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
            if(!PodaciPravilnoUneti())
            {
                return;
            }
            int trajanje = Convert.ToInt32(tbTrajanje.Text);
            List<TerminDTO> slobodniTermini = hitnaOperacijaKontroler.HitnaOperacijaSlobodniTermini(DobaviOblastLekara(), trajanje);
            if (slobodniTermini.Count == 0)
            {
                //termini za pomeranje;
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijaPomeranje((PacijentDTO)dataGridPacijenti.SelectedItem, DobaviOblastLekara(), trajanje);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                //zakazivanje prvog slobodnog
                TerminDTO t = slobodniTermini[0];
                t.Pacijent = (PacijentDTO)dataGridPacijenti.SelectedItem;
                hitnaOperacijaKontroler.ZakazivanjeHitneOperacije(t, trajanje);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijePregled();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }

        private bool PodaciPravilnoUneti()
        {
            if (dataGridPacijenti.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite pacijenta!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbTrajanje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti trajanje operacije!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private SpecijalizacijeLekara DobaviOblastLekara()
        {
            SpecijalizacijeLekara oblast;
            switch (cbOblast.SelectedIndex)
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

            return oblast;
        }

        private void TbTrajanje_KeyPress(object sender, KeyPressEventArgs e)
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
