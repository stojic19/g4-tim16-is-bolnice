using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Bolnica.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class PitanjaKontroler
    {
        private PitanjaServis pitanjaServis = new PitanjaServis();
        private PitanjeKonverter pitanjeKonverter = new PitanjeKonverter();

        public List<PitanjeDTO> DobaviPitanjaOBolnici()
        {
            return pitanjeKonverter.PitanjeModeliUDTO(pitanjaServis.DobaviPitanjaOBolnici());
        }
        public List<PitanjeDTO> DobaviPitanjaOPregledu()
        {
            return pitanjeKonverter.PitanjeModeliUDTO(pitanjaServis.DobaviPitanjaOPregledu());
        }
    }
}
