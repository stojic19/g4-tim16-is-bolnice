using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface AnketeRepozitorijumInterfejs: GlavniRepozitorijumInterfejs<Anketa>
    {
        List<Anketa> NadjiSveAnketePacijentaOBolnici(Pacijent pacijent);
    }
}
