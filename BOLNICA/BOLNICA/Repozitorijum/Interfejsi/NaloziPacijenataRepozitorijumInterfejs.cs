using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface NaloziPacijenataRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Pacijent>
    {
        List<Alergeni> DobaviAlergenePacijenta(String pacijentKorisnickoIme);

        void IzmeniPacijenta(Pacijent pacijent);
    }
}
