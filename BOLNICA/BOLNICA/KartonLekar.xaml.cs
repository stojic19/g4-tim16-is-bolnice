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
    public partial class KartonLekar : Window
    {

        String izabran = null;
        public static ObservableCollection<Recept> Recepti { get; set; }

        public KartonLekar(String korImePacijenta)
        {
            InitializeComponent();

            izabran = korImePacijenta;
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            ZdravstveniKarton zk = p.ZdravstveniKarton;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            telefon.Text = p.KontaktTelefon;
            adresa.Text = p.AdresaStanovanja;
            datum.Text = p.DatumRodjenja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (p.VrstaNaloga == VrsteNaloga.gost)
            {
                status.Text = "Gost";
            }
            else
            {
                status.Text = "Regularan";
            }

            this.DataContext = this;

            Recepti = new ObservableCollection<Recept>();

            foreach (Recept r in zk.Recepti)
            {
               Recepti.Add(r);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrikazTerminaLekara termini = new PrikazTerminaLekara();
            
            termini.Show();
            this.Close();

        }


        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this.Close(); //Izmeni!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DodavanjeRecepta recept = new DodavanjeRecepta(izabran);

            recept.Show();
            this.Close();
        }
    }
}
