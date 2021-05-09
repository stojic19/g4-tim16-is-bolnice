using Bolnica;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Model
{
    public class RukovanjeProstorom
    {
        private static String imeFajla = "prostori.xml";
        private static String imeFajla1 = "renoviranje.xml";
        public static List<Prostor> prostori = new List<Prostor>();
        public static List<Oprema> oprema = new List<Oprema>();
        public static List<Renoviranje> prostorKojiSeRenovira = new List<Renoviranje>();

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



        public static Boolean IzmeniProstor(String stari, String idProstora, int vrstaProstora, String Sprat, String Kvadratura, String BrojKreveta)
        {
            Prostor p = PretraziPoId(stari);

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
            foreach (Prostor p in prostori)
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

        public static List<Oprema> SvaOpremaProstora()
        {

            return oprema;
        }

        public static bool DodajZaRenoviranje(Renoviranje renoviranje)
        {

            prostorKojiSeRenovira.Add(renoviranje);
            return true;

        }

        public static void ProveriRenoviranje()
        {


            foreach (Renoviranje r in prostorKojiSeRenovira)
            {
                if (provjeraDatuma(r.StartDay.Date, r.EndDay.Date))
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
            foreach (Prostor p in prostori)
            {
                if (p.IdProstora.Equals(r.RoomId))
                {
                    p.JeRenoviranje = true;
                    break;
                }
            }
        }

        public static void PostaviDaSeNeRenovira(Renoviranje r)
        {
            foreach (Prostor p in prostori)
            {
                if (p.IdProstora.Equals(r.RoomId))
                {
                    p.JeRenoviranje = false;
                    break;
                }
            }
        }

        public static bool DodajSamoKolicinu(Prostor prostorUKojiPrebacujemo, Oprema oprema, int kolicina)
        {
            foreach (Oprema o in prostorUKojiPrebacujemo.Oprema)
            {
                if (o.IdOpreme.Equals(oprema.IdOpreme))
                {
                    o.Kolicina += kolicina;
                    return true;
                }

            }
            return false;
        }

        public static void DodajOpremuProstoru(Prostor prostorUKojiPrebacujemo, Oprema o)
        {
            prostorUKojiPrebacujemo.Oprema.Add(o);
        }

        public static void ProvjeriZakazaneTermine(DatePicker pocetniDatum, DatePicker zavrsniDatum)
        {
            foreach (Termin t in RukovanjeTerminima.DobaviSveTermine())
            {
                if (t.Datum >= DateTime.Parse(pocetniDatum.Text) && t.Datum <= DateTime.Parse(zavrsniDatum.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Postoje zakazani termini za taj period, trazite drugi datum !", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        public static List<Prostor> DeserijalizacijaProstora()
        {
            DeserijalizacijaProstoraZaRenoviranje();
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return prostori;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Prostor>));
                prostori = (List<Prostor>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return prostori;

            }

        }

        public static void SerijalizacijaProstora()
        {
            SerijalizacijaProstoraZaRenoviranje();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Prostor>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, prostori);
            tw.Close();

        }

        public static List<Renoviranje> DeserijalizacijaProstoraZaRenoviranje()
        {
            if (File.ReadAllText(imeFajla1).Trim().Equals(""))
            {
                return prostorKojiSeRenovira;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla1);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Renoviranje>));
                prostorKojiSeRenovira = (List<Renoviranje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return prostorKojiSeRenovira;

            }

        }

        public static void SerijalizacijaProstoraZaRenoviranje()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Renoviranje>));
            TextWriter tw = new StreamWriter(imeFajla1);
            xmlSerializer.Serialize(tw, prostorKojiSeRenovira);
            tw.Close();

        }

    }
}