using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
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
    public class DodavanjeFeedbackaViewModel : SekretarViewModel
    {
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private String poruka;
        private FeedbackDTO podaci;
        private List<String> tipovi;
        private List<String> funkcionalnosti;

        public DodavanjeFeedbackaViewModel()
        {
            Podaci = new FeedbackDTO();
            Podaci.IdFeedbacka = Guid.NewGuid().ToString();
            potvrdiKomanda = new RelayCommand(Potvrdi);
            odustaniKomanda = new RelayCommand(Odustani);
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
                feedbackKontroler.Dodaj(podaci);

                UserControl usc = null;
                GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

                usc = new PrikazNalogaSekretar();
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
        private RelayCommand odustaniKomanda;

        public RelayCommand OdustaniKomanda
        {
            get { return odustaniKomanda; }
        }
        public void Odustani()
        {
            UserControl usc = null;
            GlavniProzorSekretar.getInstance().MainPanel.Children.Clear();

            usc = new GlavniProzorSadrzaj();
            GlavniProzorSekretar.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
