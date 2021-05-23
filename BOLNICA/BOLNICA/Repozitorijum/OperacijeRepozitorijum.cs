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
    class OperacijeRepozitorijum
    {

        private static String imeFajla = "terminiOperacija.xml";

        public static List<Termin> DobaviSveTermineOperacija()
        {
            List<Termin> sveOperacije = new List<Termin>();
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sveOperacije;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sveOperacije = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sveOperacije;
            }

        }

        /*
        public static List<Alergeni> DobaviAlergenePacijenta(String pacijentKorisnickoIme)
        {
            return DobaviPacijentaPoId(pacijentKorisnickoIme).DobaviAlergene();
        }
        */

        public static Termin DobaviTerminPoId(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Termin termin = KonvertujCvorUObjekat(node);
            return termin;
        }

        private static Termin KonvertujCvorUObjekat(XmlNode cvorTermina)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(cvorTermina.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Termin));
            return (ser.Deserialize(stm) as Termin);
        }

        private static List<Termin> KonvertujSveCvoroveUObjekte(XmlNodeList cvoroviTermina)
        {
            List<Termin> objektiTermina = new List<Termin>();
            foreach (XmlNode node in cvoroviTermina)
            {
                objektiTermina.Add(KonvertujCvorUObjekat(node));
            }
            return objektiTermina;
        }

        public static void ObrisiTermin(Termin terminZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje.IdTermina + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(imeFajla);
        }

        public static void DodajTermin(Termin terminZaUpis)
        {
            List<Termin> termini = DobaviSveTermineOperacija();
            termini.Add(terminZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();

        }

        public static void IzmeniTermin(Termin termin)
        {
            ObrisiTermin(termin);
            DodajTermin(termin);
        }

    }
}
