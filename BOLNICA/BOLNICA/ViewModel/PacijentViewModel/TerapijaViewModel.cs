using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
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
    public class TerapijaViewModel:ViewModel
    {
        private ObservableCollection<TerapijaDTO> terapijePacijenta;
        private String korisnickoIme;
        private ZdravstvenKartoniKontroler zdravstveniKartonKontroler = new ZdravstvenKartoniKontroler();
        private TerapijaDTO izabranaTerapija;
        public TerapijaViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            UcitajKolekciju();
            izvestaj = new RelayCommand(PrikaziIzvestaj);
            detaljiTerapije = new RelayCommand(Detalji);
        }

        private void UcitajKolekciju()
        {
            TerapijePacijenta = new ObservableCollection<TerapijaDTO>();
            foreach (TerapijaDTO terapija in zdravstveniKartonKontroler.DobaviSveTerapijePacijenta(KorisnickoIme))
                TerapijePacijenta.Add(terapija);
        }
        public ObservableCollection<TerapijaDTO> TerapijePacijenta
        {
            get { return terapijePacijenta; }
            set
            {
                terapijePacijenta = value;
                OnPropertyChanged();
            }
        }

        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged();
            }
        }
        public TerapijaDTO IzabranaTerapija
        {
            get { return izabranaTerapija; }
            set
            {
                izabranaTerapija = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand izvestaj;
        public RelayCommand Izvestaj
        {
            get { return izvestaj; }
        }
        public void PrikaziIzvestaj()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajTerapije(KorisnickoIme));
        }

        private RelayCommand detaljiTerapije;
        public RelayCommand DetaljiTerapije
        {
            get { return detaljiTerapije; }
        }
        public void Detalji()
        {
            DetaljiTerapije detaljiTerapije = new DetaljiTerapije(IzabranaTerapija);
            detaljiTerapije.Show();
        }

    }
}
