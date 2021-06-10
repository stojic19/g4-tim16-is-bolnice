using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class FeedbackKonverter
    {
        public FeedbackDTO FeedbackModelUDTO(Feedback feedback)
        {
            return new FeedbackDTO(feedback.IdFeedbacka, feedback.IdOsobe, feedback.TipGreske, feedback.TekstFeedbacka);
        }
        public Feedback FeedbackDTOUModel(FeedbackDTO feedback)
        {
            return new Feedback(feedback.IdFeedbacka, feedback.IdOsobe, feedback.TipGreske, feedback.TekstFeedbacka);
        }
    }
}
