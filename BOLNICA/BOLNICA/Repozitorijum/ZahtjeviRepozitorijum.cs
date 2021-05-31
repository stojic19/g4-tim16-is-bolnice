using Bolnica.Model;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    public class ZahtjeviRepozitorijum : GlavniRepozitorijum<Zahtjev>, ZahtjeviRepozitorijumInterfejs
    {
        public ZahtjeviRepozitorijum()
        {
            imeFajla = "zahtjevi.xml";
        }

        public Zahtjev PretraziZahtjevPoId(String idZahtjeva)
        {
            return PretraziPoId("//ArrayOfZahtjev/Zahtjev[IdZahtjeva='" + idZahtjeva + "']");
        }


        public void IzmenaZahtjeva(Zahtjev noviPodaci)
        {
            ObrisiObjekat("//ArrayOfZahtjev/Zahtjev[IdZahtjeva='" + noviPodaci.IdZahtjeva + "']");
            DodajObjekat(noviPodaci);
        }
    }
}
