using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class SekretarDTO : OsobaDTO
    {
        public SekretarDTO(string idOSobe, string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
        {
            if (idOSobe == null)
                this.IdOsobe = Guid.NewGuid().ToString();
            else
                this.IdOsobe = idOSobe;
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
    }
}
