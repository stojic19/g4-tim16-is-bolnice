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
    class ObavestenjaRepozitorijum
    {
        private static String imeFajla = "obavestenja.xml";

        public List<Obavestenje> DobaviSvaObavestenja()
        {
            List<Obavestenje> svaObavestenja = new List<Obavestenje>();
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return svaObavestenja;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Obavestenje>));
                svaObavestenja = (List<Obavestenje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return svaObavestenja;
            }

        }

        public Obavestenje DobaviObavestenjePoId(String idObavestenja)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + idObavestenja + "']", nsmgr);
            Obavestenje obavestenje = KonvertujCvorUObjekat(node);
            return obavestenje;
        }

        private Obavestenje KonvertujCvorUObjekat(XmlNode cvorObavestenja)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(cvorObavestenja.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Obavestenje));
            return (ser.Deserialize(stm) as Obavestenje);
        }

        private List<Obavestenje> KonvertujSveCvoroveUObjekte(XmlNodeList cvoroviObavestenja)
        {
            List<Obavestenje> objektiObavestenja = new List<Obavestenje>();
            foreach (XmlNode node in cvoroviObavestenja)
            {
                objektiObavestenja.Add(KonvertujCvorUObjekat(node));
            }
            return objektiObavestenja;
        }

        public void ObrisiObavestenje(Obavestenje obavestenjeZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + obavestenjeZaBrisanje.IdObavestenja + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(imeFajla);
        }

        public void DodajObavestenje(Obavestenje obavestenjeZaUpis)
        {
            List<Obavestenje> obavestenja = DobaviSvaObavestenja();
            obavestenja.Add(obavestenjeZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Obavestenje>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, obavestenja);
            tw.Close();

        }

        public void IzmeniObavestenje(Obavestenje obavestenjeZaIzmenu)
        {
            ObrisiObavestenje(obavestenjeZaIzmenu);
            DodajObavestenje(obavestenjeZaIzmenu);
        }
    }
}
