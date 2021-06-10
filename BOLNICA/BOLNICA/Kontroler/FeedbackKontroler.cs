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

        public List<Feedback> DobaviSve()
        {
            return feedbackServis.DobaviSve();
        }

        public void Dodaj(Feedback feedback)
        {
            feedbackServis.Dodaj(feedback);
        }

        public void Izmeni(Feedback feedback)
        {
            feedbackServis.Izmeni(feedback);
        }

        public Feedback PretraziPoId(string id)
        {
            return feedbackServis.PretraziPoId(id);
        }

        public void Ukloni(Feedback feedback)
        {
            feedbackServis.Ukloni(feedback);
        }
    }
}
