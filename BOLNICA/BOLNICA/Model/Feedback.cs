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
        private List<TipFunkcije> tipFunkcionalnosti;
        private List<string> funkcionalnostiNaKojeSeOdnosi;
        private string tekstFeedbacka;

        public Feedback() { }
        public Feedback(string idFeedbacka, string idOsobe, List<TipFunkcije> tipFunkcionalnosti, List<string> funkcionalnostiNaKojeSeOdnosi, string tekstFeedbacka)
        {
            this.IdFeedbacka = idFeedbacka;
            this.IdOsobe = idOsobe;
            this.TipFunkcionalnosti = tipFunkcionalnosti;
            this.TekstFeedbacka = tekstFeedbacka;
            this.FunkcionalnostiNaKojeSeOdnosi = funkcionalnostiNaKojeSeOdnosi;
        }

        public string IdFeedbacka { get => idFeedbacka; set => idFeedbacka = value; }
        public string IdOsobe { get => idOsobe; set => idOsobe = value; }
        public string TekstFeedbacka { get => tekstFeedbacka; set => tekstFeedbacka = value; }
        public List<TipFunkcije> TipFunkcionalnosti { get => tipFunkcionalnosti; set => tipFunkcionalnosti = value; }
        public List<string> FunkcionalnostiNaKojeSeOdnosi { get => funkcionalnostiNaKojeSeOdnosi; set => funkcionalnostiNaKojeSeOdnosi = value; }
    }
}