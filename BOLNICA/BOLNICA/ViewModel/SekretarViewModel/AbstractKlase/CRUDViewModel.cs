using Bolnica.Komande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.SekretarViewModel.AbstractKlase
{
    public abstract class CRUDViewModel : SekretarViewModel
    {
        private String poruka;
        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand ukloniKomanda;

        public RelayCommand UkloniKomanda
        {
            get { return ukloniKomanda; }
            set { ukloniKomanda = value; }
        }
        public abstract void Ukloni();

        private RelayCommand izmeniKomanda;

        public RelayCommand IzmeniKomanda
        {
            get { return izmeniKomanda; }
            set { izmeniKomanda = value; }
        }
        public abstract void Izmeni();

        private RelayCommand dodajKomanda;

        public RelayCommand DodajKomanda
        {
            get { return dodajKomanda; }
            set { dodajKomanda = value; }
        }
        public abstract void Dodaj();
    }
}
