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

    public partial class InformacijeAnamaneza : Window
    {
        String korisnik = null;
        public static ObservableCollection<Terapija> Terapije { get; set; }

        public InformacijeAnamaneza(Anamneza izabrana)
        {

            InitializeComponent();

            korisnik = izabrana.IdLekara;

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabrana.IdPacijenta);
            ZdravstveniKarton zk = p.ZdravstveniKarton;

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;

            Lekar l = RukovanjeTerminima.pretraziLekare(izabrana.IdLekara);
            
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;

            idAnamneze.Text = izabrana.IdAnamneze;

            datumPregleda.Text = izabrana.Datum;

            tekst.Text = izabrana.Dijagnoza;

            this.DataContext = this;

            Terapije = new ObservableCollection<Terapija>();

            foreach (Terapija t in izabrana.Terapije)
            {
                Terapije.Add(t);
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//back
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            PrikazTerminaLekara termini = new PrikazTerminaLekara(korisnik);

            termini.Show();
            this.Close();

        }
    }
}
