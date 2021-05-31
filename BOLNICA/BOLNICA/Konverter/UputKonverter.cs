using Bolnica.DTO;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class UputKonverter
    {
        ProstorKonverter prostorKonverter = new ProstorKonverter();

        public UputDTO UputModelUDTO(Uput uput)
        {
            ProstorDTO soba = null;
            if (uput.Prostor != null) soba = prostorKonverter.ProstorModelUProstorDTO(uput.Prostor);

            return new UputDTO(uput.IDUputa, TipUStrnig(uput.TipUputa), uput.DatumIzdavanja, uput.ImePrezimeLekar, uput.IDLekaraSpecijaliste, uput.NalazMisljenje, soba, uput.PocetakStacionarnog, uput.KrajStacionarnog);
        }

        public Uput UputDTOuModel(UputDTO uput)
        {
            Prostor prostor = null;

            if (uput.Prostor != null) prostor = prostorKonverter.ProstorDTOUModel(uput.Prostor); 

            return new Uput(uput.IdUputa, uput.TipUputaEnum, uput.DatumIzdavanja, uput.Lekar, uput.IdLekaraSpecijaliste, uput.NalazMisljenje, uput.PocetakStacionarnog, uput.KrajStacionarnog, prostor);
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
