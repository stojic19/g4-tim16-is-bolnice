// File:    Obavestenje.cs
// Author:  aleks
// Created: Saturday, April 10, 2021 23:01:27
// Purpose: Definition of Class Obavestenje

using System;
using System.ComponentModel;

namespace Model
{
    public class Obavestenje : INotifyPropertyChanged
    {
      public String IdObavestenja { get; set; }
        public String Naslov { get; set; }
        public String Tekst { get; set; }
        public DateTime Datum { get; set; }
        public bool JeProcitano { get; set; }

        public String IdPrimaoca { get; set; }

        public Obavestenje(string idObavestenja, string naslov, string tekst, DateTime datum,string idPrimaoca)
        {
            IdObavestenja = idObavestenja;
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum;
            JeProcitano = false;
            IdPrimaoca = idPrimaoca;
        }
       
        public Obavestenje() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}