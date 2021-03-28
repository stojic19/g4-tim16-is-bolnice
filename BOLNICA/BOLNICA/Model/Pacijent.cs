// File:    Pacijent.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class Pacijent

using System;
using System.ComponentModel;

namespace Model
{
   public class Pacijent : Osoba, INotifyPropertyChanged
    {
      public String korisnickoIme { get; set; }

        public Pacijent(string korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
        }
        public Pacijent(string korisnickoIme, string ime, string prezime, DateTime datum, string jmbg, string adresa, string telefon, string email)
        {
            this.korisnickoIme = korisnickoIme;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datum;
            this.adresaStanovanja = adresa;
            this.jmbg = jmbg;
            this.kontaktTelefon = telefon;
            this.email = email;
            this.uloga = Uloge.pacijent;
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