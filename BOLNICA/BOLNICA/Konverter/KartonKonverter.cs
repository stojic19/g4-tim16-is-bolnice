using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class KartonKonverter
    {
        public KartonPacijentaDTO KartonPacijentaModelUDTO(ZdravstveniKarton karton)
        {
            AlergeniKonverter alergenKonverter = new AlergeniKonverter();
            List<AlergenDTO> alergeni = new List<AlergenDTO>();
            foreach (Alergeni alergen in karton.Alergeni)
                alergeni.Add(alergenKonverter.AlergenModelUAlergenDTO(alergen));
            return new KartonPacijentaDTO(karton.BracniStatus, karton.MestoZaposlenja, karton.ImeRoditelja, karton.BrojKartona, alergeni, karton.IDPacijenta);
        }
    }
}
