using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    class NaloziPacijenataRepozitorijum : GlavniRepozitorijum<Pacijent>, NaloziPacijenataRepozitorijumInterfejs
    {
        public NaloziPacijenataRepozitorijum()
        {
            imeFajla = "pacijenti.xml";
        }

        public List<Alergeni> DobaviAlergenePacijenta(String pacijentKorisnickoIme)
        {
            return PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + pacijentKorisnickoIme + "']").DobaviAlergene();
        }

        public void IzmeniPacijenta(Pacijent pacijent)
        {
            ObrisiObjekat("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + pacijent.KorisnickoIme + "']");
            DodajObjekat(pacijent);
        }

        public void IzmeniPacijentaSaKorisnickim(string stariId, Pacijent pacijentKojiSeMenja)
        {
            ObrisiObjekat("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + stariId + "']");
            DodajObjekat(pacijentKojiSeMenja);
        }
    }
}
