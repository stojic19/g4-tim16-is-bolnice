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
            Pacijent p = new Pacijent(idPacijenta.Text, ime.Text, prezime.Text, this.datum.SelectedDate ?? DateTime.Now, jmbg.Text, adresa.Text, telefon.Text, email.Text);
            if(RukovanjeNalozimaPacijenata.DodajNalog(p)==null)
            {
                System.Windows.Forms.MessageBox.Show("Već postoji uneto korisničko ime/jmbg!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
