using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Korisnik
    {
        private String idOsobe;
        private String korisnickoIme;
        private String lozinka;
        private TipoviKorisnika tipKorisnika;

        public Korisnik()
        {
        }

        public Korisnik(string idOsobe, string korisnickoIme, string lozinka, TipoviKorisnika tipKorisnika)
        {
            IdOsobe = idOsobe;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            TipKorisnika = tipKorisnika;
        }

        public Korisnik(string korisnickoIme, string lozinka, TipoviKorisnika tipKorisnika)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            TipKorisnika = tipKorisnika;
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public TipoviKorisnika TipKorisnika { get => tipKorisnika; set => tipKorisnika = value; }
        public string IdOsobe { get => idOsobe; set => idOsobe = value; }
    }
}
