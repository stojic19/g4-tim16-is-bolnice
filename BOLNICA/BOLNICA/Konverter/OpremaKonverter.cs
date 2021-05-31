using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class OpremaKonverter
    {
        public OpremaDTO OpremaModelUOpremaDTO(Oprema oprema)
        {
            return new OpremaDTO(oprema.IdOpreme, oprema.NazivOpreme, oprema.VrstaOpreme, oprema.Kolicina);
        }
        public Oprema OpremaDTOUModel(OpremaDTO oprema)
        {
            return new Oprema(oprema.IdOpreme, oprema.NazivOpreme, oprema.VrstaOpreme, oprema.Kolicina);
        }

    }
}
