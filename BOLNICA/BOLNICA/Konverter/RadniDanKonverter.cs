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
    public class RadniDanKonverter
    {
        public RadniDanDTO RadniDanModelUDTO(RadniDan radniDan)
        {
            return new RadniDanDTO(radniDan.IdRadnogDana, radniDan.PocetakSmene, radniDan.KrajSmene, "");
        }
        public RadniDan RadniDanDTOUModel(RadniDanDTO radniDan)
        {
            return new RadniDan(radniDan.IdRadnogDana, radniDan.PocetakSmene, radniDan.KrajSmene);
        }
    }
}
