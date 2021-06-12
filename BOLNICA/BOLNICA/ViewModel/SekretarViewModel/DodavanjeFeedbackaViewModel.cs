using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.SekretarViewModel
{
    public class DodavanjeFeedbackaViewModel : PotvrdiOdustaniViewModel
    {
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private FeedbackDTO podaci;
        private List<String> tipovi;
        private List<String> funkcionalnosti;

        public DodavanjeFeedbackaViewModel()
        {
            Podaci = new FeedbackDTO();
            Podaci.IdFeedbacka = Guid.NewGuid().ToString();
            Podaci.IdOsobe = GlavniProzorSekretar.getInstance().getSekretar().IdOsobe;
            UcitajTipove();
            UcitajFunkcionalnosti();
            PotvrdiKomanda = new RelayCommand(Potvrdi);
            OdustaniKomanda = new RelayCommand(Odustani);
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
            Funkcionalnosti.Add("Alergeni");
            Funkcionalnosti.Add("Lična obaveštenja");
            Funkcionalnosti.Add("Nalozi");
            Funkcionalnosti.Add("Naplata usluge");
            Funkcionalnosti.Add("Obaveštenja");
            Funkcionalnosti.Add("Hitna operacija");
            Funkcionalnosti.Add("Pomoć");
            Funkcionalnosti.Add("Pregledi");
            Funkcionalnosti.Add("Raspored lekara");
            Funkcionalnosti.Add("Stacionarno lečenje");
            Funkcionalnosti.Add("Transfer pacijenata");
            Funkcionalnosti.Add("Moj nalog");
            Funkcionalnosti.Add("Izveštaj");
            Funkcionalnosti.Add("Demo");
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

        public override void Potvrdi()
        {
            if (IspravniUnetiPodaci())
            {
                podaci.Datum = DateTime.Now;
                feedbackKontroler.Dodaj(podaci);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new GlavniProzorSadrzaj();
                GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
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

        public override void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
