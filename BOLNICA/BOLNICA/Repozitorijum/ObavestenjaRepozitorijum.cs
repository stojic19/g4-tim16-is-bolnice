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
    public class ObavestenjaRepozitorijum : GlavniRepozitorijum<Obavestenje>, ObavestenjaRepozitorijumInterfejs
    {
        public ObavestenjaRepozitorijum()
        {
            imeFajla = "obavestenja.xml";
        }
        
        public void IzmeniObavestenje(Obavestenje obavestenjeZaIzmenu)
        {
            ObrisiObjekat("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + obavestenjeZaIzmenu.IdObavestenja + "']");
            DodajObjekat(obavestenjeZaIzmenu);
        }

        public Obavestenje PretraziObavestenjaPoId(String idObavestenja)
        {
            return PretraziPoId("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + idObavestenja + "']");
        }


        public List<Obavestenje> DobaviSvaObavestenjaOsobe(String idOsobe)
        {
            List<Obavestenje> obavestenjaOsobe = new List<Obavestenje>();
            foreach(Obavestenje obavestenje in DobaviSveObjekte())
            {
                if (obavestenje.IdPrimaoca.Equals(idOsobe))
                    obavestenjaOsobe.Add(obavestenje);
            }
            return obavestenjaOsobe;
        }
    }
}
