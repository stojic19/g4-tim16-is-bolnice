using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    interface ObavestenjaRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Obavestenje>
    {
        void IzmeniObavestenje(Obavestenje obavestenjeZaIzmenu);
    }
}
