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

        public Beleska PretraziBeleskuPoId(String idPacijenta)
        {

            foreach (Beleska beleska in DobaviSveObjekte())
            {
                if (beleska.Anamneza.IdPacijenta.Equals(idPacijenta))
                    return beleska;
            }
            return null;
        }
    }
}
