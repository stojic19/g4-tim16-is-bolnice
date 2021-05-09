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

    public partial class IzmenaNalogaSekretar : UserControl
    {
        String izabran = null;

        public IzmenaNalogaSekretar(String id)
        {
            InitializeComponent();

            izabran = id;
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(id);


            if (p.VrstaNaloga == VrsteNaloga.regularan)
            {
                tipNaloga.SelectedIndex = 0;
             }
            else
            {
                tipNaloga.SelectedIndex = 1;
            }
            if (p.Pol == Pol.zenski)
            {
                pol.SelectedIndex = 0;
            }
            else
            {
                pol.SelectedIndex = 1;
            }

            idPacijenta.Text = p.KorisnickoIme;
            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            datum.SelectedDate = p.DatumRodjenja;
            jmbg.Text = p.Jmbg;
            adresa.Text = p.AdresaStanovanja;
            telefon.Text = p.KontaktTelefon;
            email.Text = p.Email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ime.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti ime pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (prezime.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti prezime pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (jmbg.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti jmbg pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            if(p.VrstaNaloga == VrsteNaloga.regularan && tipNaloga.Text.Equals("Gost"))
            {
                System.Windows.Forms.MessageBox.Show("Regularan nalog se ne može promeniti u gostujući!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tipNaloga.SelectedIndex = 0;
                return;
            }
            if (tipNaloga.Text.Equals("Regularan"))
            {

                if (idPacijenta.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Morate uneti korisničko ime pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (adresa.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Morate uneti adresu pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (telefon.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Morate uneti kontakt telefon pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (email.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Morate uneti email pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!p.KorisnickoIme.Equals(idPacijenta.Text))
                {
                    foreach (Pacijent p1 in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
                    {
                        if (p1.KorisnickoIme.Equals(idPacijenta.Text))
                        {
                            System.Windows.Forms.MessageBox.Show("Već postoji uneto korisničko ime!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            if (!p.Jmbg.Equals(jmbg.Text))
            {
                foreach (Pacijent p1 in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
                {
                    if (p1.Jmbg.Equals(jmbg.Text))
                    {
                        System.Windows.Forms.MessageBox.Show("Već postoji uneti jmbg!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            RukovanjeNalozimaPacijenata.IzmeniNalog(izabran,idPacijenta.Text, ime.Text, prezime.Text, this.datum.SelectedDate ?? DateTime.Now, pol.SelectedIndex == 0 ? Pol.zenski : Pol.muski, jmbg.Text, adresa.Text, telefon.Text, email.Text,tipNaloga.SelectedIndex == 0 ? VrsteNaloga.regularan : VrsteNaloga.gost);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
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
