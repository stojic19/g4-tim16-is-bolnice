using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
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
        List<Upravnik> Upravnici = new List<Upravnik>();
        List<SekretarDTO> Sekretari = new List<SekretarDTO>();
        List<PacijentDTO> Pacijenti = new List<PacijentDTO>();
        List<LekarDTO> Lekari = new List<LekarDTO>();
      
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        SekretarKontroler sekretarKontroler = new SekretarKontroler();

        public Login()
        {
            InitializeComponent();

            Upravnici.Add(new Upravnik("marko111", "Marko", "Anđelić", DateTime.Now, Pol.muski, "1111", "Adresa Adresić 11", "061", "marko@upravnik.com", "marko111"));

            Pacijenti = naloziPacijenataKontroler.DobaviSveNaloge();
            Lekari = lekariKontroler.DobaviSveLekareLogin();
            Sekretari = sekretarKontroler.DobaviSve();
            
            password.PasswordChar = '*';
            password.MaxLength = 14;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool founded = false;
            if (username.Text.Equals("admin") && password.Password.Equals("admin"))
            {
                GlavniProzorAdmin gpa = GlavniProzorAdmin.getInstance();
                gpa.Show();
                this.Close();
                founded = true;
                return;
            }
            else
            {
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
                        System.Windows.Forms.MessageBox.Show("Neispravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (SekretarDTO s in Sekretari)
            {
                if (s.KorisnickoIme.Equals(username.Text))
                {
                    if (s.Lozinka.Equals(password.Password))
                    {
                        GlavniProzorSekretar gps = GlavniProzorSekretar.getInstance(s);
                        gps.Show();
                        this.Close();
                        founded = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neispravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (LekarDTO l in Lekari)
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
                        System.Windows.Forms.MessageBox.Show("Neispravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (PacijentDTO p in Pacijenti)
            {
                if (p.KorisnickoIme.Equals(username.Text))
                {
                    if (p.Lozinka.Equals(password.Password))
                    {
                        if (!naloziPacijenataKontroler.ProveraNalogaPacijenta(p.KorisnickoIme))
                            return;
                        PacijentGlavniProzor pgp = new PacijentGlavniProzor(p.KorisnickoIme);
                        pgp.Show();
                        this.Close();
                        founded = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neispravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            GlavniProzorSekretar.getInstance().Close();
        }
    }
}
