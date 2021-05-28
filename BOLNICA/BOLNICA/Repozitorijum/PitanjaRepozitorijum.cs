using Bolnica.Model;
using Bolnica.Model.Enumi;
using Bolnica.Repozitorijum.Interfejsi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    public class PitanjaRepozitorijum: GlavniRepozitorijum<Pitanje>, PitanjaRepozitorijumInterfejs
    {
        public List<Pitanje> DobaviSvaPitanjaOBolnici()
        {
            List<Pitanje> pitanjaOBolnici = new List<Pitanje>();
            foreach(Pitanje pitanje in DobaviSveObjekte())
            {
                if (pitanje.PitanjeOBolnici)
                    pitanjaOBolnici.Add(pitanje);
            }
            return pitanjaOBolnici;
        }

        public List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            List<Pitanje> pitanjaOPregledu = new List<Pitanje>();
            foreach (Pitanje pitanje in DobaviSveObjekte())
            {
                if (!pitanje.PitanjeOBolnici)
                    pitanjaOPregledu.Add(pitanje);
            }
            return pitanjaOPregledu;
        }

    }
}
