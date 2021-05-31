using Bolnica.DTO;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class RenoviranjeKonverter
    {
        public RenoviranjeDTO RenoviranjeModelUDTO(Renoviranje renoviranje)
        {
            return new RenoviranjeDTO(renoviranje.IdRenoviranja, renoviranje.Prostor, renoviranje.PocetniDatum, renoviranje.DatumKraja);
        }
        public Renoviranje RenoviranjeDTOUModel(RenoviranjeDTO renoviranje)
        {
            return new Renoviranje(renoviranje.IdRenoviranja, renoviranje.Prostor, renoviranje.PocetniDatum, renoviranje.DatumKraja);
        }

    }
}
