using Bolnica.Komande;
using Bolnica.Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.PacijentViewModel
{
    public class OcenaAplikacijeViewModel: ViewModel
    {
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private String poruka;
        private FeedbackDTO podaci;
        private List<String> tipovi;
        private List<String> funkcionalnosti;
        private String korisnickoIme;
        public OcenaAplikacijeViewModel(String korisnickoIme)
        {
            Podaci = new FeedbackDTO();
            this.korisnickoIme = korisnickoIme;
            UcitajTipove();
            UcitajFunkcionalnosti();
            potvrdiKomanda = new RelayCommand(Potvrdi);
        }

        private void UcitajTipove()
        {
            Tipovi = new List<String>();
            Tipovi.Add("Izgled aplikacije");
            Tipovi.Add("Rad aplikacije");
            Tipovi.Sort();
        }

        private void UcitajFunkcionalnosti()
        {
            Funkcionalnosti = new List<String>();
            Funkcionalnosti.Add("Lični profil");
            Funkcionalnosti.Add("Lična obaveštenja");
            Funkcionalnosti.Add("Zakazivanje termina");
            Funkcionalnosti.Add("Pomeranje termina");
            Funkcionalnosti.Add("Otkazivanje termina");
            Funkcionalnosti.Add("Terapija");
            Funkcionalnosti.Add("Beleške");
            Funkcionalnosti.Add("Podestnik");
            Funkcionalnosti.Add("Izveštaj");
            Funkcionalnosti.Add("Ankete");
            Funkcionalnosti.Add("Pomoć");
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

        public List<String> Funkcionalnosti
        {
            get { return funkcionalnosti; }
            set
            {
                funkcionalnosti = value;
                OnPropertyChanged();
            }
        }
        public List<String> Tipovi
        {
            get { return tipovi; }
            set
            {
                tipovi = value;
                OnPropertyChanged();
            }
        }
        public FeedbackDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
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
                Podaci.IdFeedbacka = Guid.NewGuid().ToString();
                Podaci.IdOsobe = korisnickoIme;
                feedbackKontroler.Dodaj(Podaci);
                Poruka = "Problem uspešno prijavljen. Hvala na pomoći!";

            }
        }
        private bool IspravniUnetiPodaci()
        {
            if (Podaci.TekstFeedbacka.Equals(""))
            {
                Poruka = "Morate uneti tekst feedback-a!";
                return false;
            }
            return true;
        }
    }
}
