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
    /// Interaction logic for IzmenaObavestenja.xaml
    /// </summary>
    public partial class IzmenaObavestenja : UserControl
    {
        String izabran = null;
        public IzmenaObavestenja(String id)
        {
            InitializeComponent();

            izabran = id;
            Obavestenje o = RukovanjeObavestenjimaSekratar.PretraziPoId(id);

            idObavestenja.Text = o.IdObavestenja;
            datum.SelectedDate = Convert.ToDateTime(o.Datum);
            naslov.Text = o.Naslov;
            tekst.Text = o.Tekst;

            string[] Kategorije = o.IdPrimaoca.Split(' ');
            foreach(String Kategorija in Kategorije)
            {
                if(Kategorija.Equals("svi"))
                {
                    cbSvi.IsChecked = true;
                }
                if (Kategorija.Equals("pacijenti"))
                {
                    cbPacijenti.IsChecked = true;
                }
                if (Kategorija.Equals("lekari"))
                {
                    cbLekari.IsChecked = true;
                }
                if (Kategorija.Equals("sekretari"))
                {
                    cbSekretari.IsChecked = true;
                }
                if (Kategorija.Equals("upravnici"))
                {
                    cbUpravnici.IsChecked = true;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new ObavestenjaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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
            if (cbSvi.IsChecked == true)
            {
                Obavestenje o = new Obavestenje(idObavestenja.Text, naslov.Text, tekst.Text, DateTime.Now, "svi");
                RukovanjeObavestenjimaSekratar.IzmeniObavestenje(o);
            }
            else
            {
                String kategorije = "";
                if (cbPacijenti.IsChecked == true)
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
                RukovanjeObavestenjimaSekratar.IzmeniObavestenje(o);
                Console.WriteLine(kategorije);
            }

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
