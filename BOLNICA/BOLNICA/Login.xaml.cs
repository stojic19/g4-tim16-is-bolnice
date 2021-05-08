using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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

namespace Bolnica
{
    public partial class Login : Window
    {
        List<Upravnik> Upravnici = new List<Upravnik>();
        //List<Sekretar> Sekretari = new List<Sekretar>();
        List<Osoba> Sekretari = new List<Osoba>();
        //List<Lekar> Lekari = new List<Lekar>();
        List<Pacijent> Pacijenti = new List<Pacijent>();

        public Login()
        {
            InitializeComponent();

            Upravnici.Add(new Upravnik("marko111", "Marko", "Anđelić", DateTime.Now, Pol.muski, "1111", "Adresa Adresić 11", "061", "marko@upravnik.com", "marko111"));
            Sekretari.Add(new Osoba("aleksa222", "Aleksa", "Stojić", DateTime.Now, Pol.muski, "2222", "Adresa Adresić 22", "062", "aleksa@sekretar.com", "aleksa222"));
            //RukovanjeTerminima.sviLekari.Add(new Lekar("jelena333", "Jelena", "Hrnjak", DateTime.Now, Pol.zenski, "3333", "Adresa Adresić 33", "063", "jelena@lekar.com", "jelena3333"));

            if (RukovanjeTerminima.brojac == 0)
            {
                RukovanjeTerminima.PrivremenaInicijalizacijaLekara();
            }

            RukovanjeTerminima.brojac++;

            RukovanjeOdobrenimLekovima.DeserijalizacijaLekova();
            RukovanjeTerminima.DeserijalizacijaTermina();
            RukovanjeTerminima.DeserijalizacijaSlobodnihTermina();
            RukovanjePregledima.DeserijalizacijaPregleda();
            RukovanjeProstorom.DeserijalizacijaProstora();
            RukovanjeNalozimaPacijenata.Ucitaj();
            RukovanjeObavestenjimaSekratar.Ucitaj();
              //RukovanjeTerminima.InicijalizacijaSTermina();
            RukovanjeZdravstvenimKartonima.InicijalizacijaLekova();
            Pacijenti = RukovanjeNalozimaPacijenata.SviNalozi();

            RukovanjeOperacijama.PrivremenaInicijalizacijaLekara();
            RukovanjeAnketama.inicijalizujPitanjaOBolnici();
            RukovanjeAnketama.inicijalizujPitanjaOTerminu();
            RukovanjeAnketama.DeserijalizacijaAnketa();
            
            password.PasswordChar = '*';
            password.MaxLength = 14;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool founded = false;
            if (username.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti korisničko ime!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password.Password.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti lozinku!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password.Password.Length < 8)
            {
                System.Windows.Forms.MessageBox.Show("Uneta lozinka mora biti dugačka bar 8 karaktera!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Upravnik u in Upravnici)
            {
                if (u.KorisnickoIme.Equals(username.Text))
                {
                    if (u.Lozinka.Equals(password.Password))
                    {
                        UpravnikGlavniProzor ugp = UpravnikGlavniProzor.getInstance();
                        ugp.Show();
                        this.Close();
                        founded = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (Osoba s in Sekretari)
            {
                if (s.KorisnickoIme.Equals(username.Text))
                {
                    if (s.Lozinka.Equals(password.Password))
                    {
                        GlavniProzorSekretar gps = GlavniProzorSekretar.getInstance();
                        gps.Show();
                        this.Close();
                        founded = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (Lekar l in RukovanjeTerminima.sviLekari)
            {
                if (l.KorisnickoIme.Equals(username.Text))
                {
                    if (l.Lozinka.Equals(password.Password))
                    {
                        LekarGlavniProzor glavniProzorLekara = new LekarGlavniProzor(username.Text);
                        glavniProzorLekara.Show();
                        this.Close();
                        founded = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (Pacijent p in Pacijenti)
            {
                if (p.KorisnickoIme.Equals(username.Text))
                {
                    if (p.Lozinka.Equals(password.Password))
                    {
                        if (p.Blokiran)
                        {
                            System.Windows.MessageBox.Show("Vaš nalog je blokiran! Kontaktirajte sekretara!");
                            return;

                        }
                        PacijentGlavniProzor pgp = new PacijentGlavniProzor(p.KorisnickoIme);
                        pgp.Show();
                        this.Close();
                        founded = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (!founded)
                System.Windows.Forms.MessageBox.Show("Nepostojeći korisnik!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjePregledima.SerijalizacijaPregleda();
            RukovanjeTerminima.SerijalizacijaSlobodnihTermina();
            RukovanjeProstorom.SerijalizacijaProstora();
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjeAnketama.SerijalizacijaAnketa();
            GlavniProzorSekretar.getInstance().Close();
        }
    }
}
