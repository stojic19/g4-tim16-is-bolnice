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
    public class NoviTransferViewModel : ViewModel
    { 
        public NoviTransferViewModel()
        {
            transferKomanda = new RelayCommand(Transfer);
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

                usc = new TransferPacijenataSekretar();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
