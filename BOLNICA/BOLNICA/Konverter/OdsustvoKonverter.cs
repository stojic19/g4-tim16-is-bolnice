using Bolnica.DTO;
using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class OdsustvoKonverter
    {
        public OdsustvoDTO OdsustvoModelUDTO(Odsustvo odsustvo)
        {
            return new OdsustvoDTO(odsustvo.PocetakOdsustva, odsustvo.KrajOdsustva);
        }
        public Odsustvo OdsustvoDTOUModel(OdsustvoDTO odsustvo)
        {
            return new Odsustvo(odsustvo.PocetakOdsustva, odsustvo.KrajOdsustva);
        }
    }
}
