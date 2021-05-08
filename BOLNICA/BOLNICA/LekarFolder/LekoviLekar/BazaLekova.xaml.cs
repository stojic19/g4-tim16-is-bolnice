using Bolnica.LekarFolder.LekoviLekar;
using Bolnica.Model;
using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            this.dataGridLekovi.ItemsSource = RukovanjeOdobrenimLekovima.SviLekovi;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource);
            view2.Filter = FiltriranjeLeka;

        }


        private void IzmenaLeka(object sender, RoutedEventArgs e)
        {
            Lek izabranLek = (Lek)dataGridLekovi.SelectedItem;

            if (izabranLek != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaLeka(izabranLek.IDLeka, KorisnickoImeLekara));

            }


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

        private bool FiltriranjeLeka(object item)
        {
            if (String.IsNullOrEmpty(pretragaLeka.Text))
                return true;
            else
                return ((item as Lek).NazivLeka.IndexOf(pretragaLeka.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void pretragaLeka_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridLekovi.ItemsSource).Refresh();
        }
           
        private void IzmenaZamena(object sender, RoutedEventArgs e)
        {

        }

    }
}
