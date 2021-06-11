using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bolnica
{
    public partial class IzmenaZamenskihLekova : UserControl
    {
        LekDTO izabranLek = null;
        List<LekDTO> noviZamenski = new List<LekDTO>();
        private LekoviKontroler lekoviKontroler = new LekoviKontroler();
        public static ObservableCollection<LekDTO> Zamenski { get; set; } = new ObservableCollection<LekDTO>();
        public static ObservableCollection<LekDTO> SviLekovi { get; set; } = new ObservableCollection<LekDTO>();
        public IzmenaZamenskihLekova(String idLeka)
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            izabranLek = lekoviKontroler.PretraziPoID(idLeka);
            this.DataContext = this;
            inicijalizacijaPolja();
            inicijalizacijaTabeleZamenskih();
            InicijalizacijaTabeleSvihLekova();
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
            foreach (LekDTO l in lekoviKontroler.DobaviZameneLeka(izabranLek.IdLeka))
            {
                Zamenski.Add(l);
                noviZamenski.Add(l);
            }

        }

        private void InicijalizacijaTabeleSvihLekova()
        {
            SviLekovi.Clear();

            foreach (LekDTO l in lekoviKontroler.DobaviSveLekove())
            {
                if (!l.IdLeka.Equals(izabranLek.IdLeka) && !DaLiJeVecZamenski(l.IdLeka))
                {
                    SviLekovi.Add(l);
                }
            }
        }

        private Boolean DaLiJeVecZamenski(String idLeka)
        {

            foreach (LekDTO l in lekoviKontroler.DobaviZameneLeka(izabranLek.IdLeka))
            {
                if (l.IdLeka.Equals(idLeka))
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
                return ((item as LekDTO).NazivLeka.IndexOf(pretragaLekova.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void podesavanjePretrageLekova()
        {
            this.dataGridSviLekovi.ItemsSource = SviLekovi;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridSviLekovi.ItemsSource);
            view.Filter = FiltriranjeLekova;
        }

        private void BrisanjeZamenskog(object sender, RoutedEventArgs e)
        {
            LekDTO izabranZamenski = (LekDTO)dataGridZamenski.SelectedItem;

            if (izabranZamenski != null)
            {
                foreach (LekDTO l in noviZamenski)
                {
                    if (l.IdLeka.Equals(izabranZamenski.IdLeka))
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
            LekDTO izabranZamenski = (LekDTO)dataGridSviLekovi.SelectedItem;
            if (izabranZamenski == null) return;

            foreach (LekDTO l in lekoviKontroler.DobaviSveLekove())
            {
                if (l.IdLeka.Equals(izabranZamenski.IdLeka))
                {
                    SviLekovi.Remove(izabranZamenski);
                    noviZamenski.Add(l);
                    Zamenski.Add(l);
                    break;
                }
            }
        }

        private void Odustajanje(object sender, RoutedEventArgs e)
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova());
        }

        private void CuvanjeIzmena(object sender, RoutedEventArgs e)
        {
            lekoviKontroler.IzmenaZamenskihLekova(izabranLek.IdLeka, noviZamenski);
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new BazaLekova());
        }
    }
}
