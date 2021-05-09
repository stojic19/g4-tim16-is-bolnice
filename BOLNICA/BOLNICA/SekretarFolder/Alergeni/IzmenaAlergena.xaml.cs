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
    /// Interaction logic for IzmenaAlergena.xaml
    /// </summary>
    public partial class IzmenaAlergena : UserControl
    {
        private static String izabranPacijent = null;
        private static String izabranAlergen = null;

        public IzmenaAlergena(String idPacijenta,String idAlergena)
        {
            InitializeComponent();
            izabranPacijent = idPacijenta;
            izabranAlergen = idAlergena;
            List<Alergeni> alergeni = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta).ZdravstveniKarton.Alergeni;
            foreach(Alergeni a in alergeni)
            {
                if(a.IdAlergena.Equals(idAlergena))
                {
                    idLeka.Text = a.IdAlergena;
                    opis.Text = a.OpisReakcije;
                    vreme.Text = a.VremeZaPojavu;
                    break;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if(!PoljaPravilnoPopunjena())
            {
                return;
            }    

            RukovanjeNalozimaPacijenata.IzmeniAlergen(izabranPacijent, new Alergeni(izabranAlergen, opis.Text, vreme.Text));

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(izabranPacijent);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private bool PoljaPravilnoPopunjena()
        {
            if (vreme.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti vreme potrebno za pojavu reakcije!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (opis.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti opis reaksije!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(izabranPacijent);
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
    }
}
