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
    class NaloziPacijenataRepozitorijum
    {
        private static String imeFajla = "pacijenti.xml";

        public static List<Pacijent> DobaviSveNalogePacijenata()
        {
            List<Pacijent> sviNaloziPacijenata = new List<Pacijent>();
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sviNaloziPacijenata;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
                sviNaloziPacijenata = (List<Pacijent>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviNaloziPacijenata;
            }

        }

        public static List<Alergeni> DobaviAlergenePacijenta(String pacijentKorisnickoIme)
        {
            return DobaviPacijentaPoId(pacijentKorisnickoIme).DobaviAlergene();
        }


        public static Pacijent DobaviPacijentaPoId(String idPacijenta)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idPacijenta + "']", nsmgr);
            Pacijent pacijent = KonvertujCvorUObjekat(node);
            return pacijent;
        }

        private static Pacijent KonvertujCvorUObjekat(XmlNode cvorPacijenta)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(cvorPacijenta.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Pacijent));
            return (ser.Deserialize(stm) as Pacijent);
        }

        private static List<Pacijent> KonvertujSveCvoroveUObjekte(XmlNodeList cvoroviPacijenata)
        {
            List<Pacijent> objektiPacijenata = new List<Pacijent>();
            foreach (XmlNode node in cvoroviPacijenata)
            {
                objektiPacijenata.Add(KonvertujCvorUObjekat(node));
            }
            return objektiPacijenata;
        }

        public static void ObrisiPacijenta(Pacijent pacijentZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + pacijentZaBrisanje.KorisnickoIme + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(imeFajla);
        }

        public static void DodajPacijenta(Pacijent pacijentZaUpis)
        {
            List<Pacijent> pacijenti = DobaviSveNalogePacijenata();
            pacijenti.Add(pacijentZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, pacijenti);
            tw.Close();

        }

        public static void IzmeniPacijenta(Pacijent pacijent)
        {
            ObrisiPacijenta(pacijent);
            DodajPacijenta(pacijent);
        }

    }
}
