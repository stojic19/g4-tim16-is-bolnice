using Bolnica.Komande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.SekretarViewModel.AbstractKlase
{
    public abstract class PotvrdiOdustaniViewModel : SekretarViewModel
    {
        private String poruka;
        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
            set { potvrdiKomanda = value; }
        }
        public abstract void Potvrdi();
        
        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
            set { odustaniKomanda = value; }
        }
        public abstract void Odustani();
    }
}
