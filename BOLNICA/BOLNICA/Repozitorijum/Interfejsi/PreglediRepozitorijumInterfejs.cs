using Bolnica.Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface PreglediRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Pregled>
    {
        void IzmeniPregled(Pregled pregledZaIzmenu);
        List<Pregled> SortPoDatumuPregleda();
        List<Pregled> DobaviSvePregledePacijenta(String korisnickoImePacijenta);
    }
}
