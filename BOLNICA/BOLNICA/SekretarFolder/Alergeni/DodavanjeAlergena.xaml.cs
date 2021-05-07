using Bolnica.Model;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
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
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for DodavanjeAlergena.xaml
    /// </summary>
    public partial class DodavanjeAlergena : UserControl
    {
        public static ObservableCollection<Lek> SviLekovi { get; set; }
        private static String izabran = null;

        public DodavanjeAlergena(String idPacijenta)
        {
            InitializeComponent();

            izabran = idPacijenta;
            this.DataContext = this;

            SviLekovi = new ObservableCollection<Lek>();
            SviLekovi.Add(new Lek("L1","Lek 1", "100mg"));
            SviLekovi.Add(new Lek("L2", "Lek 2", "200mg"));
            SviLekovi.Add(new Lek("L3", "Lek 3", "300mg"));
            /*foreach (Lek l in RukovanjeZdravstvenimKartonima.inicijalniLekovi)//Izmeniti kada je u pitanju personalizacija obavestenja
            {
                if()
            }*/
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String idLeka = null;
            if (dataGridLekSekretar.SelectedIndex != -1)
            {
                idLeka = (((Lek)dataGridLekSekretar.SelectedItem).IDLeka);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite lek!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(Alergeni ale in RukovanjeNalozimaPacijenata.PretraziPoId(izabran).ZdravstveniKarton.Alergeni)
            {
                if(ale.IdAlergena.Equals(idLeka))
                {
                    System.Windows.Forms.MessageBox.Show("Izabrani lek već postoji u alergenima!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }
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
            Alergeni a = new Alergeni(idLeka, opis.Text, vreme.Text);
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            p.ZdravstveniKarton.Alergeni.Add(a);
            //p.ZdravstveniKarton.AddAlergeni(a);
            AlergeniSekretar.AlergeniPacijenta.Add(a);
            RukovanjeNalozimaPacijenata.Sacuvaj();

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(izabran);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(izabran);
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
