using Bolnica.LekarFolder;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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

    public partial class InformacijeAnamaneza : UserControl
    {
        Pregled izabranPregled = null;
        Anamneza izabranaAnamneza = null;
        public static ObservableCollection<Terapija> Terapije { get; set; }

        public InformacijeAnamaneza(Anamneza odabranaAnamneza, String IDIzabranog)
        {

            InitializeComponent();
            this.izabranPregled = RukovanjePregledima.PretraziPoId(IDIzabranog);
            this.izabranaAnamneza = odabranaAnamneza;

            inicijalizacijaPolja();

            this.DataContext = this;

            Terapije = new ObservableCollection<Terapija>();

            foreach (Terapija t in izabranaAnamneza.Terapije)
            {
                Terapije.Add(t);
            }


        }

        private void inicijalizacijaPolja()
        {

            Pacijent p = RukovanjeNalozimaPacijenata.PretraziPoId(izabranaAnamneza.IdPacijenta);
            Lekar l = RukovanjeTerminima.pretraziLekare(izabranaAnamneza.IdLekara);

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            jmbg.Text = p.Jmbg;
            imeLekara.Text = l.Ime;
            prezimeLekara.Text = l.Prezime;
            datumPregleda.Text = izabranaAnamneza.Datum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            tekst.Text = izabranaAnamneza.Dijagnoza;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
        }

        private void Povratak(object sender, RoutedEventArgs e)
        {
            RukovanjeNalozimaPacijenata.Sacuvaj();
            RukovanjePregledima.SerijalizacijaPregleda();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(izabranPregled.IdPregleda, 1));

        }
    }
}