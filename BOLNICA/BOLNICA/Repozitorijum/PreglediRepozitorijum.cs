using Bolnica.Model;
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
    public class PreglediRepozitorijum //implementiranje interfejsa i dodaj abstraktnu klasu za repo(dont repeat yourself)
    {

        private static String imeFajla = "pregledi.xml";

        public List<Pregled> DobaviSvePreglede()
        {
            List<Pregled> sviPregledi = new List<Pregled>();
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sviPregledi;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pregled>));
                sviPregledi = (List<Pregled>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviPregledi;
            }

        }
        public Pregled PretraziPoId(String idPregleda)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode cvor = root.SelectSingleNode("//ArrayOfPregled/Pregled[IdPregleda='" + idPregleda + "']", nsmgr);
            Pregled pregled = KonvertujCvorUObjekat(cvor);
            return pregled;
        }

        private Pregled KonvertujCvorUObjekat(XmlNode cvorPregleda)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(cvorPregleda.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Pregled));
            return (ser.Deserialize(stm) as Pregled);
        }

        public void DodajPregled(Pregled noviPregled)
        {
            List<Pregled> sviPregledi = DobaviSvePreglede();
            sviPregledi.Add(noviPregled);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pregled>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, sviPregledi);
            tw.Close();
        }

        public void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfPregled/Pregled/Termin[IdTermina='" + terminOtkazanogPregleda + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(imeFajla);
        }

        public void IzmeniPregled(Pregled pregledZaIzmenu)
        {
            UklanjanjePregleda(pregledZaIzmenu.IdPregleda);
            DodajPregled(pregledZaIzmenu);
        }

        public Pregled PretragaPoTerminu(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode cvor = root.SelectSingleNode("//ArrayOfPregled/Pregled/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Pregled pregled = KonvertujCvorUObjekat(cvor);
            return pregled;
        }

        public Pregled PretragaPoAnamnezi(String idAnamneze)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode cvor = root.SelectSingleNode("//ArrayOfPregled/Pregled/Anamneza[IdAnamneze='" + idAnamneze + "']", nsmgr);
            Pregled pregled = KonvertujCvorUObjekat(cvor);
            return pregled;
        }

        public List<Pregled> SortPoDatumuPregleda()
        {
            return DobaviSvePreglede().OrderBy(user => user.Termin.Datum).ToList();
        }
    }
}
