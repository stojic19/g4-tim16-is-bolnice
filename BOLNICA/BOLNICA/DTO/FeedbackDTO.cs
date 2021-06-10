// File:    Feedback.cs
// Author:  aleks
// Created: Friday, June 11, 2021 0:20:58
// Purpose: Definition of Class Feedback

using System;

namespace Model
{
    public class FeedbackDTO
    {
        private string idFeedbacka;
        private string idOsobe;
        private TipGreske tipGreske;
        private string tekstFeedbacka;

        public FeedbackDTO()
        {
        }

        public FeedbackDTO(string idFeedbacka, string idOsobe, TipGreske tipGreske, string tekstFeedbacka)
        {
            this.IdFeedbacka = idFeedbacka;
            this.IdOsobe = idOsobe;
            this.TipGreske = tipGreske;
            this.TekstFeedbacka = tekstFeedbacka;
        }

        public string IdFeedbacka { get => idFeedbacka; set => idFeedbacka = value; }
        public string IdOsobe { get => idOsobe; set => idOsobe = value; }
        public TipGreske TipGreske { get => tipGreske; set => tipGreske = value; }
        public string TekstFeedbacka { get => tekstFeedbacka; set => tekstFeedbacka = value; }
    }
}