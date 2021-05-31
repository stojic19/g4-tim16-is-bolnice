using Bolnica.DTO;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Konverter
{
    public class PitanjeKonverter
    {
        public List<PitanjeDTO> PitanjeModeliUDTO(List<Pitanje> pitanja)
        {
            List<PitanjeDTO> pitanjaDto = new List<PitanjeDTO>();
            foreach (Pitanje pitanje in pitanja)
                pitanjaDto.Add(new PitanjeDTO(pitanje.Ocena, pitanje.TekstPitanja, pitanje.PitanjeOBolnici));
            return pitanjaDto;
        }

        public List<Pitanje> PitanjeDTOUModel(List<PitanjeDTO> pitanjaDto)
        {
            List<Pitanje> pitanja = new List<Pitanje>();
            foreach (PitanjeDTO pitanje in pitanjaDto)
                pitanja.Add(new Pitanje(pitanje.Ocena, pitanje.TekstPitanja, pitanje.PitanjeOBolnici));
            return pitanja;
        }
    }
}
