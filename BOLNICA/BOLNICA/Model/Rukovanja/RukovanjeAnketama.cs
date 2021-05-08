using Bolnica.Model.Enumi;
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
    public class RukovanjeAnketama
    {

        public static String sveAnketeFajl = "sveAnkete.xml";
        public static List<Pitanje> pitanjaOPregledu = new List<Pitanje>();
        public static List<Pitanje> pitanjaOBolnici = new List<Pitanje>();
        public static List<Anketa> popunjeneAnkete = new List<Anketa>();
        public static void inicijalizujPitanjaOTerminu()
        {
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Ljubaznost lekara"));
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Stručnost lekara"));
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Dužina čekanja na prijem"));
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Čistoća prostorija"));
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Ljubaznost osoblja"));
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Zadovoljstvo pruženom uslugom"));
            pitanjaOPregledu.Add(new Pitanje(OcenaPitanja.pet, "Celokupna ocena za lekara"));
        }

        public static void inicijalizujPitanjaOBolnici()
        {
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Izgled bolnice"));
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Higijena bolnice"));
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Lokacija bolnice"));
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Obezbeđen parking"));
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Aplikacija bolnice"));
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Celokupna ocena osoblja"));
            pitanjaOBolnici.Add(new Pitanje(OcenaPitanja.pet, "Celokupna ocena bolnice"));
        }

        public static List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return pitanjaOPregledu;
        }


        public static List<Pitanje> DobaviSvaPitanjaOBolnici()
        {
            return pitanjaOBolnici;
        }
        public static List<Anketa> DobaviSveAnkete()
        {
            return popunjeneAnkete;
        }

        public static void DodajAnketu(Anketa anketa)
        {
            popunjeneAnkete.Add(anketa);
        }

        public static bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            DateTime novaAnketa = NadjiDatumPoslednjeAnketeOBolnici(pacijent).AddMonths(3);
            if (DateTime.Compare(DateTime.Now.Date, novaAnketa.Date) >= 0)
                return true;

            return false;
        }

        public static DateTime NadjiDatumPoslednjeAnketeOBolnici(Pacijent pacijent)
        {
            List<Anketa> anketePacijenta = new List<Anketa>();
            foreach (Anketa anketa in popunjeneAnkete)
            {
                if (anketa.Pacijent.KorisnickoIme.Equals(pacijent.KorisnickoIme) && anketa.Pregled == null)
                {
                    anketePacijenta.Add(anketa);
                }
            }
            if (anketePacijenta.Count == 0)
            {
                return DateTime.Now.Date.AddMonths(-3);
            }


            return SortirajAnketePoDatumu(anketePacijenta)[0].OcenioBolnicu;
        }

        public static List<Anketa> SortirajAnketePoDatumu(List<Anketa> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderByDescending(user => user.OcenioBolnicu).ToList();
        }

        public static List<Anketa> DeserijalizacijaAnketa()
        {
            if (!File.Exists(sveAnketeFajl) || File.ReadAllText(sveAnketeFajl).Trim().Equals(""))
            {
                return popunjeneAnkete;
            }
            else
            {
                FileStream fileStream = File.OpenRead(sveAnketeFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Anketa>));
                popunjeneAnkete = (List<Anketa>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return popunjeneAnkete;
            }

        }
        public static void SerijalizacijaAnketa()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Anketa>));
            TextWriter tw = new StreamWriter(sveAnketeFajl);
            xmlSerializer.Serialize(tw, popunjeneAnkete);
            tw.Close();

        }

    }
}
