using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder.LekoviLekar;
using Bolnica.Model;
using Bolnica.ViewModel.LekarViewModel;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bolnica.LekarFolder
{
    public partial class BazaLekova : UserControl
    {
        private BazaLekovaViewModel bazaLekovaViewModel;

        public BazaLekova()
        {
            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            bazaLekovaViewModel = new BazaLekovaViewModel();
            this.DataContext = bazaLekovaViewModel;

        }

    }
}
