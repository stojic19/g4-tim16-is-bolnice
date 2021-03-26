// File:    RukovanjeTerminima.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class RukovanjeTerminima

using System;
using System.Collections.Generic;

namespace Model
{
    public class RukovanjeTerminima
    {
        private String imeFajla;

        public Termin ZakaziTermin(Termin t)
        {
            throw new NotImplementedException();
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

        public List<Termin> DobaviSveTermine()
        {
            throw new NotImplementedException();
        }

        public List<Termin> sviTermini;

    }
}