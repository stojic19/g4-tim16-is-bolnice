using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Repozitorijum
{
    public class LekoviRepozitorijum
    {
        public static List<Lek> SviLekovi { get; set; } = new List<Lek>();

        public void DodajLek(Lek novLek)
        {
            SviLekovi.Add(novLek);
        }

        public static void SerijalizacijaLekova()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
            TextWriter tw = new StreamWriter("lekovi.xml");
            xmlSerializer.Serialize(tw, SviLekovi);
            tw.Close();

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
