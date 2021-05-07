using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    class RukovanjeZahtjevima
    {
        public static List<Zahtjev> zahtjevi = new List<Zahtjev>();
        private static String imeFajla = "zahtjevi.xml";
        public static bool DodajZahtjev(Zahtjev zahtjev)
        {

            if (zahtjevi.Contains(zahtjev))
            {
                return false;
            }

            zahtjevi.Add(zahtjev);
            SerijalizacijaZahtjeva();
            return true;
        }

        public static List<Zahtjev> SviZahtjevi()
        {
            return zahtjevi;
        }

        public static void Verifikuj(Zahtjev zahtjev)
        {
            RukovanjeLijekovima.SviLijekovi().Add(zahtjev.Lijek);
            SviZahtjevi().Remove(zahtjev);
        }

        public static List<Zahtjev> DeserijalizacijaZahtjeva()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return zahtjevi;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Zahtjev>));
                zahtjevi = (List<Zahtjev>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return zahtjevi;

            }

        }

        public static void SerijalizacijaZahtjeva()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Zahtjev>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, zahtjevi);
            tw.Close();

        }
    }
}
