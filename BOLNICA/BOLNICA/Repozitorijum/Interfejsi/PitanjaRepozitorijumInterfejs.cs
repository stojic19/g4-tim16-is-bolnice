using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface PitanjaRepozitorijumInterfejs: GlavniRepozitorijumInterfejs<Pitanje>
    {
         List<Pitanje> DobaviSvaPitanjaOBolnici();

        List<Pitanje> DobaviSvaPitanjaOPregledu();
    }
}
