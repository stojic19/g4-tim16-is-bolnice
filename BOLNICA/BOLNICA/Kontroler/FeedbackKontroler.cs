using Bolnica.Konverter;
using Bolnica.Servis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    class FeedbackKontroler
    {
        FeedbackServis feedbackServis = new FeedbackServis();
        FeedbackKonverter feedbackKonverter = new FeedbackKonverter();
        public List<FeedbackDTO> DobaviSve()
        {
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
            foreach(Feedback feedback in feedbackServis.DobaviSve())
            {
                feedbacks.Add(feedbackKonverter.FeedbackModelUDTO(feedback));
            }
            return feedbacks;
        }

        public void Dodaj(FeedbackDTO feedback)
        {
            feedbackServis.Dodaj(feedbackKonverter.FeedbackDTOUModel(feedback));
        }

        public void Izmeni(FeedbackDTO feedback)
        {
            feedbackServis.Izmeni(feedbackKonverter.FeedbackDTOUModel(feedback));
        }

        public FeedbackDTO PretraziPoId(string id)
        {
            return feedbackKonverter.FeedbackModelUDTO(feedbackServis.PretraziPoId(id));
        }

        public void Ukloni(FeedbackDTO feedback)
        {
            feedbackServis.Ukloni(feedbackKonverter.FeedbackDTOUModel(feedback));
        }
    }
}
