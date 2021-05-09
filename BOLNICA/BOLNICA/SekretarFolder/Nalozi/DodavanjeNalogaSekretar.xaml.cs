﻿using Bolnica.Sekretar.Pregled;
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
    public partial class DodavanjeNalogaSekretar : UserControl
    {
        public DodavanjeNalogaSekretar()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VrsteNaloga vrsteNaloga;
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

            if (tipNaloga.Text.Equals("Regularan"))
            {
                vrsteNaloga = VrsteNaloga.regularan;

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
                if (lozinka.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Morate uneti lozinku pacijenta!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(lozinka.Text.Length<8)
                {
                    System.Windows.Forms.MessageBox.Show("Lozinka se mora sastojati od minimum 8 znakova!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
                foreach (Pacijent p1 in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
                {
                    if (p1.KorisnickoIme.Equals(idPacijenta.Text))
                    {
                        System.Windows.Forms.MessageBox.Show("Već postoji uneto korisničko ime!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                vrsteNaloga = VrsteNaloga.gost;
            }

            foreach (Pacijent p1 in RukovanjeNalozimaPacijenata.sviNaloziPacijenata)
            {
                if (p1.Jmbg.Equals(jmbg.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Već postoji uneti jmbg!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Pol polpol;
            if (pol.Text.Equals("Ženski"))
            {
                polpol = Pol.zenski;
            }
            else
            {
                polpol = Pol.muski;
            }
            Pacijent p = new Pacijent(idPacijenta.Text, ime.Text, prezime.Text, this.datum.SelectedDate ?? DateTime.Now, polpol, jmbg.Text, adresa.Text, telefon.Text, email.Text, vrsteNaloga,lozinka.Text);
     
            RukovanjeNalozimaPacijenata.DodajNalog(p);

            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new PrikazNalogaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
