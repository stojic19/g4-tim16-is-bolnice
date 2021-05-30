using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class LekarDTO : OsobaDTO
    {
        private String imeIPrezime;
        private SpecijalizacijeLekara specijalizacija;

        public String ImeIPrezime
        {
            get { return imeIPrezime; }
            set { imeIPrezime = value; }
        }
        public SpecijalizacijeLekara Specijalizacija
        {
            get { return specijalizacija; }
            set { specijalizacija = value; }
        }

        public LekarDTO(string imeIPrezimeLekara, string korisnickoIme, SpecijalizacijeLekara specijalizacija)
        {
            this.imeIPrezime = imeIPrezimeLekara;
            this.KorisnickoIme = korisnickoIme;
            this.specijalizacija = specijalizacija;
        }

        public LekarDTO(string korisnickoIme, string lozinka)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
        }

        public LekarDTO(string korisnickoIme)
        {
            this.KorisnickoIme = korisnickoIme;
        }

        public LekarDTO(string ime, string prezime, string jmbg, string korisnickoIme)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.KorisnickoIme = korisnickoIme;
        }
    }
}
