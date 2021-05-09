using Bolnica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Model
{
    public class RukovanjeOpremom
    {
        private static String imeFajla = "oprema.xml";
        public static List<Oprema> oprema = new List<Oprema>();

        public static bool DodajOpremu(Oprema o)
        {

            if (oprema.Contains(o))
            {
                return false;
            }

            oprema.Add(o);
            PrikazOpreme.Oprema.Add(o);
            return true;
        }

        public static Boolean IzmeniOpremu(String stari, String idOpreme, String naziv, int vrstaOpreme, String kolicina)
        {
            Oprema o = PretraziPoId(stari);

            o.IdOpreme = idOpreme;
            o.NazivOpreme = naziv;

            if (vrstaOpreme == 0)
            {
                o.VrstaOpreme = VrsteOpreme.staticka;
            }
            else
            {
                o.VrstaOpreme = VrsteOpreme.dinamicka;
            }
            o.Kolicina = int.Parse(kolicina);

            int indeks = PrikazOpreme.Oprema.IndexOf(o);
            PrikazOpreme.Oprema.RemoveAt(indeks);
            PrikazOpreme.Oprema.Insert(indeks, o);

            return true;
        }

        public static Boolean UkloniOpremu(String idOpreme)
        {
            Oprema o = PretraziPoId(idOpreme);

            if (o == null)
            {
                return false;
            }

            oprema.Remove(o);
            PrikazOpreme.Oprema.Remove(o);

            SerijalizacijaOpreme();

            if (oprema.Contains(o) || PrikazOpreme.Oprema.Contains(o))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static void PremjestiKolicinuOpreme(Prostor prostorUKojiPrebacujemo, Oprema opremaKojuPrebacujemo, int kolicina)
        {
            ProvjeriKolicineKojuPremjestamo(opremaKojuPrebacujemo, kolicina);

            foreach (Oprema o in RukovanjeOpremom.SvaOprema())
            {
                if (o.IdOpreme.Equals(opremaKojuPrebacujemo.IdOpreme))
                {
                    o.Kolicina -= kolicina;
                }
            }

            if (!RukovanjeProstorom.DodajSamoKolicinu(prostorUKojiPrebacujemo, opremaKojuPrebacujemo, kolicina))
            {
                Oprema o = new Oprema(opremaKojuPrebacujemo.IdOpreme, opremaKojuPrebacujemo.NazivOpreme, opremaKojuPrebacujemo.VrstaOpreme, kolicina);
                RukovanjeProstorom.DodajOpremuProstoru(prostorUKojiPrebacujemo, o);
            }
        }

        public static bool ProvjeriKolicineKojuPremjestamo(Oprema oprema, int kolicina)
        {
            if (oprema.Kolicina < kolicina)
            {
                System.Windows.Forms.MessageBox.Show("Neispravna kolicina !", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static Oprema PretraziPoId(String idOpreme)
        {
            foreach (Oprema o in oprema)
            {
                if (o.IdOpreme.Equals(idOpreme))
                {
                    return o;
                }
            }

            return null;
        }

        public static List<Oprema> SvaOprema()
        {

            return oprema;
        }

        public static List<Oprema> DeserijalizacijaOpreme()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return oprema;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Oprema>));
                oprema = (List<Oprema>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return oprema;

            }

        }

        public static void SerijalizacijaOpreme()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Oprema>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, oprema);
            tw.Close();

        }


    }
}