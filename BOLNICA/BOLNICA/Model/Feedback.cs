// File:    Feedback.cs
// Author:  aleks
// Created: Friday, June 11, 2021 0:20:58
// Purpose: Definition of Class Feedback

using System;
using System.Collections.Generic;

namespace Model
{
    public class Feedback
    {
        private string idFeedbacka;
        private string idOsobe;
        private TipFunkcije tipFunkcionalnosti;
        private string funkcionalnostiNaKojeSeOdnosi;
        private string tekstFeedbacka;
        private DateTime datum;
        public Feedback() { }
        public Feedback(string idFeedbacka, string idOsobe, TipFunkcije tipFunkcionalnosti, string funkcionalnostiNaKojeSeOdnosi, string tekstFeedbacka, DateTime datum)
        {
            this.IdFeedbacka = idFeedbacka;
            this.IdOsobe = idOsobe;
            this.TipFunkcionalnosti = tipFunkcionalnosti;
            this.TekstFeedbacka = tekstFeedbacka;
            this.FunkcionalnostiNaKojeSeOdnosi = funkcionalnostiNaKojeSeOdnosi;
            this.Datum = datum;
        }

        public string IdFeedbacka { get => idFeedbacka; set => idFeedbacka = value; }
        public string IdOsobe { get => idOsobe; set => idOsobe = value; }
        public string TekstFeedbacka { get => tekstFeedbacka; set => tekstFeedbacka = value; }
        public TipFunkcije TipFunkcionalnosti { get => tipFunkcionalnosti; set => tipFunkcionalnosti = value; }
        public string FunkcionalnostiNaKojeSeOdnosi { get => funkcionalnostiNaKojeSeOdnosi; set => funkcionalnostiNaKojeSeOdnosi = value; }
        public DateTime Datum { get => datum; set => datum = value; }
    }
}