using Bolnica.Interfejsi.Sekretar;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class FeedbackServis : CRUDInterfejs<Feedback>
    {
        private FeedbackRepozitorijumInterfejs feedbackRepozitorijum = new FeedbackRepozitorijum();

        public List<Feedback> DobaviSve()
        {
            return feedbackRepozitorijum.DobaviSveObjekte();
        }

        public void Dodaj(Feedback feedback)
        {
            feedbackRepozitorijum.DodajObjekat(feedback);
        }

        public void Izmeni(Feedback feedback)
        {
            feedbackRepozitorijum.Izmeni(feedback);
        }

        public Feedback PretraziPoId(string id)
        {
            return feedbackRepozitorijum.PretraziPoId("//ArrayOfFeedback/Feedback[IdFeedbacka='" + id + "']");
        }

        public void Ukloni(Feedback feedback)
        {
            feedbackRepozitorijum.ObrisiObjekat("//ArrayOfFeedback/Feedback[IdFeedbacka='" + feedback.IdFeedbacka + "']");
        }
    }
}
