using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class StacionarnoSmestanjeViewModel : SekretarViewModel
    {
        private ObservableCollection<ProstorDTO> prostorije;
        private ProstoriKontroler prostoriKontroler = new ProstoriKontroler();
        private String poruka;
  
        public StacionarnoSmestanjeViewModel()
        {
            UcitajUKolekciju();
            potvrdiKomanda = new RelayCommand(Potvrdi);
            transferZahtevKomanda = new RelayCommand(transferZahtev);
        }

        private void UcitajUKolekciju()
        {
            Prostorije = new ObservableCollection<ProstorDTO>();
            foreach (ProstorDTO prostor in prostoriKontroler.SviProstori())
            {
                Prostorije.Add(prostor);
            }
        }
        public ObservableCollection<ProstorDTO> Prostorije
        {
            get { return prostorije; }
            set
            {
                prostorije = value;
                OnPropertyChanged();
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        public void Potvrdi()
        {
           UserControl usc = null;
           GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

           usc = new StacionarnoLecenjeSekretar();
           GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private RelayCommand transferZahtevKomanda;

        public RelayCommand TransferZahtevKomanda
        {
            get { return transferZahtevKomanda; }
        }
        public void transferZahtev()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new NoviTransferPacijenataSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
