using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    public class FeedbackRepozitorijum : GlavniRepozitorijum<Feedback>, FeedbackRepozitorijumInterfejs
    {
        public FeedbackRepozitorijum()
        {
            imeFajla = "feedback.xml";
        }
        public void Izmeni(Feedback feedback)
        {
            ObrisiObjekat("//ArrayOfFeedback/Feedback[IdFeedbacka='" + feedback.IdFeedbacka + "']");
            DodajObjekat(feedback);
        }
    }
}
