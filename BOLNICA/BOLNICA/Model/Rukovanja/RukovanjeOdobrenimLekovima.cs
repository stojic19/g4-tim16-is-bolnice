using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    class RukovanjeOdobrenimLekovima
    {

        public static List<Lek> SviLekovi { get; set; } = new List<Lek>();
        private static String imeFajla = "lekovi.xml";

        public static Lek PretraziPoID(String sifraLeka)
        {
            foreach (Lek l in SviLekovi)
            {

                if (l.IDLeka.Equals(sifraLeka))
                {
                    return l;
                }
            }

            return null;
        }

        public static void SerijalizacijaLekova()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, SviLekovi);
            tw.Close();

        }

        public static Boolean IzmenaLeka(Lek noviLek)
        {

            foreach (Lek l in SviLekovi)
            {
                if (l.IDLeka.Equals(noviLek.IDLeka))
                {
                    l.NazivLeka = noviLek.NazivLeka;
                    l.Jacina = noviLek.Jacina;
                    l.Kolicina = l.Kolicina;
                    return true;
                }

            }

            return false;

        }

        public static List<Lek> DeserijalizacijaLekova()
        {
            if (File.ReadAllText("lekovi.xml").Trim().Equals(""))
            {
                return SviLekovi;
            }
            else
            {
                FileStream fileStream = File.OpenRead("lekovi.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
                SviLekovi = (List<Lek>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return SviLekovi;

            }

        }
    }
}
