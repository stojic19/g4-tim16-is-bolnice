using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class ObavestenjeKonverter
    {
        public ObavestenjeDTO ObavestenjeModelUDTO(Obavestenje obavestenje)
        {
            return new ObavestenjeDTO(obavestenje.IdObavestenja, obavestenje.Naslov, obavestenje.Tekst, obavestenje.Datum, obavestenje.IdPrimaoca);
        }
        public Obavestenje ObavestenjeDTOUModel(ObavestenjeDTO obavestenje)
        {
            return new Obavestenje(obavestenje.IdObavestenja, obavestenje.Naslov, obavestenje.Tekst, obavestenje.Datum, obavestenje.IdPrimaoca);
        }
    }
}
