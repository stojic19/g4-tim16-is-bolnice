// File:    Pacijent.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class Pacijent

using System;

namespace Model
{
   public class Pacijent : Osoba
   {
      public String korisnickoIme { get; set; }

        public Pacijent(string korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
        }
    }
}