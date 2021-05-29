using Bolnica.Model;
using Bolnica.UpravnikFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Servis
{
    class RenoviranjeServis
    {
        private static String imeFajla1 = "renoviranje.xml";

        public static List<Renoviranje> renoviranja = new List<Renoviranje>();

        public static List<Renoviranje> SvaRenoviranja()
        {
            return renoviranja;
        }
        public static void DodajZaRenoviranje(Renoviranje renoviranje)
        {
                renoviranja.Add(renoviranje);
                PrikazRenoviranja.Renoviranje.Add(renoviranje);
        }

        public static void ProveriRenoviranje()
        {

            foreach (Renoviranje r in renoviranja)
            {
                if (provjeraDatuma(r.PocetniDatum.Date, r.DatumKraja.Date))
                {
                    PostaviDaSeRenovira(r);
                }
                else
                {
                    PostaviDaSeNeRenovira(r);
                }
            }
        }

        public static bool provjeraDatuma(DateTime datumPocetka, DateTime datumKraja)
        {
            if (DateTime.Compare(datumPocetka.Date, DateTime.Now.Date) <= 0 && DateTime.Compare(DateTime.Now.Date, datumKraja.Date) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void PostaviDaSeRenovira(Renoviranje r)
        {
            /* foreach (Prostor p in prostori)
             {
                 if (p.IdProstora.Equals(r.RoomId))
                 {
                     p.JeRenoviranje = true;
                     break;
                 }
             }*/
        }

        public static void PostaviDaSeNeRenovira(Renoviranje r)
        {
            /*  foreach (Prostor p in prostori)
              {
                  if (p.IdProstora.Equals(r.RoomId))
                  {
                      p.JeRenoviranje = false;
                      break;
                  }
              }*/
        }

        public static List<Renoviranje> DeserijalizacijaProstoraZaRenoviranje()
        {
            if (File.ReadAllText(imeFajla1).Trim().Equals(""))
            {
                return renoviranja;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla1);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Renoviranje>));
                renoviranja = (List<Renoviranje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return renoviranja;

            }

        }

        public static void SerijalizacijaProstoraZaRenoviranje()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Renoviranje>));
            TextWriter tw = new StreamWriter(imeFajla1);
            xmlSerializer.Serialize(tw, renoviranja);
            tw.Close();

        }

    }
}
