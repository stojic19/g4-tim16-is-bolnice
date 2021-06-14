using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface KorisnikRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Korisnik>
    {

        Korisnik PretraziKorisnikaPoKorImenu(String idLeka);
        void ObrisiKorisnika(String korisnickoIme);
        void ObrisiKorisnikaPoKorImenu(String KorIme);
    }
}
