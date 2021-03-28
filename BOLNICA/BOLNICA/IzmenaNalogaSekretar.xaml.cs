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
    /// <summary>
    /// Interaction logic for IzmenaNalogaSekretar.xaml
    /// </summary>
    public partial class IzmenaNalogaSekretar : Window
    {
        String izabran = null;

        public IzmenaNalogaSekretar(String id)
        {
            InitializeComponent();

            izabran = id;
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(id);


            idPacijenta.Text = p.korisnickoIme;
            ime.Text = p.ime;
            prezime.Text = p.prezime;
            datum.SelectedDate = p.datumRodjenja;
            jmbg.Text = p.jmbg;
            adresa.Text = p.adresaStanovanja;
            telefon.Text = p.kontaktTelefon;
            email.Text = p.email;
        
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
