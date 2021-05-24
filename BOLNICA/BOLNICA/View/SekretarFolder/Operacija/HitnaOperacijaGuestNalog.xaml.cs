using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Sekretar.Pregled;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica.SekretarFolder.Operacija
{
    /// <summary>
    /// Interaction logic for HitnaOperacijaGuestNalog.xaml
    /// </summary>
    public partial class HitnaOperacijaGuestNalog : UserControl
    {
        HitnaOperacijaKontroler hitnaOperacijaKontroler = new HitnaOperacijaKontroler();
        public HitnaOperacijaGuestNalog()
        {
            InitializeComponent();
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
            if (!PravilniPodaci())
            {
                return;
            }
            Pacijent pacijent = new Pacijent(tbIme.Text, tbPrezime.Text, tbJmbg.Text, DobaviIzabranPol());
            hitnaOperacijaKontroler.DodajGuestNalog(pacijent);
            int trajanje = Convert.ToInt32(tbTrajanje.Text);

            List<Termin> slobodniTermini = OperacijeServis.HitnaOperacijaSlobodniTermini(DobaviOblastLekara(), trajanje);
            if (slobodniTermini.Count == 0)
            {
                //termini za pomeranje;
                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijaPomeranje(pacijent, DobaviOblastLekara(), trajanje);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                //zakazivanje prvog slobodnog
                Termin t = slobodniTermini[0];
                t.Pacijent = pacijent;
                OperacijeServis.ZakazivanjeHitneOperacije(t, trajanje);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new HitnaOperacijePregled();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
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

        private Pol DobaviIzabranPol()
        {
            Pol polpol;
            if (pol.Text.Equals("Ženski"))
            {
                polpol = Pol.zenski;
            }
            else
            {
                polpol = Pol.muski;
            }

            return polpol;
        }

        private bool PravilniPodaci()
        {
            if (tbIme.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti ime pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbPrezime.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti prezime pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbJmbg.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti jmbg pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (Pacijent p1 in hitnaOperacijaKontroler.DobaviSveNaloge())
            {
                if (p1.Jmbg.Equals(tbJmbg.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji uneti jmbg!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
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
    }
}
