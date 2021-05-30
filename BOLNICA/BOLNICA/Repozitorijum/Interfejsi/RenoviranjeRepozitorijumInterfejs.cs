using Bolnica.Model;
using Model;
using System;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface RenoviranjeRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Renoviranje>
    {
        void ObrisiRenoviranje(String idRenoviranja);
    }
}
