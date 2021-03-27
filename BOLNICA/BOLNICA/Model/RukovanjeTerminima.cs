// File:    RukovanjeTerminima.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class RukovanjeTerminima

using Bolnica;
using System;
using System.Collections.Generic;

namespace Model
{
    public class RukovanjeTerminima
    {
        private String imeFajla;

        public static Termin ZakaziTermin(Termin t)
        {
            sviTermini.Add(t);
            PrikazTerminaLekara.Termini.Add(t);

            if (sviTermini.Contains(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public Boolean OtkaziTermin(String idTermina)
        {
            throw new NotImplementedException();
        }

        public Boolean IzmeniTermin(String idTermina)
        {
            throw new NotImplementedException();
        }

        public Termin PretraziPoId(String idTermina)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoLekaru(String korImeLekara)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoProstoriji(String idProstorije)
        {
            throw new NotImplementedException();
        }

        public List<Termin> PretraziPoPacijentu(String korImePacijenta)
        {
            throw new NotImplementedException();
        }

        public static List<Termin> DobaviSveTermine()
        {
            return sviTermini;
        }

        public static List<Termin> sviTermini = new List<Termin>();

    }
}