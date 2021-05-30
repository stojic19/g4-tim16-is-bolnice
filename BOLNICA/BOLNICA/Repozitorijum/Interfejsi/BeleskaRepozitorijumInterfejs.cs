using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface BeleskaRepozitorijumInterfejs: GlavniRepozitorijumInterfejs<Beleska>
    {
        Beleska PretraziBeleskuPoAnamnezi(String idPacijenta);
        void ObrisiBelesku(String idBeleske);
    }
}
