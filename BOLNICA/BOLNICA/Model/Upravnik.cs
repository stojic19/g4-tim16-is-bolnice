// File:    Upravnik.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class Upravnik

using System;

namespace Model
{
   public class Upravnik : Osoba
   {
        public Upravnik(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Pol = pol;
            this.AdresaStanovanja = adresa;
            this.Jmbg = jmbg;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.Lozinka = lozinka;
        }
    }
}