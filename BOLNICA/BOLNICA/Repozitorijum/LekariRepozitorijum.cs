using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    class LekariRepozitorijum : GlavniRepozitorijum<Lekar>, LekariRepozitorijumInterfejs
    {
        public LekariRepozitorijum()
        {
            imeFajla = "lekari.xml";
        }
        public void IzmeniLekara(Lekar lekar)
        {
            ObrisiObjekat("//ArrayOfLekar/Lekar[IdOsobe='" + lekar.IdOsobe + "']");
            DodajObjekat(lekar);
        }
    }
}
