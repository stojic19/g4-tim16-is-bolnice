using Bolnica.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    class AlergeniKonverter
    {
        public AlergenDTO AlergeniPrikazDTOUAlergenDTO(AlergeniPrikazDTO alergeniPrikazDTO)
        {
            return new AlergenDTO(alergeniPrikazDTO.IdAlergena, alergeniPrikazDTO.OpisReakcije, alergeniPrikazDTO.VremeZaPojavu);
        }
        public AlergenDTO AlergeniModelUDTO(Alergeni alergeni)
        {
            return new AlergenDTO(alergeni.IdAlergena, alergeni.OpisReakcije, alergeni.VremeZaPojavu);
        }
        public AlergeniPrikazDTO AlergeniModelPrikazUDTO(Alergeni alergeni)
        {
            return new AlergeniPrikazDTO(alergeni.IdAlergena, alergeni.Lek.NazivLeka, alergeni.OpisReakcije, alergeni.VremeZaPojavu);
        }
        public Alergeni AlergenDTOUModel(AlergenDTO alergeniDTO)
        {
            return new Alergeni(alergeniDTO.IdAlergena, alergeniDTO.OpisReakcije, alergeniDTO.VremeZaPojavu);
        }

        public AlergenDTO AlergenModelUAlergenDTO(Alergeni alergeni)
        {
            LekKonverter lekKonverter = new LekKonverter();
            return new AlergenDTO(alergeni.IdAlergena, lekKonverter.LekModelULekDTO(alergeni.Lek), alergeni.OpisReakcije, alergeni.VremeZaPojavu);
        }
    }
}
