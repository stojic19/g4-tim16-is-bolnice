using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    interface SekretariRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Model.Sekretar>
    {
        void Izmeni(Model.Sekretar sekretar);
    }
}
