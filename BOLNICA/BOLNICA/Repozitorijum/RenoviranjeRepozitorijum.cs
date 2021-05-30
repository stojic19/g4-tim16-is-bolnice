using Bolnica.Model;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;

namespace Bolnica.Repozitorijum
{
    public class RenoviranjeRepozitorijum : GlavniRepozitorijum<Renoviranje>, RenoviranjeRepozitorijumInterfejs
    {
        public RenoviranjeRepozitorijum()
        {
            imeFajla = "renoviranje.xml";
        }

        public void ObrisiRenoviranje(String idRenoviranja)
        {
            ObrisiObjekat("//ArrayOfRenoviranje/Renoviranje[IdRenoviranja='" + idRenoviranja + "']");
        }
    }
}