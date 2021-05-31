using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface ZahtjeviRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Zahtjev>
    {
        Zahtjev PretraziZahtjevPoId(String idZahtjeva);
        void IzmenaZahtjeva(Zahtjev noviPodaci);
    }
}
