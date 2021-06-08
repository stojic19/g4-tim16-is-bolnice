using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.LekarFolder.LekoviLekar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bolnica.ViewModel.LekarViewModel
{
    public class BazaLekovaViewModel : ViewModel
    {
        private LekoviKontroler lekoviKontroler = new LekoviKontroler();

        public BazaLekovaViewModel()
        {
            izmenaLekaKomanda = new RelayCommand(IzmenaLeka);
            verifikacijaLekaKomanda = new RelayCommand(VerifikacijaLeka);
            izmenaZamenaKomanda = new RelayCommand(IzmenaZamena);
            InicijalizacijaTabele();
            InicijalizacijaPretrage();
            Sastojci = new ObservableCollection<SastojakDTO>();
            Zamenski = new ObservableCollection<LekDTO>();
        }

        private ObservableCollection<LekDTO> lekovi;
        public ObservableCollection<LekDTO> Lekovi
        {
            get { return lekovi; }
            set
            {
                lekovi = value;
                OnPropertyChanged();
            }

        }
        private ObservableCollection<SastojakDTO> sastojci;
        public ObservableCollection<SastojakDTO> Sastojci
        {
            get { return sastojci; }
            set
            {
                sastojci = value;
                OnPropertyChanged();
            }

        }
        private ObservableCollection<LekDTO> zamenski;
        public ObservableCollection<LekDTO> Zamenski
        {
            get { return zamenski; }
            set
            {
                zamenski = value;
                OnPropertyChanged();
            }

        }

        private void InicijalizacijaTabele()
        {
            Lekovi = new ObservableCollection<LekDTO>();
            foreach (LekDTO l in lekoviKontroler.DobaviSveLekove())
            {
                Lekovi.Add(l);
            }
        }

        private String poljePretraga;

        public String PoljePretraga
        {
            get { return poljePretraga; }
            set
            {
                poljePretraga = value;
                OnPropertyChanged("PoljePretraga");
                CollectionViewSource.GetDefaultView(Lekovi).Refresh();

            }
        }

        private void InicijalizacijaPretrage()
        {
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(Lekovi);
            view2.Filter = FiltriranjeLeka;
        }

        private bool FiltriranjeLeka(object item)
        {
            if (String.IsNullOrEmpty(PoljePretraga))
                return true;
            else
                return ((item as LekDTO).NazivLeka.IndexOf(PoljePretraga, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private LekDTO izabranLek;

        public LekDTO IzabranLek
        {
            get { return izabranLek; }
            set
            {
                izabranLek = value;
                OnPropertyChanged();
                if (izabranLek != null)
                {
                    PopunjavanjeSastojaka(IzabranLek.IdLeka);
                    PopunjavanjeZamena(IzabranLek.IdLeka);
                }
            }
        }

        private void PopunjavanjeSastojaka(String idIzabranogLeka)
        {
            Sastojci.Clear();

            foreach (SastojakDTO s in lekoviKontroler.DobaviSastojkeLeka(idIzabranogLeka))
            {
                Sastojci.Add(s);
            }
        }

        private void PopunjavanjeZamena(String idIzabranogLeka)
        {
            Zamenski.Clear();

            foreach (LekDTO l in lekoviKontroler.DobaviZameneLeka(idIzabranogLeka))
            {
                Zamenski.Add(l);
            }
        }

        private RelayCommand verifikacijaLekaKomanda;

        public RelayCommand VerifikacijaLekaKomanda
        {
            get { return verifikacijaLekaKomanda; }
        }
        public void VerifikacijaLeka()
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new VerifikacijaLekova());

        }

        private RelayCommand izmenaLekaKomanda;

        public RelayCommand IzmenaLekaKomanda
        {
            get { return izmenaLekaKomanda; }
        }
        public void IzmenaLeka()
        {
            if (IzabranLek != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaLeka(IzabranLek.IdLeka));
            }
        }

         private RelayCommand izmenaZamenaKomanda;

        public RelayCommand IzmenaZamenaKomanda
        {
            get { return izmenaZamenaKomanda; }
        }
        public void IzmenaZamena()
        {
            if (IzabranLek != null)
            {
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new IzmenaZamenskihLekova(IzabranLek.IdLeka));

            }
        }

    }
}
