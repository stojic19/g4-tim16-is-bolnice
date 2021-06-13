// File:    Obavestenje.cs
// Author:  aleks
// Created: Saturday, April 10, 2021 23:01:27
// Purpose: Definition of Class Obavestenje

using System;
using System.ComponentModel;

namespace Model
{
    public class Obavestenje 
    {
        private string idObavestenja;
        private string naslov;
        private string tekst;
        private DateTime datum;
        private bool jeProcitano;
        private string idPrimaoca;

        public String IdObavestenja { get => idObavestenja; set => idObavestenja = value; }
        public String Naslov { get => naslov; set => naslov = value; }
        public String Tekst { get => tekst; set => tekst = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public bool JeProcitano { get => jeProcitano; set => jeProcitano = value; }
        public String IdPrimaoca { get => idPrimaoca; set => idPrimaoca = value; }

        public Obavestenje(string idObavestenja, string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            IdObavestenja = idObavestenja;
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum;
            JeProcitano = false;
            IdPrimaoca = idPrimaoca;
        }
        public Obavestenje(string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            IdObavestenja = generisiID();
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum;
            JeProcitano = false;
            IdPrimaoca = idPrimaoca;
        }
        public Obavestenje() { }

        private static string generisiID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}