using Bolnica.LekarFolder;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
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

namespace Bolnica
{
    public partial class IzmenaZamenskihLekova : UserControl
    {
        Lek izabranLek = null;
        String KorisnickoImeLekara = null;
        List<Lek> noviZamenski = new List<Lek>();
        public static ObservableCollection<Lek> Zamenski { get; set; } = new ObservableCollection<Lek>();
        public static ObservableCollection<Lek> SviLekovi { get; set; } = new ObservableCollection<Lek>();
        public IzmenaZamenskihLekova(String idLeka, String idLekara)
        {
            InitializeComponent();
            izabranLek = LekoviServis.PretraziPoID(idLeka);
            KorisnickoImeLekara = idLekara;
            this.DataContext = this;
            inicijalizacijaPolja();
            inicijalizacijaTabeleZamenskih();
            inicijalizacijaTabeleSvihLekova();
            podesavanjePretrageLekova();
        }

        private void inicijalizacijaPolja()
        {
            this.nazivLeka.Text = izabranLek.NazivLeka;
            this.jacinaLeka.Text = izabranLek.Jacina;

        }

        private void inicijalizacijaTabeleZamenskih()
        {
            Zamenski.Clear();
            foreach (Lek l in izabranLek.Zamene)
            {
                Zamenski.Add(l);
                noviZamenski.Add(l);
            }

        }

        private void inicijalizacijaTabeleSvihLekova()
        {
            SviLekovi.Clear();

            foreach (Lek l in LekoviRepozitorijum.SviLekovi)
            {
                if (!l.IDLeka.Equals(izabranLek.IDLeka) && !ProveraPostojanjaZamenskog(l.IDLeka) )
                {
                    SviLekovi.Add(l);
                }
                
            }

        }

        private Boolean ProveraPostojanjaZamenskog(String idLeka)
        {

            foreach(Lek l in izabranLek.Zamene)
            {
                if (l.IDLeka.Equals(idLeka))
                {
                    return true;
                }
            }

            return false;
        }

        private void pretragaLekova_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridSviLekovi.ItemsSource).Refresh();
        }

        private bool FiltriranjeLekova(object item)
        {
            if (String.IsNullOrEmpty(pretragaLekova.Text))
                return true;
            else
                return ((item as Lek).NazivLeka.IndexOf(pretragaLekova.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void podesavanjePretrageLekova()
        {
            this.dataGridSviLekovi.ItemsSource = SviLekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridSviLekovi.ItemsSource);
            view.Filter = FiltriranjeLekova;
        }

        private void BrisanjeZamenskog(object sender, RoutedEventArgs e)
        {
            Lek izabranZamenski = (Lek)dataGridZamenski.SelectedItem;

            if (izabranZamenski != null)
            {
                foreach (Lek l in noviZamenski)
                {
                    if (l.IDLeka.Equals(izabranZamenski.IDLeka))
                    {
                        noviZamenski.Remove(l);
                        Zamenski.Remove(l);
                        SviLekovi.Add(l);
                        break;
                    }
                }
            }
        }

        private void DodavanjeZamenskog(object sender, RoutedEventArgs e)
        {
            Lek izabranZamenski = (Lek)dataGridSviLekovi.SelectedItem;

            if (izabranZamenski != null)
            {
                foreach (Lek l in LekoviRepozitorijum.SviLekovi)
                {
                    if (l.IDLeka.Equals(izabranZamenski.IDLeka))
                    {
                        noviZamenski.Add(l);
                        Zamenski.Add(l);
                        SviLekovi.Remove(l);
                        break;
                    }
                }
            }
        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoImeLekara));
        }

        private void CuvanjeIzmena(object sender, RoutedEventArgs e)
        {
            LekoviServis.IzmenaZamenskihLekova(izabranLek.IDLeka, noviZamenski);
            LekoviRepozitorijum.SerijalizacijaLekova();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova(KorisnickoImeLekara));
        }
    }
}
