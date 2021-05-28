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

        public List<Pitanje> DobaviPitanjaOBolnici()
        {
            return pitanjaServis.DobaviPitanjaOBolnici();
        }
        public List<Pitanje> DobaviPitanjaOPregledu()
        {
            return pitanjaServis.DobaviPitanjaOPregledu();
        }
    }
}
