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
    public class TransferViewModel : ViewModel
    {
        private String poruka;
  
        public TransferViewModel()
        {
            transferKomanda = new RelayCommand(Transfer);
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand transferKomanda;

        public RelayCommand TransferKomanda
        {
            get { return transferKomanda; }
        }
        public void Transfer()
        {
                 UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new NoviTransferPacijenataSekretar();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
