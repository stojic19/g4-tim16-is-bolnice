// File:    Prostor.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class Prostor

using System;

namespace Model
{
    public class Prostor
    {
        public String IdProstora { get; set; }
        public VrsteProstora vrstaProstora;
        public int sprat;
        public float kvadratura;
        public int brojKreveta;

    public Prostor(string idProstora, VrsteProstora vrstaProstora)
        {
            IdProstora = idProstora;
            this.vrstaProstora = vrstaProstora;
        }
    }
}