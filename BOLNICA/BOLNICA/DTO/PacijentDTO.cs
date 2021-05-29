using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class PacijentDTO : OsobaDTO
    {
        private VrsteNaloga vrstaNaloga;
        KartonPacijentaDTO karton;

        public VrsteNaloga VrstaNaloga { get => vrstaNaloga; set => vrstaNaloga = value; }

        public PacijentDTO(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, VrsteNaloga vrstaNaloga, string lozinka)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Jmbg = jmbg;
            this.AdresaStanovanja = adresa;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Pol = pol;
            this.VrstaNaloga = vrstaNaloga;
        }
        public PacijentDTO(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, VrsteNaloga vrstaNaloga)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Jmbg = jmbg;
            this.AdresaStanovanja = adresa;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = "";
            this.Pol = pol;
            this.VrstaNaloga = vrstaNaloga;
        }

        public PacijentDTO(String ime, String prezime, String jmbg)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
        }

    }
}
