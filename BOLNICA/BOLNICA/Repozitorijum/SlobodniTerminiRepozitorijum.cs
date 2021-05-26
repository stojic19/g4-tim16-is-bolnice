using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum
{
    class SlobodniTerminiRepozitorijum : GlavniRepozitorijum<Termin>, SlobodniTerminiRepozitorijumInterfejs
    {
        public SlobodniTerminiRepozitorijum()
        {
            imeFajla = "slobodniTermini.xml";
        }

        public List<Termin> DobaviSlobodneTerminePoIdLekara(string idLekara)
        {
            List<Termin> termini = new List<Termin>();
            foreach(Termin termin in DobaviSveObjekte())
            {
                if(termin.Lekar.KorisnickoIme.Equals(idLekara))
                {
                    termini.Add(termin);
                }
            }
            return termini;
        }

        public void IzmeniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
            DodajObjekat(termin);
        }
        private void UkloniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
        }

    }
}
