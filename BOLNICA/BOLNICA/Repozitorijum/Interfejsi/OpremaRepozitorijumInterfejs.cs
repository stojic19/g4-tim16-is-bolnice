using Model;
using System;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface OpremaRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Oprema>
    {
        Oprema PretraziOpremuPoId(String idOpreme);
        void IzmenaOpreme(Oprema noviPodaci);
    }
}