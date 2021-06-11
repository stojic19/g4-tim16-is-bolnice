
using Bolnica;
using Model;
using System;
using System.ComponentModel;

namespace Bolnica.Model
{
   public class Sekretar : Osoba
   {
        Sekretar() { }
        public Sekretar(string idOsobe, string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
        {
            if (idOsobe == null)
                this.IdOsobe = Guid.NewGuid().ToString();
            else
                this.IdOsobe = idOsobe;
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