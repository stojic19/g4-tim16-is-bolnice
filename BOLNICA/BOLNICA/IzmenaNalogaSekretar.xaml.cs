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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{

    public partial class IzmenaNalogaSekretar : Window
    {
        String izabran = null;

        public IzmenaNalogaSekretar(String id)
        {
            InitializeComponent();

            izabran = id;
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(id);


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
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RukovanjeNalozimaPacijenata.IzmeniNalog(izabran, ime.Text, prezime.Text, this.datum.SelectedDate ?? DateTime.Now, jmbg.Text, adresa.Text, telefon.Text, email.Text);
            this.Close();
        }
    }
}
