using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View.LekarFolder.ZdravstveniKartonLekar
{
    public partial class InformacijeAlergeni : UserControl
    {
        public static ObservableCollection<SastojakDTO> Sastojci { get; set; }
        LekoviKontroler lekoviKontroler = new LekoviKontroler();
        AlergenDTO izabranAlergen = null;
        String idPregleda = null;
        public InformacijeAlergeni(AlergenDTO izabranAlergen, String idPregleda)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            this.DataContext = this;
            this.izabranAlergen = izabranAlergen;
            this.idPregleda = idPregleda;
            inicijalizacijaPolja();
            inicijalizacijaTabele();
        }

        private void inicijalizacijaPolja()
        {
            this.jacinaLeka.Text = izabranAlergen.Lek.Jacina;
            this.nazivLeka.Text = izabranAlergen.Lek.NazivLeka;
            this.vremeReakcije.Text = izabranAlergen.VremeZaPojavu;
            this.opisReakcije.Text = izabranAlergen.OpisReakcije;

        }

        private void inicijalizacijaTabele()
        {
            Sastojci = new ObservableCollection<SastojakDTO>();

            foreach(SastojakDTO s in lekoviKontroler.DobaviSastojkeLeka(izabranAlergen.Lek.IdLeka))
            {
                Sastojci.Add(s);
            }

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(idPregleda, 2));
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new KartonLekar(idPregleda, 2));
        }

        private void opisReakcije_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    

        private void vremeReakcije_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void vremeReakcije_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void IzmeniAlergen(object sender, RoutedEventArgs e)
        {
            opisReakcije.IsReadOnly = false;
            opisReakcije.Text = string.Empty;
            vremeReakcije.IsReadOnly = false;
            vremeReakcije.Text = string.Empty;
            izmeniAlergen.Visibility = Visibility.Hidden;
            odustani.Visibility = Visibility.Visible;
            potvrdi.Visibility = Visibility.Visible;
            
        }
    }
}
