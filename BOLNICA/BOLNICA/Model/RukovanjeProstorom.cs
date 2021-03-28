using Bolnica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    public class RukovanjeProstorom
    {
        private String imeFajla;
        public static List<Prostor> prostori = new List<Prostor>();

        public static Prostor DodajProstor(Prostor p)
        {
            prostori.Add(p);
            PrikazProstora.Prostori.Add(p);

            if (prostori.Contains(p))
            {
                return p;
            }
            else
            {
                return null;
            }
        }
        public Boolean IzmeniProstor(String idProstora)
        {
            throw new NotImplementedException();
        }

        public Boolean UkloniProstor(String idProstora)
        {
            throw new NotImplementedException();
        }

        public Prostor PretraziPoId(String idProstora)
        {
            throw new NotImplementedException();
        }

        public static List<Prostor> SviProstori()
        {

            return prostori;
        }

        public static List<Prostor> DeserijalizacijaProstora()
        {
            if (File.ReadAllText("termini.xml").Trim().Equals(""))
            {
                return prostori;
            }
            else
            {
                FileStream fileStream = File.OpenRead("prostori.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Prostor>));
                prostori = (List<Prostor>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return prostori;

            }

        }

        public static void SerijalizacijaProstora()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Prostor>));
            TextWriter tw = new StreamWriter("prostori.xml");
            xmlSerializer.Serialize(tw, prostori);
            tw.Close();

        }

    }
}