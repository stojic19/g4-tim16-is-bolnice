using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    public class SekretariRepozitorijum : GlavniRepozitorijum<Model.Sekretar>, SekretariRepozitorijumInterfejs
    {
        public SekretariRepozitorijum()
        {
            imeFajla = "sekretari.xml";
        }
        public void Izmeni(Model.Sekretar sekretar)
        {
            ObrisiObjekat("//ArrayOfSekretar/Sekretar[IdOsobe='" + sekretar.IdOsobe + "']");
            DodajObjekat(sekretar);
        }
    }
}
