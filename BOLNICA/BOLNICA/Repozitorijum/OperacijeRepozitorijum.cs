using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    class OperacijeRepozitorijum : GlavniRepozitorijum<Termin>, OperacijeRepozitorijumInterfejs
    {
        public OperacijeRepozitorijum()
        {
            imeFajla = "terminiOperacija.xml";
        }
        
        public void IzmeniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
            DodajObjekat(termin);
        }

        internal void UkloniOperaciju(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
        }

        public List<Termin> DobaviOperacijePoIdLekara(string idLekara)
        {
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in DobaviSveObjekte())
            {
                if (termin.Lekar.KorisnickoIme.Equals(idLekara))
                {
                    termini.Add(termin);
                }
            }
            return termini;
        }
    }
}
