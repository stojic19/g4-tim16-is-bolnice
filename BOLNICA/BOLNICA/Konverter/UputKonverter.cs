using Bolnica.DTO;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class UputKonverter
    {
        public UputDTO UputModelUDTO(Uput uput)
        {
            return new UputDTO(uput.IDUputa, TipUStrnig(uput.TipUputa), uput.DatumIzdavanja, uput.ImePrezimeLekar, uput.IDLekaraSpecijaliste, uput.NalazMisljenje);
        }

        public Uput UputDTOuModel(UputDTO uput)
        {

            return new Uput(uput.IdUputa, uput.TipUputaEnum, uput.DatumIzdavanja, uput.Lekar, uput.IdLekaraSpecijaliste, uput.NalazMisljenje, uput.PocetakStacionarnog, uput.KrajStacionarnog, uput.Prostor );
        }

        public String TipUStrnig(TipoviUputa tipUputa)
        {
            if (tipUputa.Equals(TipoviUputa.LABORATORIJA))
            {
                return "Laboratorija";
            }
            else if (tipUputa.Equals(TipoviUputa.SPECIJALISTA))
            {
                return "Specijalističko-ambulantni pregled";
            }
            else
            {
                return "Stacionarno lečenje";
            }
        }
    }
}
