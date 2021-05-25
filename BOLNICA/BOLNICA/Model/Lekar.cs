using Bolnica.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Lekar : Osoba
    {
        private List<RadniDan> RadniDani { get; set; }

        private Godisnji Godisnji { get; set; }

        private List<Odsustvo> Odsustvo { get; set; }

        public SpecijalizacijeLekara specijalizacija { get; set; } = SpecijalizacijeLekara.nema;
        public Boolean dostupnost { get; set; } = false;
        public Lekar() { }

        public Lekar(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka, SpecijalizacijeLekara specijalizacija)
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
            this.specijalizacija = specijalizacija;
        }

        public Lekar(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
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

            RadniDani = new List<RadniDan>();
            Godisnji = new Godisnji(DateTime.Now.Year, 20);
            Odsustvo = new List<Odsustvo>();
        }

        public Lekar(string korisnickoIme, string ime, string prezime)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
        }


        public Lekar(string korisnickoIme, SpecijalizacijeLekara specijalizacija, bool dostupnost)
        {
            this.KorisnickoIme = korisnickoIme;
            this.specijalizacija = specijalizacija;
            this.dostupnost = dostupnost;
        }

    }
}