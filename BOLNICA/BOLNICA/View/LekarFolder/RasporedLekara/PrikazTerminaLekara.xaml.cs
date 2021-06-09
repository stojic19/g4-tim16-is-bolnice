using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Lokalizacija;
using Bolnica.ViewModel.LekarViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace Bolnica
{

    public partial class PrikazTerminaLekara : System.Windows.Controls.UserControl
    {
        

        private LekarRasporedViewModel lekarRasporedViewModel; 

        public PrikazTerminaLekara()
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            lekarRasporedViewModel = new LekarRasporedViewModel();
            dataGridTermini.ItemsSource = lekarRasporedViewModel.Termini;
            this.DataContext = lekarRasporedViewModel;

        }


    }
}
