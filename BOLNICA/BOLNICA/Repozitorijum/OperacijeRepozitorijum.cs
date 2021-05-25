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
        
        /*
        public Termin DobaviTerminPoId(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Termin termin = KonvertujCvorUObjekat(node);
            return termin;
        }*/

        public void IzmeniTermin(Termin termin)
        {
            ObrisiObjekat("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
            DodajObjekat(termin);
        }

    }
}
