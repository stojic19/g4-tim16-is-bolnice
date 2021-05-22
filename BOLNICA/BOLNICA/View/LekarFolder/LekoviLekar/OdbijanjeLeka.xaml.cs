using Bolnica.Model;
using Bolnica.Model.Rukovanja;
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

namespace Bolnica.LekarFolder.LekoviLekar
{
    public partial class OdbijanjeLeka : UserControl
    {
        String KorisnickoImeLekara = null;
        Zahtjev izabranZahtev = null;
        public static ObservableCollection<Sastojak> Sastojci { get; set; } = new ObservableCollection<Sastojak>();

        public OdbijanjeLeka(string idZahtjeva, string korisnickoImeLekara)
        {
            InitializeComponent();
            this.KorisnickoImeLekara = korisnickoImeLekara;
            izabranZahtev = ZahteviServis.PretraziPoId(idZahtjeva);
            this.DataContext = this;
            inicijalizacijaPodataka();
            
        }

        private void inicijalizacijaPodataka()
        {
            nazivLeka.Text = izabranZahtev.Lijek.NazivLeka;
            jacinaLeka.Text = izabranZahtev.Lijek.Jacina;
            Sastojci.Clear();

            foreach(Sastojak s in izabranZahtev.Lijek.Sastojci)
            {
                Sastojci.Add(s);
            }


        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova(KorisnickoImeLekara));

        }

        private void Potvrda(object sender, RoutedEventArgs e)
        {
            if (!ValidacijaUnosa()) return;


            ZahteviServis.OdbijZahtev(izabranZahtev.IdZahtjeva, razlogOdbijanja.Text);
            ZahteviServis.SerijalizacijaZahtjeva();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova(KorisnickoImeLekara));

        }

        private Boolean ValidacijaUnosa()
        {
            if (razlogOdbijanja.Text.Equals(""))
            {
                validacijaOdbijanja.Visibility = Visibility.Visible;
                return false;
            }

            return true;

        }

        private void razlogOdbijanja_TextChanged(object sender, TextChangedEventArgs e)
        {
            validacijaOdbijanja.Visibility = Visibility.Hidden;
        }

        private void razlogOdbijanja_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            validacijaOdbijanja.Visibility = Visibility.Hidden;
        }
    }
}
