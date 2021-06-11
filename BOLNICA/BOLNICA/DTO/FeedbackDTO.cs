// File:    Feedback.cs
// Author:  aleks
// Created: Friday, June 11, 2021 0:20:58
// Purpose: Definition of Class Feedback

using System;
using System.Collections.Generic;

namespace Model
{
    public class FeedbackDTO
    {
        private string idFeedbacka;
        private string idOsobe;
        private string tipFunkcionalnosti;
        private string funkcionalnostiNaKojeSeOdnosi;
        private string tekstFeedbacka;

        public FeedbackDTO()
        {
            tekstFeedbacka = "";
            tipFunkcionalnosti = "";
            funkcionalnostiNaKojeSeOdnosi = "";
        }

        public FeedbackDTO(string idFeedbacka, string idOsobe, string tipFunkcionalnosti, string funkcionalnostiNaKojeSeOdnosi, string tekstFeedbacka)
        {
            this.IdFeedbacka = idFeedbacka;
            this.IdOsobe = idOsobe;
            this.TipFunkcionalnosti = tipFunkcionalnosti;
            this.FunkcionalnostiNaKojeSeOdnosi = funkcionalnostiNaKojeSeOdnosi;
            this.TekstFeedbacka = tekstFeedbacka;
        }

        public string IdFeedbacka { get => idFeedbacka; set => idFeedbacka = value; }
        public string IdOsobe { get => idOsobe; set => idOsobe = value; }

        public string TekstFeedbacka { get => tekstFeedbacka; set => tekstFeedbacka = value; }
        public string TipFunkcionalnosti { get => tipFunkcionalnosti; set => tipFunkcionalnosti = value; }
        public string FunkcionalnostiNaKojeSeOdnosi { get => funkcionalnostiNaKojeSeOdnosi; set => funkcionalnostiNaKojeSeOdnosi = value; }
    }
}