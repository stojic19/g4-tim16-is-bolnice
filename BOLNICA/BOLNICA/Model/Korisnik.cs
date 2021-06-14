using Bolnica.Model.Enumi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Korisnik : Osoba
    {
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

        public TipoviKorisnika TipKorisnika { get => tipKorisnika; set => tipKorisnika = value; }

    }
}
