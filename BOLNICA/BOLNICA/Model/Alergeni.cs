// File:    Alergeni.cs
// Author:  aleks
// Created: Saturday, April 10, 2021 15:02:54
// Purpose: Definition of Class Alergeni

using System;
using System.ComponentModel;

namespace Model
{
   public class Alergeni
   {
        public String IdAlergena { get; set; }
        public String OpisReakcije { get; set; }
        public String VremeZaPojavu { get; set; }
        public Alergeni() { }
        public Alergeni(string idAlergena, string opisReakcije, string vremeZaPojavu)
        {
            IdAlergena = idAlergena;
            OpisReakcije = opisReakcije;
            VremeZaPojavu = vremeZaPojavu;
        }
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