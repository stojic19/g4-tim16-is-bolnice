using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    public class PitanjaServis
    {
        private PitanjaRepozitorijumInterfejs pitanjaRepozitorijum = new PitanjaRepozitorijum();

        public List<Pitanje> DobaviPitanjaOBolnici()
        {
            return pitanjaRepozitorijum.DobaviSvaPitanjaOBolnici();
        }
        public List<Pitanje> DobaviPitanjaOPregledu()
        {
            return pitanjaRepozitorijum.DobaviSvaPitanjaOPregledu();
        }
    }
}
