using Bolnica.DTO;
using Bolnica.Komande;
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
        }

        private void UcitajTerapije()
        {
            Terapije = new ObservableCollection<TerapijaDTO>();
            foreach (TerapijaDTO terapija in pregled.Anamneza.SveTerapije)
                Terapije.Add(terapija);


        }
        private void UcitajRecepte()
        {
            Recepti = new ObservableCollection<ReceptDTO>();
            foreach (ReceptDTO recept in pregled.Recepti)
                Recepti.Add(recept);

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

        }
        private RelayCommand vratiSe;
        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNaIstoriju()
        {
        }
    }
}
