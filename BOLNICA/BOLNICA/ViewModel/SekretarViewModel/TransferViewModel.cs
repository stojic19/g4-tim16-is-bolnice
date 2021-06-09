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
    public class TransferViewModel : SekretarViewModel
    {
        private String poruka;
  
        public TransferViewModel()
        {
            transferZahtevKomanda = new RelayCommand(TransferZahtev);
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
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
