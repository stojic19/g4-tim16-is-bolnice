// File:    RukovanjeProstorom.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class RukovanjeProstorom

using System;
using System.Collections.Generic;

namespace Model
{
    public class RukovanjeProstorom
    {
        private String imeFajla;
        public static List<Prostor> prostori = new List<Prostor>();
        public Prostor DodajProstor(Prostor p)
        {
            throw new NotImplementedException();
        }

        public Boolean IzmeniProstor(String idProstora)
        {
            throw new NotImplementedException();
        }

        public Boolean UkloniProstor(String idProstora)
        {
            throw new NotImplementedException();
        }

        public Prostor PretraziPoId(String idProstora)
        {
            throw new NotImplementedException();
        }

        public static List<Prostor> SviProstori()
        {
            return prostori;
        }

    }
}