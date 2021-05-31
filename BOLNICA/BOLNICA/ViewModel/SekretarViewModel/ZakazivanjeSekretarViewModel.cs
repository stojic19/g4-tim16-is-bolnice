using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.Sekretar.Pregled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class ZakazivanjeSekretarViewModel : ViewModel
    {
        private List<PacijentDTO> sviPacijenti;
        private List<LekarDTO> sviLekari;
        private LekariKontroler lekarKontroler = new LekariKontroler();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private ZakazivanjePregledaDTO podaci;
        private PacijentDTO izabranPacijent;
        private String poruka;

        public ZakazivanjeSekretarViewModel(String korisnickoIme)
        {
            Podaci = new ZakazivanjePregledaDTO();
            Podaci.KorisnickoImePacijenta = korisnickoIme;
            podaci.DatumOd = DateTime.Now.AddDays(1).Date;
            podaci.DatumDo = DateTime.Now.AddDays(3).Date;
            UcitajUKolekciju();
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
        }
        private void UcitajUKolekciju()
        {
            SviLekari = new List<LekarDTO>();
            foreach (LekarDTO lekar in lekarKontroler.DobaviLekareOpstePrakse())
                SviLekari.Add(lekar);

            SviPacijenti = new List<PacijentDTO>();
            foreach (PacijentDTO pacijent in naloziPacijenataKontroler.DobaviSveNaloge())
                SviPacijenti.Add(pacijent);
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
        public List<PacijentDTO> SviPacijenti
        {
            get { return sviPacijenti; }
            set
            {
                sviPacijenti = value;
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

        public PacijentDTO IzabranPacijent
        {
            get { return izabranPacijent; }
            set
            {
                izabranPacijent = value;
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

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }

       
        private void Potvrdi()
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

            if (IzabranPacijent == null || Podaci.IzabraniLekar == null || Podaci.Prioritet == -1 || !pocetak.HasValue || !kraj.HasValue)
            {
                Poruka = "*Popunite sva polja!";
                return false;
            }
           else if (DateTime.Compare(Podaci.DatumOd.Date, DateTime.Now.Date) <= 0)
            {
                Poruka = "*Izaberite datum u budućnosti!";
                return false;
            }
            else if (DateTime.Compare(Podaci.DatumOd.Date, Podaci.DatumDo.Date) >= 0)
            {
                Poruka = "*Početni datum mora biti raniji od krajnjeg!";
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

            usc = new TerminiPregledaSekretar();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
