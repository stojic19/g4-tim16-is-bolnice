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
    /// Interaction logic for DodavanjeObavestenja.xaml
    /// </summary>
    public partial class DodavanjeObavestenja : UserControl
    {

        public DodavanjeObavestenja()
        {
            InitializeComponent();

            idObavestenja.Text = generisiIdObavestenja();
            datum.SelectedDate = DateTime.Now;
        }
        public static String generisiIdObavestenja()
        {
            int brojac = RukovanjeObavestenjimaSekratar.SvaObavestenja().Count;
            bool postoji;
            do
            {
                postoji = false;
                foreach (Obavestenje o in RukovanjeObavestenjimaSekratar.SvaObavestenja())
                {
                    if (o.IdObavestenja.Equals("O" + brojac.ToString()))
                    {
                        postoji = true;
                        brojac++;
                        break;
                    }
                }
            } while (postoji);

            return "O" + brojac.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (naslov.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti naslov obaveštenja!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tekst.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti tekst obaveštenja!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbSvi.IsChecked==false && cbPacijenti.IsChecked == false && cbLekari.IsChecked == false && cbSekretari.IsChecked == false && cbUpravnici.IsChecked == false)
            {
                System.Windows.Forms.MessageBox.Show("Morate odabrati bar jednu kategoriju!", "Proverite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbSvi.IsChecked == true)
            {
                Obavestenje o = new Obavestenje(idObavestenja.Text, naslov.Text, tekst.Text, DateTime.Now, "svi");
                RukovanjeObavestenjimaSekratar.DodajObavestenje(o);
            }
            else
            {
                String kategorije = "";
                if(cbPacijenti.IsChecked == true)
                {
                    kategorije += " pacijenti";
                }
                if (cbLekari.IsChecked == true)
                {
                    kategorije += " lekari";
                }
                if (cbSekretari.IsChecked == true)
                {
                    kategorije += " sekretari";
                }
                if (cbUpravnici.IsChecked == true)
                {
                    kategorije += " upravnici";
                }
                Obavestenje o = new Obavestenje(idObavestenja.Text, naslov.Text, tekst.Text, DateTime.Now, kategorije);
                RukovanjeObavestenjimaSekratar.DodajObavestenje(o);
            }

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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
    }
}
