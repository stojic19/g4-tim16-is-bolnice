using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.PacijentFolder;
using Bolnica.View.PacijentFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class IzvestajSaPregledaViewModel: ViewModel
    {
        private PregledDTO pregled;
        private ObservableCollection<TerapijaDTO> terapije;
        private ObservableCollection<ReceptDTO> recepti;

        public IzvestajSaPregledaViewModel(PregledDTO pregled)
        {
            this.pregled = pregled;
            UcitajTerapije();
            UcitajRecepte();
            vratiSe = new RelayCommand(VratiSeNaIstoriju);
            kreirajBelesku = new RelayCommand(Kreiraj);
        }

        private void UcitajTerapije()
        {
            if (pregled.Anamneza.SveTerapije != null)
            {
                Terapije = new ObservableCollection<TerapijaDTO>();
                foreach (TerapijaDTO terapija in pregled.Anamneza.SveTerapije)
                    Terapije.Add(terapija);
            }

        }
        private void UcitajRecepte()
        {
            if (pregled.Recepti != null)
            {
                Recepti = new ObservableCollection<ReceptDTO>();
                foreach (ReceptDTO recept in pregled.Recepti)
                    Recepti.Add(recept);
            }
        }

        public PregledDTO Pregled
        {
            get { return pregled; }
            set
            {
                pregled = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TerapijaDTO> Terapije
        {
            get { return terapije; }
            set
            {
                terapije = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReceptDTO> Recepti
        {
            get { return recepti; }
            set
            {
                recepti = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand kreirajBelesku;
        public RelayCommand KreirajBelesku
        {
            get { return kreirajBelesku; }
        }
        public void Kreiraj()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new KreirajBelesku(Pregled));
        }
        private RelayCommand vratiSe;
        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNaIstoriju()
        {

            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IstorijaPregleda(Pregled.Termin.IdPacijenta));
        }
    }
}
