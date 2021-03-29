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
        public static Boolean IzmeniProstor(String idProstora, int vrstaProstora, String Sprat, String Kvadratura, String BrojKreveta)
        {
            Prostor p = PretraziPoId(idProstora);

            p.IdProstora = idProstora;

            if (vrstaProstora == 0)
            {
                p.VrstaProstora = VrsteProstora.ordinacija;
            }
            else if (vrstaProstora == 1)
            {
                p.VrstaProstora = VrsteProstora.sala;
            }
            else
            {
                p.VrstaProstora = VrsteProstora.soba;
            }
            p.Sprat = int.Parse(Sprat);
            p.Kvadratura = float.Parse(Kvadratura);
            p.BrojKreveta = int.Parse(BrojKreveta);

            int indeks = PrikazProstora.Prostori.IndexOf(p);
            PrikazProstora.Prostori.RemoveAt(indeks);
            PrikazProstora.Prostori.Insert(indeks, p);

            return true;
        }

        public static Boolean UkloniProstor(String idProstora)
        {
            Prostor p = PretraziPoId(idProstora);

            if (p == null)
            {
                return false;
            }

            prostori.Remove(p);
            PrikazProstora.Prostori.Remove(p);

            SerijalizacijaProstora();

            if (prostori.Contains(p) || PrikazProstora.Prostori.Contains(p))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Prostor PretraziPoId(String idProstora)
        {
            foreach(Prostor p in prostori)
            {
                if (p.IdProstora.Equals(idProstora))
                {
                    return p;
                }
            }

            return null;
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