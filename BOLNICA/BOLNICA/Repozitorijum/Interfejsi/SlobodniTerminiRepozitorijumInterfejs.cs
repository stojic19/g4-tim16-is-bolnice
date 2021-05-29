using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface SlobodniTerminiRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Termin>
    {

        List<Termin> DobaviSlobodneTerminePoIdLekara(string idLekara);

        void IzmeniTermin(Termin termin);

        void UkloniTermin(Termin termin);

        List<Termin> DobaviSlobodneTermineLekara(Termin terminZaPoredjenje, String izabranLekar);

    }
}
