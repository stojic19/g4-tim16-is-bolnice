using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for DodavanjeObavestenja.xaml
    /// </summary>
    public partial class DodavanjeObavestenja : UserControl
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();

        private List<String> primaoci;
        public DodavanjeObavestenja()
        {
            InitializeComponent();

            idObavestenja.Text = new Guid().ToString();
            datum.SelectedDate = DateTime.Now;

            InicijalizujPrimaoca();       
        }

        private void InicijalizujPrimaoca()
        {
            primaoci = new List<string>();

            primaoci.Add("Svi korisnici");
            primaoci.Add("Pacijenti");
            primaoci.Add("Lekari");
            primaoci.Add("Sekretari");
            primaoci.Add("Upravnici");
            foreach (PacijentDTO pacijent in naloziPacijenataKontroler.DobaviSveNaloge())
            {
                primaoci.Add(pacijent.KorisnickoIme + " " + pacijent.Prezime + " " + pacijent.Ime);
            }
            foreach (Lekar lekar in lekariKontroler.DobaviSveLekare())
            {
                primaoci.Add(lekar.KorisnickoIme + " " + lekar.Prezime + " " + lekar.Ime);
            }
            Primalac.ItemsSource = primaoci;
            Primalac.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!PodaciPraviloUneti())
            {
                return;
            }
            obavestenjaKontroler.DodajObavestenje(new Obavestenje(idObavestenja.Text, naslov.Text, tekst.Text, DateTime.Now, DobaviIzabraneKategorije()));

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private string DobaviIzabraneKategorije()
        {
            String kategorije = "";
            foreach(var primalac in Primalac.SelectedItems)
            {
                if (primalac.ToString().Equals("Svi korisnici"))
                {
                    return "svi";
                }
                else if(primalac.ToString().Equals("Pacijenti"))
                {
                    kategorije += " pacijenti";
                }
                else if (primalac.ToString().Equals("Lekari"))
                {
                    kategorije += " lekari";
                }
                else if (primalac.ToString().Equals("Sekretari"))
                {
                    kategorije += " sekretari";
                }
                else if (primalac.ToString().Equals("Upravnici"))
                {
                    kategorije += " upravnici";
                }
                else
                {
                    string[] podaci = primalac.ToString().Split(' ');
                    kategorije += " " + podaci[0];
                }
            }
            return kategorije;
        }

        private bool PodaciPraviloUneti()
        {
            if (naslov.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti naslov obaveštenja!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tekst.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti tekst obaveštenja!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Primalac.SelectedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Morate odabrati bar jednog primaoca!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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
    }
}
