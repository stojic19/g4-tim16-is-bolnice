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
        private bool blokiran;
        KartonPacijentaDTO karton;
        private int polInt;
        private int vrstaNalogaInt;
        private String polString;
        public VrsteNaloga VrstaNaloga { get => vrstaNaloga; set => vrstaNaloga = value; }
        public bool Blokiran { get => blokiran; set => blokiran = value; }
        public int PolInt { get => polInt; set => polInt = value; }
        public String PolString { get => polString; set => polString = value; }
        public int VrstaNalogaInt { get => vrstaNalogaInt; set => vrstaNalogaInt = value; }
        public KartonPacijentaDTO Karton { get => karton; set => karton = value; }

        public PacijentDTO(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, VrsteNaloga vrstaNaloga, string lozinka, bool blokiran)
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
            this.Blokiran = blokiran;
            this.PolInt = (int)pol;
            this.VrstaNalogaInt = (int)vrstaNaloga;
            this.polString = PolToString(pol);
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
            this.PolInt = (int)pol;
            this.VrstaNalogaInt = (int)vrstaNaloga;
            this.polString = PolToString(pol);
        }

        public PacijentDTO(KartonPacijentaDTO karton, String ime, String prezime, DateTime datumRodjenja, String jmbg, String adresaStanovanja, String kontaktTelefon, String email, String korisnickoIme, String lozinka, Pol pol) : base(ime, prezime, datumRodjenja, jmbg, adresaStanovanja, kontaktTelefon, email, korisnickoIme, lozinka, pol)
        {
            this.karton = karton;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.Jmbg = jmbg;
            this.AdresaStanovanja = adresaStanovanja;
            this.KontaktTelefon = kontaktTelefon;
            this.Email = email;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Pol = pol;
            this.polString = PolToString(pol);
        }

        public PacijentDTO()
        {
            this.Ime = "";
            this.Prezime = "";
            this.Jmbg = "";
            this.AdresaStanovanja = "";
            this.KontaktTelefon = "";
            this.Email = "";
            this.KorisnickoIme = "";
            this.Lozinka = "";
        }

        public PacijentDTO(String ime, String prezime, String jmbg, String korisnickoIme)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.KorisnickoIme = korisnickoIme;
        }

        public PacijentDTO(string ime, string prezime, string jmbg, Pol pol)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Pol = pol;
            this.PolInt = (int)pol;
            this.polString = PolToString(pol);
        }

        public String PolToString(Pol p)
        {
            if (p.Equals(Pol.muski))
            {
                return "M";
            }
            else { return "Ž"; }
        }
    }
}
