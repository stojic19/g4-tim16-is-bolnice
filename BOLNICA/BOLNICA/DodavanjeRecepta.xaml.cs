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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    public partial class DodavanjeRecepta : Window
    {
        String izabran = null;
        public static ObservableCollection<Recept> Recepti { get; set; }
        public DodavanjeRecepta(String idPacijenta)
        {
            InitializeComponent();
            izabran = idPacijenta;

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabran);
            ZdravstveniKarton zk = p.ZdravstveniKarton;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;

            Lekar l = RukovanjeTerminima.pretraziLekare("JelenaHrnjak");
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;

            idRecepta.Text = RukovanjeZdravstvenimKartonima.generisiIDRecepta(izabran);


            this.DataContext = this;

            Recepti = new ObservableCollection<Recept>();

            foreach (Recept r in zk.Recepti)
            {
                Recepti.Add(r);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        KartonLekar kartonLekar = new KartonLekar(izabran);
        kartonLekar.Show();
        this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Sacuvaj
        {

            String idRecepta = this.idRecepta.Text;

            String idLekara = "JelenaHrnjak";

            String idPacijenta = izabran;

            Pacijent pacijent = RukovanjeNalozimaPacijenata.PretraziPoId(idPacijenta);
            //pacijent.ZdravstveniKarton = new ZdravstveniKarton(idPacijenta);
            //pacijent.ZdravstveniKarton.Recepti = new List<Recept>();


            DateTime? pocetak = this.pocTer.SelectedDate;
            String formatiranoPoc = null;

            if (pocetak.HasValue)
            {
                formatiranoPoc = pocetak.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            DateTime? kraj = this.krajTer.SelectedDate;
            String formatiranoKraj = null;

            if (pocetak.HasValue)
            {
                formatiranoKraj = kraj.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            int satnica = int.Parse(this.satnica.Text);

            int kolicina = int.Parse(this.dnevnaKol.Text);

            String nazivLeka = this.imeLeka.Text;
            String sifraLeka = this.sifraLeka.Text;
            String jacinaLeka = this.jacinaLeka.Text;

            Lek l = new Lek(sifraLeka, nazivLeka, jacinaLeka);


            if (this.imeLeka.Text.Equals("") || this.sifraLeka.Text.Equals("") || this.satnica.Text.Equals("") ||
                this.jacinaLeka.Text.Equals("") || !pocetak.HasValue || !kraj.HasValue || this.dnevnaKol.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Niste popunili sva polja!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (pacijent == null)
            {

                System.Windows.Forms.MessageBox.Show("Nepostojeći pacijent!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Recept r = new Recept(idRecepta, idLekara, idPacijenta,formatiranoKraj, formatiranoPoc, satnica, kolicina, l);
            RukovanjeZdravstvenimKartonima.DodajRecept(r);

            KartonLekar kl = new KartonLekar(izabran);
            kl.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Izvestaj
        {
            KartonLekar kl = new KartonLekar(izabran);
            kl.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Odustani
        {
            KartonLekar kl = new KartonLekar(izabran);
            kl.Show();
            this.Close();

        }
    }
}
