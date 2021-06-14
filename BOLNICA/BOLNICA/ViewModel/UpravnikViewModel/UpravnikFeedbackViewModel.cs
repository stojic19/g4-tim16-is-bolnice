using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.UpravnikFolder;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace Bolnica.ViewModel.UpravnikViewModel
{
    public class UpravnikFeedbackViewModel : ViewModel
    {
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private String poruka;
        private FeedbackDTO podaci;
        private List<String> tipovi;
        private List<String> funkcionalnosti;

        public UpravnikFeedbackViewModel()
        {
            Podaci = new FeedbackDTO();
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
            Funkcionalnosti.Add("Prikaz prostora");
            Funkcionalnosti.Add("Dodavanje prostora");
            Funkcionalnosti.Add("Izmjena prostora");
            Funkcionalnosti.Add("Uklanjanje prostora");
            Funkcionalnosti.Add("Raspored opreme");
            Funkcionalnosti.Add("Prikaz opreme");
            Funkcionalnosti.Add("Dodavanje opreme");
            Funkcionalnosti.Add("Izmjena opreme");
            Funkcionalnosti.Add("Uklanjanje opreme");
            Funkcionalnosti.Add("Prikaz lijekova");
            Funkcionalnosti.Add("Zahtjevi za odobrenje lijeka");
            Funkcionalnosti.Add("Dodavanje zahtjeva");
            Funkcionalnosti.Add("Izmjena zahtjeva");
            Funkcionalnosti.Add("Uklanjanje zahtjeva");
            Funkcionalnosti.Add("Renoviranje");
            Funkcionalnosti.Add("Dodavanje opreme prostoru");
            Funkcionalnosti.Add("Premjestanje opreme");
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
                feedbackKontroler.Dodaj(Podaci);
                System.Windows.MessageBox.Show("Problem uspjesno prijavljen. Hvala na pomoci!"); 

                UserControl usc = null;
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Clear();

                usc = new PrikazProstora();
                UpravnikGlavniProzor.getInstance().MainPanel.Children.Add(usc);
            }
        }
        private bool IspravniUnetiPodaci()
        {
            if (Podaci.TekstFeedbacka.Equals(""))
            {
                System.Windows.MessageBox.Show("Morate uneti tekst feedback-a!"); 
                return false;
            }
            return true;
        }
    }
}
