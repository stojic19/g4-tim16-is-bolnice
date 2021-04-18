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
    public partial class KartonLekar : Window
    {

        String izabran = null;
        public static ObservableCollection<Recept> Recepti { get; set; }
        public static ObservableCollection<Anamneza> Anamneze { get; set; }

        public KartonLekar(String korImePacijenta, int indeks)
        {
            InitializeComponent();

            Tabovi.SelectedIndex = indeks;
            izabran = korImePacijenta;
            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            ZdravstveniKarton zk = p.ZdravstveniKarton;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            telefon.Text = p.KontaktTelefon;
            adresa.Text = p.AdresaStanovanja;
            datum.Text = p.DatumRodjenja.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if(p.Pol == Pol.zenski)
            {
                pol.Text = "Ž";
            }
            else
            {
                pol.Text = "M";
            }

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

            Anamneze = new ObservableCollection<Anamneza>();

            foreach (Anamneza a in zk.Anamneze)
            {
                Anamneze.Add(a);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            PrikazTerminaLekara termini = new PrikazTerminaLekara();
            
            termini.Show();
            this.Close();

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DodavanjeRecepta recept = new DodavanjeRecepta(izabran);

            recept.Show();

            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Nova anamneza
        {
            NovaAnamneza dodajAnamnezu = new NovaAnamneza(izabran);

            dodajAnamnezu.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Vise informacija anamneza
        {   
        }
    }
}
