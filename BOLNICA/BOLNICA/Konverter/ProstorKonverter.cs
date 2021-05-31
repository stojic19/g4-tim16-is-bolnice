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
        public ProstorDTO ProstorModelUProstorDTO(Prostor prostor )
        {
            return new ProstorDTO(prostor.IdProstora, prostor.NazivProstora, prostor.VrstaProstora, prostor.Sprat, prostor.Kvadratura,false);
        }
        public Prostor ProstorDTOUModel(ProstorDTO prostor)
        {
            return new Prostor(prostor.IdProstora, prostor.NazivProstora, prostor.VrstaProstora,prostor.Sprat, prostor.Kvadratura, false);
        }

    }
}
