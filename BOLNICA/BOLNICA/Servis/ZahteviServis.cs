using Bolnica.Repozitorijum;
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
    class ZahteviServis
    {
        public static List<Zahtjev> SviZahtevi { get; set; } = new List<Zahtjev>();
        private static String imeFajla = "zahtjevi.xml";
        

        public static Zahtjev PretraziPoId(String idZahteva)
        {
            foreach(Zahtjev z in SviZahtevi)
            {
                if (z.IdZahtjeva.Equals(idZahteva))
                {
                    return z;
                }
            }

            return null;
        }

        public static Zahtjev PretraziPoIdLeka(String idLeka)
        {
            foreach (Zahtjev z in SviZahtevi)
            {
                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    return z;
                }
            }

            return null;
        }

        public static void OdobriZahtev(String idZahteva)
        {
            foreach(Zahtjev z in SviZahtevi)
            {
                if (z.IdZahtjeva.Equals(idZahteva))
                {
                    z.Odgovor = Enumi.VrsteOdgovora.Odobren;
                    z.Lijek.Verifikacija = true;
                    LekoviRepozitorijum.SviLekovi.Add(z.Lijek);
                }
            }

        }

        public static void OdbijZahtev(String idZahteva, String razlogOdbijanja)
        {
            foreach (Zahtjev z in SviZahtevi)
            {
                if (z.IdZahtjeva.Equals(idZahteva))
                {
                    z.Odgovor = Enumi.VrsteOdgovora.Odbijen;
                    z.RazlogOdbijanja = razlogOdbijanja;
                }
            }

        }

        public static bool DodajZahtjev(Zahtjev zahtjev)
        {

            if (SviZahtevi.Contains(zahtjev))
            {
                return false;
            }

            zahtjev.DatumSlanja = DateTime.Now;
            zahtjev.Odgovor = Enumi.VrsteOdgovora.Čekanje;
            SviZahtevi.Add(zahtjev);
            PrikazLijekova.Zahtjevi.Add(zahtjev);
            return true;
        }

        public static bool IzmeniLek(Lek noviPodaci)
        {
            foreach (Zahtjev z in SviZahtevi)
            {
                if (z.Lijek.IDLeka.Equals(noviPodaci.IDLeka))
                {
                    z.Lijek.NazivLeka = noviPodaci.NazivLeka;
                    z.Lijek.Jacina = noviPodaci.Jacina;
                    z.Lijek.Kolicina = int.Parse(noviPodaci.Kolicina.ToString());
                    z.Lijek.Proizvodjac = noviPodaci.Proizvodjac;

                    int indeks = PrikazLijekova.Zahtjevi.IndexOf(z);
                    PrikazLijekova.Zahtjevi.RemoveAt(indeks);
                    PrikazLijekova.Zahtjevi.Insert(indeks, z);
                    return true;
                }
            }

            return false;
        }

        public static void UklanjanjeLeka(String idLeka)
        {
            foreach (Zahtjev z in SviZahtevi.ToList())
            {
                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    SviZahtevi.Remove(z);
                    PrikazLijekova.Zahtjevi.Remove(z);
                }
            }
        }

        public static void DodajSastojak(Sastojak sastojak, String idLeka)
        {
            foreach (Zahtjev z in SviZahtevi)
            {

                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    z.Lijek.Sastojci.Add(sastojak);
                    DetaljiOLijeku.Sastojci.Add(sastojak);
                    break;
                }
            }

        }

        public static Lek pretraziLekPoId(String idLeka)
        {
            foreach (Zahtjev z in SviZahtevi)
            {
                if (z.Lijek.IDLeka.Equals(idLeka))
                {
                    return z.Lijek;
                }
            }

            return null;
        }


        public static List<Zahtjev> DeserijalizacijaZahtjeva()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return SviZahtevi;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Zahtjev>));
                SviZahtevi = (List<Zahtjev>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return SviZahtevi;

            }

        }

        public static void SerijalizacijaZahtjeva()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Zahtjev>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, SviZahtevi);
            tw.Close();

        }
    }
}
