using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using com.sun.org.apache.xerces.@internal.impl.xpath.regex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class ZakazivanjeViewModel : ViewModel
    {
        private List<LekarDTO> sviLekari;
        private LekariKontroler lekarKontroler = new LekariKontroler();
        private ZakazivanjePregledaDTO podaci;
        private String poruka;
        private DateTime preporuceniDatumOd;
        private DateTime preporuceniDatumDo;

        public ZakazivanjeViewModel(String korisnickoIme)
        {
            Podaci = new ZakazivanjePregledaDTO();
            Podaci.KorisnickoImePacijenta = korisnickoIme;
            Podaci.DatumOd = DateTime.Now.AddDays(1);
            Podaci.DatumDo = DateTime.Now.AddDays(3);
            UcitajUKolekciju();
            prikaziDatume = new RelayCommand(Prikazi);
        }



        private void UcitajUKolekciju()
        {
            SviLekari = new List<LekarDTO>();
            foreach (LekarDTO lekar in lekarKontroler.DobaviLekareOpstePrakse())
                SviLekari.Add(lekar);
        }
        private bool dostupno2=false;
        public DateTime PreporuceniDatumOd
        {
            get { return preporuceniDatumOd; }
            set
            {
                preporuceniDatumOd = value;
                OnPropertyChanged();
            }
        }
        private bool dostupno = false;
        public DateTime PreporuceniDatumDo
        {
            get { return preporuceniDatumDo; }
            set
            {
                preporuceniDatumDo = value;

                OnPropertyChanged();
            }
        }

        public bool Dostupno
        {
            get { return dostupno; }
            set
            {
                dostupno = value;
                OnPropertyChanged();
            }
        }
        public bool Dostupno2
        {
            get { return dostupno2; }
            set
            {
                dostupno2 = value;
                OnPropertyChanged();
            }
        }


        public List<LekarDTO> SviLekari
        {
            get { return sviLekari; }
            set
            {
                sviLekari = value;
                OnPropertyChanged();
            }
        }
        public ZakazivanjePregledaDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
        }


        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand prikaziDatume;

        public RelayCommand PrikaziDatume
        {
            get { return prikaziDatume; }
        }

       
        private void Prikazi()
        {

            if (Validacija())
            {
               
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazSlobodnihDatumaPacijent(Podaci));
            }



        }

        private bool Validacija()
        {
            
             DateTime? pocetak = Podaci.DatumOd;
             DateTime? kraj = Podaci.DatumDo;

             if (Podaci.IzabraniLekar == null || Podaci.Prioritet == -1 || !pocetak.HasValue || !kraj.HasValue)
             {
                 Poruka = "Popunite sva polja!";
                 return false;
             }
            else if (DateTime.Compare(Podaci.DatumOd.Date, DateTime.Now.Date) <= 0)
             {
                 Poruka = "Izaberite datum u budućnosti!";
                 return false;
             }
             else if (DateTime.Compare(Podaci.DatumOd.Date, Podaci.DatumDo.Date) >= 0)
             {
                 Poruka = "*Početni datum mora biti raniji od krajnjeg!";
                 return false;
             }

            return true;
        }
    }
}
