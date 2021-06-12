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
            List<string> tipovi = new List<string>();
            if(feedback.TipFunkcionalnosti.Count() > 0)
            foreach (TipFunkcije tipFunkcije in feedback.TipFunkcionalnosti)
            {
                tipovi.Add(tipFunkcije.ToString());
            }
            if (feedback.Datum == null)
                feedback.Datum = DateTime.Now;
            return new FeedbackDTO(feedback.IdFeedbacka, feedback.IdOsobe, null, null, feedback.TekstFeedbacka, feedback.Datum);
        }
        public Feedback FeedbackDTOUModel(FeedbackDTO feedback)
        {
            List<TipFunkcije> tipovi = new List<TipFunkcije>();
            if(feedback.TipFunkcionalnosti != null)
            { 
                Enum.TryParse(feedback.TipFunkcionalnosti.ToLower(), out TipFunkcije tipFunkcije);
                tipovi.Add(tipFunkcije);
            }
            List<string> funkcije = new List<string>();
            funkcije.Add(feedback.FunkcionalnostiNaKojeSeOdnosi);
            if (feedback.Datum == null)
                feedback.Datum = DateTime.Now;
            return new Feedback(feedback.IdFeedbacka, feedback.IdOsobe, tipovi, funkcije, feedback.TekstFeedbacka, feedback.Datum);
        }
    }
}
