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
    public class StacionarnoViewModel : SekretarViewModel
    {
        private ObservableCollection<PacijentDTO> pacijenti;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private String poruka;
        private PacijentDTO selektovaniPacijent;
  
        public StacionarnoViewModel()
        {
            UcitajUKolekciju();
            smestanjeKomanda = new RelayCommand(Smestanje);
            transferZahtevKomanda = new RelayCommand(TransferZahtev);
        }

        private void UcitajUKolekciju()
        {
            Pacijenti = new ObservableCollection<PacijentDTO>();
            foreach (PacijentDTO pacijentDTO in naloziPacijenataKontroler.DobaviSveNaloge())
            {
                Pacijenti.Add(pacijentDTO);
            }
        }
        public PacijentDTO SelektovaniPacijent
        {
            get { return selektovaniPacijent; }
            set
            {
                selektovaniPacijent = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PacijentDTO> Pacijenti
        {
            get { return pacijenti; }
            set
            {
                pacijenti = value;
                OnPropertyChanged();
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand smestanjeKomanda;

        public RelayCommand SmestanjeKomanda
        {
            get { return smestanjeKomanda; }
        }
        public void Smestanje()
        {
           UserControl usc = null;
           GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

           usc = new StacionarnoLecenjeSmestanjeSekretar();
           GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }

        private RelayCommand transferZahtevKomanda;

        public RelayCommand TransferZahtevKomanda
        {
            get { return transferZahtevKomanda; }
        }
        public void TransferZahtev()
        {
                 UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new NoviTransferPacijenataSekretar();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
