using Bolnica.DTO;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class AnketaKonverter
    {
        public Anketa AnketaDTOUModel(AnketaDTO anketaDto)
        {
            PitanjeKonverter pitanjaKonverter = new PitanjeKonverter();
            return new Anketa(pitanjaKonverter.PitanjeDTOUModel(anketaDto.PitanjaAnkete), anketaDto.DodatniKomentar);
        }
    }
}
