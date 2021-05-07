using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
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
            if (vreme.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti vreme potrebno za pojavu reakcije!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (opis.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti opis reaksije!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Alergeni a = new Alergeni(izabranAlergen, opis.Text, vreme.Text);
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabranPacijent);
            foreach(Alergeni a1 in RukovanjeNalozimaPacijenata.PretraziPoId(izabranPacijent).ZdravstveniKarton.Alergeni)
            {
                if (a1.IdAlergena.Equals(izabranAlergen))
                {
                    a1.OpisReakcije = opis.Text;
                    a1.VremeZaPojavu = vreme.Text;

                    int indeks = AlergeniSekretar.AlergeniPacijenta.IndexOf(a1);
                    AlergeniSekretar.AlergeniPacijenta.RemoveAt(indeks);
                    AlergeniSekretar.AlergeniPacijenta.Insert(indeks, a1);

                    RukovanjeNalozimaPacijenata.Sacuvaj();
                    break;
                }
            }

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(izabranPacijent);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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
    }
}
