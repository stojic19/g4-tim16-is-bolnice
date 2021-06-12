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
    public class AdminFeedbackViewModel : ViewModel
    {
        private ObservableCollection<FeedbackDTO> feedbacks;
        private FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        private FeedbackDTO selektovaniFeedback;
        private String poruka;
        public AdminFeedbackViewModel()
        {
            UcitajUKolekciju();
            selektovaniFeedback = new FeedbackDTO();
            odjavaKomanda = new RelayCommand(Odjava);
            pregledKomanda = new RelayCommand(Pregled);
            ukloniKomanda = new RelayCommand(Ukloni);
        }

        public void UcitajUKolekciju()
        {
            Feedbacks = new ObservableCollection<FeedbackDTO>();
            foreach (FeedbackDTO feedback in feedbackKontroler.DobaviSve())
            {
                Feedbacks.Add(feedback);
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }
        public FeedbackDTO SelektovaniFeedback
        {
            get { return selektovaniFeedback; }
            set
            {
                selektovaniFeedback = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FeedbackDTO> Feedbacks
        {
            get { return feedbacks; }
            set
            {
                feedbacks = value;
                OnPropertyChanged();
            }
        }

        public void Ukloni()
        {
            if (SelektovaniFeedback != null)
            {
                UserControl usc = null;
                GlavniProzorAdmin.getInstance().MainPanel.Children.Clear();

                usc = new UklanjanjeFeedbacka(selektovaniFeedback.IdFeedbacka);
                GlavniProzorAdmin.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati feedback za uklanjanje!";
            }

        }

        public void Pregled()
        {
            if (SelektovaniFeedback != null)
            {
                UserControl usc = null;
                GlavniProzorAdmin.getInstance().MainPanel.Children.Clear();

                usc = new DetaljiFeedbackaAdmin(selektovaniFeedback.IdFeedbacka);
                GlavniProzorAdmin.getInstance().MainPanel.Children.Add(usc);
            }
            else
            {
                Poruka = "*Morate izabrati feedback za pregled!";
            }
        }

        public void Odjava()
        {
            GlavniProzorAdmin.getInstance().Odjava();
        }

        private RelayCommand pregledKomanda;

        public RelayCommand PregledKomanda
        {
            get { return pregledKomanda; }
        }
        private RelayCommand ukloniKomanda;

        public RelayCommand UkloniKomanda
        {
            get { return ukloniKomanda; }
        }
        private RelayCommand odjavaKomanda;

        public RelayCommand OdjavaKomanda
        {
            get { return odjavaKomanda; }
        }
    }
}
