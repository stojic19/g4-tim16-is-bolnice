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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.LekarFolder
{
    public partial class BazaLekova : UserControl
    {
        String KorisnickoImeLekara = null;
        public static ObservableCollection<Lek> Lekovi { get; set; } = new ObservableCollection<Lek>();
        public static ObservableCollection<Sastojak> Sastojci { get; set; } = new ObservableCollection<Sastojak>();
        public static ObservableCollection<Lek> Zamenski { get; set; } = new ObservableCollection<Lek>();

        public BazaLekova(String korisnickoImeLekara)
        {
            InitializeComponent();
            KorisnickoImeLekara = korisnickoImeLekara;

            this.DataContext = this;

            foreach (Lek l in RukovanjeOdobrenimLekovima.SviLekovi)
            {
                Lekovi.Add(l);
            }
        }

        private void pretragaLeka_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void IzmenaLeka(object sender, RoutedEventArgs e)
        {

        }


        private void VerifikacijaLeka(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova(KorisnickoImeLekara));

        }

        private void dataGridLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Lek izabranLek = (Lek)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                PopunjavanjeSastojakaZamena(izabranLek.IDLeka);

            }
        }

        private void PopunjavanjeSastojakaZamena(String idIzabranogLeka)
        {
            Sastojci.Clear();
            Zamenski.Clear();

            foreach (Sastojak s in RukovanjeOdobrenimLekovima.PretraziPoID(idIzabranogLeka).Sastojci)
            {
                Sastojci.Add(s);
            }

            foreach (Lek l in RukovanjeOdobrenimLekovima.PretraziPoID(idIzabranogLeka).Zamene)
            {
                Zamenski.Add(l);
            }
        }
    }
}
