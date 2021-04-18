using System;

namespace Model
{
    public class Lekar : Osoba
    {
        public SpecijalizacijeLekara specijalizacija = SpecijalizacijeLekara.nema;
        public Boolean dostupnost = false;
        public Lekar() { }

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

        public SpecijalizacijeLekara getSpecijalizacija()
        {
            return this.specijalizacija;
        }

        public void setSpecijalizacija(SpecijalizacijeLekara sLekara)
        {
            this.specijalizacija = sLekara;
        }

        public Boolean getDostupnost()
        {
            return this.dostupnost;
        }

        public void setDostupnost(Boolean dostupnost)
        {
            this.dostupnost = dostupnost;
        }

    }
}