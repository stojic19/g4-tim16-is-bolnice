using Bolnica.Kontroler;
using Bolnica.View.AdminView;
using Bolnica.ViewModel.SekretarViewModel.AbstractKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.ViewModel.AdminViewModel
{
    public class UklanjanjeFeedbackaViewModel : PotvrdiOdustaniViewModel
    {
        FeedbackKontroler feedbackKontroler = new FeedbackKontroler();
        string idFeedbacka;
        public UklanjanjeFeedbackaViewModel(string idFeedbacka)
        {
            this.idFeedbacka = idFeedbacka;
        }
        public override void Odustani()
        {
            UserControl usc = null;
            GlavniProzorAdmin.getInstance().MainPanel.Children.Clear();

            usc = new PregledFeedbacka();
            GlavniProzorAdmin.getInstance().MainPanel.Children.Add(usc);
        }

        public override void Potvrdi()
        {
            feedbackKontroler.Ukloni(feedbackKontroler.PretraziPoId(idFeedbacka));

            UserControl usc = null;
            GlavniProzorAdmin.getInstance().MainPanel.Children.Clear();

            usc = new PregledFeedbacka();
            GlavniProzorAdmin.getInstance().MainPanel.Children.Add(usc);
        }
    }
}
