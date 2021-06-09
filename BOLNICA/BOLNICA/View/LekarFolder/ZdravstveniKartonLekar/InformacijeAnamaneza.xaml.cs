using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.ViewModel.LekarViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Bolnica
{

    public partial class InformacijeAnamaneza : UserControl
    {
        private InformacijeAnamnezaViewModel informacijeAnamnezaViewModel;
        public InformacijeAnamaneza(AnamnezaDTO odabranaAnamneza)
        {

            InitializeComponent();
            LekarGlavniProzor.postaviPrethodnu();
            LekarGlavniProzor.postaviTrenutnu(this);
            informacijeAnamnezaViewModel = new InformacijeAnamnezaViewModel(odabranaAnamneza);
            this.DataContext = informacijeAnamnezaViewModel;
        }


    }
}