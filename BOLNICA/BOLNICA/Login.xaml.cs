using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.Servis;
using Bolnica.View.AdminView;
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
        KorisnikKontroler korisnikKontroler = new KorisnikKontroler();
        List<Upravnik> Upravnici = new List<Upravnik>();

        public Login()
        {
            InitializeComponent();
            Upravnici.Add(new Upravnik("marko111", "Marko", "Anđelić", DateTime.Now, Pol.muski, "1111", "Adresa Adresić 11", "061", "marko@upravnik.com", "marko111"));

            password.PasswordChar = '*';
            password.MaxLength = 14;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ProveraUnosa()) return;
            if (!ProveraPostojanja()) return;
            if (!ProveraLozinke()) return;

            TipoviKorisnika tipKorisnika = korisnikKontroler.ProveriLozinkuITip(username.Text, password.Password);

            Window prozor = LoginFactory.OtvoriProzor(tipKorisnika, username.Text);
            prozor.Show();
            this.Close();
        }

        private Boolean ProveraUnosa()
        {
            if (username.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti korisničko ime!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (password.Password.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti lozinku!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (password.Password.Length < 8 && korisnikKontroler.ProveriLozinkuITip(username.Text, password.Password) != TipoviKorisnika.ADMIN)
            {
                System.Windows.Forms.MessageBox.Show("Uneta lozinka mora biti dugačka bar 8 karaktera!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private Boolean ProveraPostojanja()
        {
            if (!korisnikKontroler.ProveriPostojanje(username.Text))
            {
                System.Windows.Forms.MessageBox.Show("Nepostojeći korisnik!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Text = string.Empty;
                password.Password = string.Empty;
                return false;
            }

            return true;
        }

        private Boolean ProveraLozinke()
        {
            if (korisnikKontroler.ProveriLozinkuITip(username.Text, password.Password) == (TipoviKorisnika)(-1))
            {
                System.Windows.Forms.MessageBox.Show("Pogrešna lozinka!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Password = string.Empty;
                return false;

            }
            return true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GlavniProzorSekretar.getInstance().Close();
        }
    }
}
