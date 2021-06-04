using Bolnica.Model;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    public class BeleskaRepozitorijum : GlavniRepozitorijum<Beleska>, BeleskaRepozitorijumInterfejs
    {
        public BeleskaRepozitorijum()
        {
            imeFajla = "beleske.xml";

        }

        public Beleska PretraziBeleskuPoAnamnezi(String idAnamneze)
        {

            foreach (Beleska beleska in DobaviSveObjekte())
            {
                if (beleska.Anamneza.IdAnamneze.Equals(idAnamneze))
                    return beleska;
            }
            return null;
        }
        public void ObrisiBelesku(String idBeleske)
        {
            ObrisiObjekat("//ArrayOfBeleska/Beleska[Id='" + idBeleske + "']");
        }
        public Beleska PretraziBeleskePoId(String idBeleske)
        {
            return PretraziPoId("//ArrayOfBeleska/Beleska[Id='" + idBeleske + "']");
        }
    }
}
