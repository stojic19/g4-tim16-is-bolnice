using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;

namespace Bolnica.Repozitorijum
{
    public class LekoviRepozitorijum : GlavniRepozitorijum<Lek>, LekoviRepozitorijumInterfejs
    {
        public LekoviRepozitorijum()
        {
            imeFajla = "lekovi.xml";
        }

        public Lek PretraziLekPoId(String idLeka)
        {
            return PretraziPoId("//ArrayOfLek/Lek[IDLeka='" + idLeka + "']");
        }


        public void IzmenaLeka(Lek noviPodaci)
        {
            ObrisiObjekat("//ArrayOfLek/Lek[IDLeka='" + noviPodaci.IDLeka + "']");
            DodajObjekat(noviPodaci);
        }
    }
}
