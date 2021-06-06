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
        private String tekstPretrage;
        public TerapijaViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            tekstPretrage = "Unesite ime leka";
            UcitajKolekciju();
            izvestaj = new RelayCommand(PrikaziIzvestaj);
            detaljiTerapije = new RelayCommand(Detalji);
            pretraga = new RelayCommand(Pretrazi);
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
        private String poruka;
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }
        public String TekstPretrage
        {
            get { return tekstPretrage; }
            set
            {
                tekstPretrage = value;
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


        private RelayCommand pretraga;

        public RelayCommand Pretraga
        {
            get { return pretraga; }
        }
     
        public void Pretrazi()
        {
            Poruka = "";

            if (TekstPretrage.Equals(""))
            {
                TerapijePacijenta.Clear();
                foreach (TerapijaDTO terapija in zdravstveniKartonKontroler.DobaviSveTerapijePacijenta(KorisnickoIme))
                    TerapijePacijenta.Add(terapija);
                return;
            }


            List<TerapijaDTO> pretraga = PretragaTermina();
            if (pretraga.Count != 0)
            {
                TerapijePacijenta.Clear();
                foreach (TerapijaDTO terapija in pretraga)
                {
                        TerapijePacijenta.Add(terapija);
                }
                return;
            }
            Poruka = "Ne postoje obavljeni termini za uneti datum!";

        }

        private List<TerapijaDTO> PretragaTermina()
        {
            List<TerapijaDTO> rezultatiPretrage = new List<TerapijaDTO>();
            foreach (TerapijaDTO terapija in zdravstveniKartonKontroler.DobaviSveTerapijePacijenta(KorisnickoIme).OrderByDescending(user => user.PocetakTerapije).ToList())
            {
                if (terapija.Lek.NazivLeka.ToUpper().StartsWith(TekstPretrage.ToUpper()))
                    rezultatiPretrage.Add(terapija);
            }
            return rezultatiPretrage;
        }

    }
}
