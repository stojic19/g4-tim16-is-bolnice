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
            if (feedback.Datum == null)
                feedback.Datum = DateTime.Now;

            return new FeedbackDTO(feedback.IdFeedbacka, feedback.IdOsobe, feedback.TipFunkcionalnosti.ToString(), feedback.FunkcionalnostiNaKojeSeOdnosi, feedback.TekstFeedbacka, feedback.Datum);
        }
        public Feedback FeedbackDTOUModel(FeedbackDTO feedback)
        {
            Enum.TryParse(feedback.TipFunkcionalnosti.ToLower(), out TipFunkcije tipFunkcije);

            if (feedback.Datum == null)
                feedback.Datum = DateTime.Now;
            return new Feedback(feedback.IdFeedbacka, feedback.IdOsobe, tipFunkcije, feedback.FunkcionalnostiNaKojeSeOdnosi, feedback.TekstFeedbacka, feedback.Datum);
        }
    }
}
