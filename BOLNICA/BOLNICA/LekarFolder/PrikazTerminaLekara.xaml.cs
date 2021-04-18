using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class PrikazTerminaLekara : Window
    {

        public static ObservableCollection<Termin> Termini { get; set; }
        public String korisnik = null;

        public PrikazTerminaLekara(String korIme)
        {
            InitializeComponent();
            korisnik = korIme;
            this.DataContext = this;

            Termini = new ObservableCollection<Termin>();

            foreach (Termin t in RukovanjeTerminima.PretraziPoLekaru(korIme))
            {
                Termini.Add(t);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) //zakazivanje
        {
            ZakazivanjeTerminaLekar zakazivanje = new ZakazivanjeTerminaLekar();
            zakazivanje.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //izmena
        {
            Termin izabranZaMenjanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaMenjanje != null)
            {

                IzmenaTerminaLekar izmena = new IzmenaTerminaLekar(izabranZaMenjanje.IdTermina);
                izmena.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //otkazivanje
        {

            Termin izabranZaBrisanje = (Termin)dataGridTermini.SelectedItem;

            if (izabranZaBrisanje != null)
            {

                OtkazivanjeTerminaLekar otkazivanje = new OtkazivanjeTerminaLekar(izabranZaBrisanje.IdTermina);
                otkazivanje.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Izaberite termin koji želite da otkažete!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //back
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeTerminima.SerijalizacijaTermina();
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //karton
        {
            Termin izabran = (Termin)dataGridTermini.SelectedItem;

            if (izabran != null)
            {
                KartonLekar karton = new KartonLekar(izabran.Pacijent.KorisnickoIme,0, korisnik );
                karton.Show();
                this.Close();
            }
        }
    }
}
