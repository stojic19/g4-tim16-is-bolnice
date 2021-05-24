using Model;
using System;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface LekoviRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Lek>
    {
        Lek PretraziLekPoId(String idLeka);
        void IzmenaLeka(Lek noviPodaci);
    }
}
