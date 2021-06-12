using Bolnica.DTO;
using Bolnica.Komande;
using Bolnica.Kontroler;
using Bolnica.SekretarFolder;
using Bolnica.View.AdminView;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bolnica.ViewModel.AdminViewModel
{
    public class DetaljiFeedbackaViewModel : ViewModel
    {
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private FeedbackDTO podaci;
        public DetaljiFeedbackaViewModel(string idFeedbacka)
        {
            Podaci = feedbackKontroler.PretraziPoId(idFeedbacka);
            odjavaKomanda = new RelayCommand(Odjava);
            nazadKomanda = new RelayCommand(Nazad);
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

        public void Nazad()
        {
            UserControl usc = null;
            GlavniProzorAdmin.getInstance().MainPanel.Children.Clear();

            usc = new PregledFeedbacka();
            GlavniProzorAdmin.getInstance().MainPanel.Children.Add(usc);
        }

        public void Odjava()
        {
            GlavniProzorAdmin.getInstance().Odjava();
        }

        private RelayCommand nazadKomanda;

        public RelayCommand NazadKomanda
        {
            get { return nazadKomanda; }
        }
        private RelayCommand odjavaKomanda;

        public RelayCommand OdjavaKomanda
        {
            get { return odjavaKomanda; }
        }
    }
}
