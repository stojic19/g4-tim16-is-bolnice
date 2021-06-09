using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class ProstorKonverter
    {
        OpremaKonverter opremaKonverter = new OpremaKonverter();
        public ProstorDTO ProstorModelUProstorDTO(Prostor prostor )
        {
            List<OpremaDTO> oprema = new List<OpremaDTO>();
            foreach (Oprema o in prostor.Oprema)
                oprema.Add(opremaKonverter.OpremaModelUOpremaDTO(o));
            return new ProstorDTO(prostor.IdProstora, prostor.NazivProstora, prostor.VrstaProstora, prostor.Sprat, prostor.Kvadratura,oprema,false);
        }
        public Prostor ProstorDTOUModel(ProstorDTO prostor)
        {
            List<Oprema> oprema = new List<Oprema>();
            foreach (OpremaDTO o in prostor.Oprema)
                oprema.Add(opremaKonverter.OpremaDTOUModel(o));
            return new Prostor(prostor.IdProstora, prostor.NazivProstora, prostor.VrstaProstora,prostor.Sprat, prostor.Kvadratura,oprema, false);
        }

    }
}
