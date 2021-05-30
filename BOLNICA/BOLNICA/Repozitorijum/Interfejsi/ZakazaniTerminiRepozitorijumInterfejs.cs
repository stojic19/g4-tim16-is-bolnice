using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface ZakazaniTerminiRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Termin>
    {
        Boolean DaLiPostojiTermin(Termin t);

        Boolean OtkaziTerminLekar(String idTermina);

        void OtkaziPregledSekretar(String idTermina);

        List<Termin> PretraziPoLekaru(String korImeLekara);

        List<Termin> DobaviSveSlobodneTermine();

        List<Termin> DobaviSveZakazaneTermine();

        List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme);

        void ObrisiZakazanTermin(String terminZaBrisanje);

        void IzmeniTermin(Termin termin);
    }
}
