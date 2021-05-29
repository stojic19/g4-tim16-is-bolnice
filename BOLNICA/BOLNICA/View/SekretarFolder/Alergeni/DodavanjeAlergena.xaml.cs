using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.Sekretar.Pregled;
using Bolnica.SekretarFolder;
using Bolnica.SekretarFolder.Operacija;
using Bolnica.ViewModel.PacijentViewModel;
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
    public partial class DodavanjeAlergena : UserControl
    {
        DodavanjeAlergenaViewModel dodavanjeAlergenaViewModel; // 

        public DodavanjeAlergena(String idPacijenta)
        {
            InitializeComponent();
            dodavanjeAlergenaViewModel = new DodavanjeAlergenaViewModel(idPacijenta);
            this.DataContext = dodavanjeAlergenaViewModel;
        }
        /*private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!IspravniUnetiPodaci())
            {
                return;
            }

            alergeniKontroler.DodajAlergen(izabranPacijent, new AlergeniDTO((((Lek)dataGridLekSekretar.SelectedItem).IDLeka), opis.Text, vreme.Text));

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(izabranPacijent);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private bool IspravniUnetiPodaci()
        {
            String idLeka = null;
            if (dataGridLekSekretar.SelectedIndex != -1)
            {
                idLeka = (((Lek)dataGridLekSekretar.SelectedItem).IDLeka);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Izaberite lek!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (AlergeniPrikazDTO ale in alergeniKontroler.DobaviAlergenePoIdPacijenta(izabranPacijent))
            {
                if (ale.IdAlergena.Equals(idLeka))
                {
                    System.Windows.Forms.MessageBox.Show("Izabrani lek već postoji u alergenima!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
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
        }*/
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
