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
    public partial class DodavanjeNalogaSekretar : Window
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
            p.ZdravstveniKarton = new ZdravstveniKarton(p.KorisnickoIme); //DODALA JELENA DA BI RADIO RECEPT
            p.ZdravstveniKarton.Recepti = new List<Recept>();
            RukovanjeNalozimaPacijenata.DodajNalog(p);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
