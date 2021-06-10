
using System;
using System.ComponentModel;

namespace Model
{
    public class Osoba
    {
        private string idOsobe;
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string jmbg;
        private string adresaStanovanja;
        private string kontaktTelefon;
        private string email;
        private string korisnickoIme;
        private string lozinka;
        private Pol pol;

        public String IdOsobe { get => idOsobe; set => idOsobe = value; }
        public String Ime { get => ime; set => ime = value; }
        public String Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public String Jmbg { get => jmbg; set => jmbg = value; }
        public String AdresaStanovanja { get => adresaStanovanja; set => adresaStanovanja = value; }
        public String KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public String Email { get => email; set => email = value; }

        public String KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public String Lozinka { get => lozinka; set => lozinka = value; }

        public Pol Pol { get => pol; set => pol = value; }

        public Osoba(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
        {
            this.IdOsobe = generisiID();
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

        public Osoba() { }

        private string generisiID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}