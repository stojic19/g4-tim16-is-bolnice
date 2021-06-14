using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Factory;
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
        private PitanjaRepozitorijumInterfejs pitanjaRepozitorijum = PitanjaFactory.DobaviRepozitorijum();

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
