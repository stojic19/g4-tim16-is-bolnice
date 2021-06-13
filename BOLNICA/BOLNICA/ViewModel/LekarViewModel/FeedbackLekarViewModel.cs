using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.ViewModel.LekarViewModel
{
    public class FeedbackLekarViewModel : ViewModel
    {
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private LekariKontroler lekariKontroler = new LekariKontroler();
        private FeedbackDTO podaci;
        private List<String> tipovi;
        private List<String> funkcionalnosti;
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

        public FeedbackLekarViewModel()
        {
            Podaci = new FeedbackDTO();
            Podaci.IdFeedbacka = Guid.NewGuid().ToString();
            Podaci.IdOsobe = lekariKontroler.DobaviId(LekarGlavniProzor.DobaviKorisnickoIme());
            UcitajTipove();
            UcitajFunkcionalnosti();
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
        }

        private void UcitajTipove()
        {
            Tipovi = new List<String>();
            Tipovi.Add("Interfejs");
            Tipovi.Add("Funkcionalnost");
            Tipovi.Sort();
        }

        private void UcitajFunkcionalnosti()
        {
            Funkcionalnosti = new List<String>();
            Funkcionalnosti.Add("Pregled baze lekova");
            Funkcionalnosti.Add("Izmena leka");
            Funkcionalnosti.Add("Izmena zamenskih lekova");
            Funkcionalnosti.Add("Verifikacija lekova");
            Funkcionalnosti.Add("Pregled rasporeda");
            Funkcionalnosti.Add("Zakazivanje termina");
            Funkcionalnosti.Add("Izmena termina");
            Funkcionalnosti.Add("Otkazivanje termina");
            Funkcionalnosti.Add("Pregled kartona");
            Funkcionalnosti.Add("Dodavanje anamneze");
            Funkcionalnosti.Add("Generisanje izveštaja anamneza");
            Funkcionalnosti.Add("Dodavanje recepta");
            Funkcionalnosti.Add("Generisanje izveštaja recepata");
            Funkcionalnosti.Add("Izdavanje uputa");
            Funkcionalnosti.Add("Prevod");
            Funkcionalnosti.Add("Promena teme");
            Funkcionalnosti.Sort();
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


        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        public void Potvrdi()
        {
            if (IspravniUnetiPodaci())
            {
                podaci.Datum = DateTime.Now;
                feedbackKontroler.Dodaj(podaci);

                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
                LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PocetnaStranicaLekar());
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

        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
        }
        public void Odustani()
        {
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Clear();
            LekarGlavniProzor.DobaviProzorZaIzmenu().Children.Add(new PocetnaStranicaLekar());
        }
    }
}
