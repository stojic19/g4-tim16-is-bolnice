using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class OsobaDTO
    {
        private String ime;
        private String prezime;
        private DateTime datumRodjenja;
        private String jmbg;
        private String adresaStanovanja;
        private String kontaktTelefon;
        private String email;
        private String korisnickoIme;
        private String lozinka;
        private Pol pol;

        public String Ime { get => ime; set => ime = value; }
        public String Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public String Jmbg { get => jmbg; set => jmbg = value; }
        public String AdresaStanovanja { get => adresaStanovanja; set => adresaStanovanja = value; }
        public String KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public String Email { get => email; set => email = value; }

        public String KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public String Lozinka { get => lozinka; set => lozinka = value; }

        public OsobaDTO(string ime, string prezime, DateTime datumRodjenja, string jmbg, string adresaStanovanja, string kontaktTelefon, string email, string korisnickoIme, string lozinka, Pol pol)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.jmbg = jmbg;
            this.adresaStanovanja = adresaStanovanja;
            this.kontaktTelefon = kontaktTelefon;
            this.email = email;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.pol = pol;
        }
        public OsobaDTO() { }
    }
}
