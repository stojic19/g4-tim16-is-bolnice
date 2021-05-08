using Bolnica.Model.Rukovanja;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model
{
    class RukovanjeLijekovima
    {
        private static String imeFajla = "lijekovi.xml";
        private static String imeFajla1 = "sastojci.xml";

        public static List<Lek> lijekovi = new List<Lek>();
        public static List<Lek> zahtjevi = new List<Lek>();
        public static List<Sastojak> sastojci = new List<Sastojak>();

        public static Lek DodajLijek(Lek lijek)
        {
            lijekovi.Add(lijek);
            PrikazLijekova.Lijekovi.Add(lijek);

            if (lijekovi.Contains(lijek))
            {
                return lijek;
            }
            else
            {
                return null;
            }
        }

        public static Sastojak DodajSastojak(Sastojak sastojak)
        {
            sastojci.Add(sastojak);
            DetaljiOLijeku.Sastojci.Add(sastojak);

            if (sastojci.Contains(sastojak))
            {
                return sastojak;
            }
            else
            {
                return null;
            }
        }

        public static bool IzmjeniLijek(Lek lijek)
        {
            Lek l = pretraziPoId(lijek.IDLeka);

            l.IDLeka = lijek.IDLeka;
            l.NazivLeka = lijek.NazivLeka;
            l.Jacina = lijek.Jacina;
            l.Kolicina = int.Parse(lijek.Kolicina.ToString());
            l.Proizvodjac = lijek.Proizvodjac;
            // l.Sastojci = lijek.Sastojci;
            l.Verifikacija = lijek.Verifikacija;

            int indeks = PrikazLijekova.Lijekovi.IndexOf(l);
            PrikazLijekova.Lijekovi.RemoveAt(indeks);
            PrikazLijekova.Lijekovi.Insert(indeks, l);
            return true;
        }


        public static bool UkloniLijek(String idLijeka)
        {
            Lek lijek = pretraziPoId(idLijeka);
            if (lijek == null)
            {
                return false;
            }

            lijekovi.Remove(lijek);
            PrikazLijekova.Lijekovi.Remove(lijek);
            SerijalizacijaLijekova();

            if (lijekovi.Contains(lijek) || PrikazLijekova.Lijekovi.Contains(lijek))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static Lek pretraziPoId(String idLeka)
        {
            foreach (Lek l in lijekovi)
            {
                if (l.IDLeka == idLeka)
                    return l;
            }
            return null;
        }

        public static List<Lek> SviLijekovi()
        {
            return lijekovi;
        }

        public static List<Sastojak> SviSastojci()
        {
            return sastojci;
        }

        public static List<Lek> DeserijalizacijaLijekova()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return lijekovi;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
                lijekovi = (List<Lek>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return lijekovi;

            }

        }

        public static void SerijalizacijaLijekova()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, lijekovi);
            tw.Close();

        }

        /*public static List<Sastojak> DeserijalizacijaSastojaka()
        {
            if (File.ReadAllText(imeFajla1).Trim().Equals(""))
            {
                return sastojci;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla1);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sastojak>));
                sastojci = (List<Sastojak>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sastojci;

            }

        }

        public static void SerijalizacijaProstoraZaRenoviranje()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sastojak>));
            TextWriter tw = new StreamWriter(imeFajla1);
            xmlSerializer.Serialize(tw, sastojci);
            tw.Close();

        }*/

    }
}
