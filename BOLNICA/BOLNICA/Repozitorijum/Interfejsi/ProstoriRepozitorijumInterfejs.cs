using Model;
using System;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface ProstoriRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Prostor>
    {
        Prostor PretraziProstorPoId(String idProstora);
        void IzmenaProstora(Prostor noviPodaci);
    }
}
