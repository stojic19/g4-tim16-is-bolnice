using Bolnica.Model;
using System.Collections.Generic;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface PreglediRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Pregled>
    {
        void IzmeniPregled(Pregled pregledZaIzmenu);
        List<Pregled> SortPoDatumuPregleda();
    }
}
