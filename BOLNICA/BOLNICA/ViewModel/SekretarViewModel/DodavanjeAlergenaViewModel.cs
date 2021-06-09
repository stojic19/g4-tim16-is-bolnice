﻿using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class DodavanjeAlergenaViewModel : SekretarViewModel
    {
        private String korisnickoIme;
        private ObservableCollection<LekDTO> lekovi;
        private AlergeniKontroler alergeniKontroler = new AlergeniKontroler();
        private LekDTO selektovaniLek;
        private String poruka;
        private AlergenDTO podaci;
        private String tekstPretrage;

        public DodavanjeAlergenaViewModel(String korisnickoImePacijenta)
        {
            Podaci = new AlergenDTO();
            this.korisnickoIme = korisnickoImePacijenta;
            UcitajUKolekciju();
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
        }

        public void UcitajUKolekciju()
        {
            Lekovi = new ObservableCollection<LekDTO>();
            foreach (LekDTO lek in alergeniKontroler.DobaviLekoveZaDodavanje())
            {
                Lekovi.Add(lek);
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Lekovi);
            view.Filter = FiltriranjeLekova;
        }
        private bool FiltriranjeLekova(object item)
        {
            if (String.IsNullOrEmpty(tekstPretrage))
                return true;
            else
                return ((item as LekDTO).NazivLeka.IndexOf(tekstPretrage, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public ObservableCollection<LekDTO> Lekovi
        {
            get { return lekovi; }
            set
            {
                lekovi = value;
                OnPropertyChanged();
            }
        }
        public LekDTO SelektovaniLek
        {
            get { return selektovaniLek; }
            set
            {
                selektovaniLek = value;
                OnPropertyChanged();
            }
        }
        public AlergenDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
        }
        public String TekstPretrage
        {
            get { return tekstPretrage; }
            set
            {
                tekstPretrage = value;
                OnPropertyChanged(() => this.tekstPretrage);
            }
        }

        private void OnPropertyChanged(Func<object> p)
        {
            CollectionViewSource.GetDefaultView(Lekovi).Refresh();
        }
        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        public void Potvrdi()
        {
            if (IspravniUnetiPodaci())
            {
                Podaci.IdAlergena = selektovaniLek.IdLeka;
                alergeniKontroler.DodajAlergen(korisnickoIme, Podaci);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new AlergeniSekretar(korisnickoIme);
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
            }
        }
        private bool IspravniUnetiPodaci()
        {
            if (selektovaniLek == null)
            {
                Poruka = "*Izaberite lek!";
                return false;
            }
            if (alergeniKontroler.DaLiLekVecPostojiUAlergenimaPacijenta(korisnickoIme, selektovaniLek.IdLeka))
            {
                Poruka = "Izabrani lek već postoji u alergenima!";
                return false;
            }
            if (Podaci.OpisReakcije.Equals(""))
            {
                Poruka = "Morate uneti opis reaksije!";
                return false;
            }
            if (Podaci.VremeZaPojavu.Equals(""))
            {
                Poruka = "Morate uneti vreme potrebno za pojavu reakcije!";
                return false;
            }
            return true;
        }
        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
        }
        public void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new AlergeniSekretar(korisnickoIme);
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
