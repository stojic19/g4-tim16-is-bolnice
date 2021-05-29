using Bolnica;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Model
{
    public class ProstoriServis
    {
        ZakazaniTerminiServis terminiServis = new ZakazaniTerminiServis();

        private static String imeFajla = "prostori.xml";
        private static String imeFajla1 = "renoviranje.xml";
        public static List<Prostor> prostori = new List<Prostor>();
        public static List<Oprema> oprema = new List<Oprema>();
        public static List<Renoviranje> prostorKojiSeRenovira = new List<Renoviranje>();
       
       
        public static void DodajProstor(Prostor p)
        { 
            if (!prostori.Contains(p))
            {
                prostori.Add(p);
                PrikazProstora.Prostori.Add(p);
            }
        }


        public static Boolean IzmeniProstor(Prostor noviPodaci)
        {
            foreach (Prostor p in ProstoriServis.SviProstori())
            {
                if (p.IdProstora.Equals(noviPodaci.IdProstora))
                {
                    p.NazivProstora = noviPodaci.NazivProstora;
                    p.VrstaProstora = noviPodaci.VrstaProstora;
                    p.Sprat = noviPodaci.Sprat;
                    p.Kvadratura = noviPodaci.Kvadratura;

                    int indeks = PrikazProstora.Prostori.IndexOf(p);
                    PrikazProstora.Prostori.RemoveAt(indeks);
                    PrikazProstora.Prostori.Insert(indeks, p);
                    return true;
                } 
            }

            return false;
        }

        public static void UkloniProstor(String idProstora)
        {
            Prostor prostor = PretraziPoId(idProstora);
            prostori.Remove(prostor);
            PrikazProstora.Prostori.Remove(prostor);
                
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

        public static void OduzmiKolicinuOpreme(Prostor prostorIzKojegPremjestamo, Oprema oprema, int kolicina)
        {
            foreach (Oprema o in prostorIzKojegPremjestamo.Oprema)
            {
                if (o.Equals(oprema))
                {
                    o.Kolicina -= kolicina;
                }
            }
        }

        public static void PremjestiOpremuUDrugiProstor(Prostor prostorUKojiPremjestamo, Oprema oprema, int kolicina)
        {

            if (!DodajSamoKolicinu(prostorUKojiPremjestamo, oprema, kolicina))
            {
                Oprema o = new Oprema(oprema.IdOpreme, oprema.NazivOpreme, oprema.VrstaOpreme, kolicina);
                ProstoriServis.DodajOpremuProstoru(prostorUKojiPremjestamo, o);
            }
            if (oprema.NazivOpreme.Equals("krevet"))
                prostorUKojiPremjestamo.BrojSlobodnihKreveta += kolicina;
        }

        public static Oprema PretraziOpremuUProstoru(Prostor prostor, Oprema oprema)
        {
            foreach (Oprema o in prostor.Oprema)
            {
                if (o == oprema)
                {
                    return o;
                }
            }
            return null;
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

        public static bool DodajSamoKolicinu(Prostor prostorUKojiPrebacujemo, Oprema oprema, int kolicina)
        {
            foreach (Oprema o in prostorUKojiPrebacujemo.Oprema)
            {
                if (o == oprema)
                {
                    o.Kolicina += kolicina;
                    return true;
                }

            }
            return false;

            if (oprema.NazivOpreme.Equals("krevet"))
                prostorUKojiPrebacujemo.BrojSlobodnihKreveta += kolicina;
        }

        public static void DodajOpremuProstoru(Prostor prostorUKojiPrebacujemo, Oprema o)
        {
            prostorUKojiPrebacujemo.Oprema.Add(o);
            
        }

        public void ProvjeriZakazaneTermine(DateTime pocetniDatum, DateTime zavrsniDatum)
        {
            foreach (Termin t in terminiServis.DobaviSveZakazaneTermine())
            {
                if (t.Datum >= pocetniDatum && t.Datum <= zavrsniDatum)
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