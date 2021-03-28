using System;

namespace Model
{
    public class Lekar : Osoba
    {
        public String KorisnickoIme { get; set; }
        public SpecijalizacijeLekara specijalizacija = SpecijalizacijeLekara.nema;
        public Boolean dostupnost = false;
        public Lekar() { }
        public Lekar(string korisnickoIme)
        {
            this.KorisnickoIme = korisnickoIme;
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