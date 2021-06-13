using Bolnica.Model;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    public class KorisnikRepozitorijum : GlavniRepozitorijum<Korisnik>, KorisnikRepozitorijumInterfejs 
    {
        public KorisnikRepozitorijum()
        {
            imeFajla = "korisnici.xml";
        }

        public Korisnik PretraziKorisnikaPoKorImenu(String korisnickoIme)
        {
            return PretraziPoId("//ArrayOfKorisnik/Korisnik[KorisnickoIme='" + korisnickoIme + "']");
        }

        public void ObrisiKorisnika(String idOsobe)
        {
            ObrisiObjekat("//ArrayOfKorisnik/Korisnik[IdOsobe='" + idOsobe + "']");
        }

        public void ObrisiKorisnikaPoKorImenu(String KorIme)
        {
            ObrisiObjekat("//ArrayOfKorisnik/Korisnik[KorisnickoIme='" + KorIme + "']");
        }
    }
}
